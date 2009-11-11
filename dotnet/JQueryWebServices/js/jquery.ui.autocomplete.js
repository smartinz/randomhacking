/*
 * jQuery UI Autocomplete @VERSION
 *
 * Copyright (c) 2009 AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * http://docs.jquery.com/UI/Autocomplete
 *
 * Depends:
 *	jquery.ui.core.js
 */
(function($) {

$.widget("ui.autocomplete", {
	_init: function() {
		var self = this;
		this.cache = {};
		this.element.attr("autocomplete", "off").addClass("ui-autocomplete")
		// TODO verify these actually work as intended
		.attr("role", "textbox").attr("aria-autocomplete", "list").attr("aria-haspopup", "true")
		.bind("keydown.autocomplete", function(event) {
			switch(event.keyCode) {
			case $.ui.keyCode.PAGE_UP:
				self.move("previousPage");
				break;
			case $.ui.keyCode.PAGE_DOWN:
				self.move("nextPage");
				break;
			case $.ui.keyCode.UP:
				self.move("previous");
				event.preventDefault();
				break;
			case $.ui.keyCode.DOWN:
				self.move("next");
				event.preventDefault();
				break;
			case $.ui.keyCode.ENTER:
			case $.ui.keyCode.TAB:
				self.select();
				break;
			case $.ui.keyCode.ESCAPE:
				self.element.val(self.term);
				self.close();
				break;
			case 16:
			case 17:
			case 18:
				// ignore metakeys (shift, ctrl, alt)
				break;
			default:
				// keypress is triggered before the input value is changed
				clearTimeout(self.searching);
				self.searching = setTimeout(function() {
					self.search();
				}, self.options.delay);
				break;
			}
		}).focus(function() {
			self.previous = self.element.val();
		}).blur(function() {
			clearTimeout(self.searching);
			// clicks on the menu (or a button to trigger a search) will cause a blur event
			// TODO try to implement this without a timeout, see clearTimeout in search()
			self.closing = setTimeout(function() {
				// TODO pass {data: item} when a valid value is selected, even when the suggestionlist wasn't used
				self.close();
			}, 150);
		});
		this.initSource();
	},
	
	destroy: function() {
		// TODO implement
	},
	
	// TODO call when source-option is updated
	initSource: function() {
		if ($.isArray(this.options.source)) {
			var array = this.options.source;
			this.source = function(request, response) {
				// escape regex characters
				var matcher = new RegExp(request.term.replace(/([\^\$\(\)\[\]\{\}\*\.\+\?\|\\])/gi, "\\$1"), "i");
				return $.grep(array, function(value) {
    				return matcher.test(value)
				});
			}
		} else if (typeof this.options.source == "string") {
			var url = this.options.source;
			this.source = function(request, response) {
				$.getJSON(url, request, response);
			}
		} else {
			this.source = this.options.source;
		}
		// proxy with cache provider
		if (this.options.cache) {
			var self = this;
			this.source = (function(source) {
				return function(request) {
					if (self.cache.term == request.term && self.cache.content)
						return self.cache.content;
					if (new RegExp(self.cache.term).test(request.term) && self.cache.content && self.cache.content.length < self.options.cache.limit) {
						// TODO refactor with array-source above
						var matcher = new RegExp(request.term.replace(/([\^\$\(\)\[\]\{\}\*\.\+\?\|\\])/gi, "\\$1"), "i");
						return $.grep(self.cache.content, function(value) {
		    				return matcher.test(value.result)
						});
					}
					return source.apply(this, arguments);
				}
			})(this.source);
		}
	},
	
	search: function(value) {
		var self = this;
		clearTimeout(self.closing);
		value = value !== undefined ? value : this.element.val();
		if (value.length >= this.options.minLength) {
			if (this._trigger("search") === false)
				return;
			self.element.addClass("ui-autocomplete-loading");
			// always save the actual value, not the one passed as an argument
			self.term = this.element.val();
			function response(content) {
				if (content.length) {
					content = self.normalize(content);
					// cache response
					if (self.options.cache) {
						self.cache.term = value;
						self.cache.content = content;
					}
					self._trigger("open");
					self.suggest(content);
				} else {
					self.close();
				}
				self.element.removeClass("ui-autocomplete-loading");
			}
			// source can call response or return content directly
			var result = this.source({ term: value }, response);
			if (result) {
				response(result);
			}
		} else {
			self.close();
		}
	},
	
	close: function(selected) {
		clearTimeout(this.closing);
		if (this.menu) {
			this._trigger("close");
			this.menu.element.remove();
			this.menu = null;
		}
		// TODO don't trigger when input is below minLength
		if (this.previous != this.element.val()) {
			this._trigger("change", null, selected);
		}
	},
	
	normalize: function(items) {
		// TODO consider optimization: if first item has the right format, assume all others have it as well
		return $.map(items, function(item) {
			if (typeof item == "string") {
				return {
					label: item,
					result: item
				};
			}
			return $.extend({
				label: item.label || item.result,
				result: item.result || item.label
			}, item);
		})
	},
	
	suggest: function(items) {
		this.menu && this.menu.element.remove();
		var self = this;
		var ul = $("<ul/>");
		$.each(items, function(index, item) { 
			$("<li/>").data("item.autocomplete", item).append("<a>" + item.label + "</a>").appendTo(ul); 
		})
		ul.addClass("ui-autocomplete-menu").appendTo(document.body).menu({ 
			focus: function(event, ui) {
				self._trigger("focus", null, { item: ui.item.data("item.autocomplete") });
				// use result to match what will end up in the input
				self.element.val(ui.item.data("item.autocomplete").result);
			},
			selected: function(event, ui) {
				var data = ui.item.data("item.autocomplete");
				self.element.val( data.result );
				self.close({ item: data });
				// prevent the blur handler from triggering another change event
				self.previous = data.result;
				// TODO only trigger when focus was lost?
				self.element.focus();
			} 
		})
		.removeClass("ui-corner-all").addClass("ui-corner-bottom")
		.position({ 
			my: "left top", 
			at: "left bottom", 
			of: this.element 
		});
		this.menu = ul.data("menu");
		if (ul.width() <= this.element.width()) {
			ul.width(this.element.width());
		}
	},
	
	move: function(direction) {
		if (!this.menu) {
			this.search();
			return;
		}
		if (this.menu.first() && /^previous/.test(direction) || this.menu.last() && /^next/.test(direction)) {
			this.element.val(this.term);
			this.menu.deactivate();
			return;
		}
		this.menu[direction]();
	},
	
	select: function() {
		if (!this.menu)
			return;
		this.menu.select();
	},
	
	widget: function() {
		// return empty jQuery object when menu isn't initialized yet
		return this.menu && this.menu.element || $([]);
	}
});

$.ui.autocomplete.defaults = {
	// caching isn't working yet, disable by default for now
	cache: {
		limit: 50
	},
	minLength: 1,
	delay: 300
}

})(jQuery);