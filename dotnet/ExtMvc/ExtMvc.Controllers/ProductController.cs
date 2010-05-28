using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Conversation;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using log4net;
using Nexida.Infrastructure;
using Nexida.Infrastructure.Mvc;

namespace ExtMvc.Controllers
{
	public class ProductController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ProductController));
		private readonly ProductRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;
		private readonly IStringConverter<Product> _stringConverter;

		public ProductController(IConversation conversation, IMappingEngine mapper, ProductRepository repository, IValidator validator, IStringConverter<Product> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Create(ProductDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Product itemMapped = _mapper.Map<ProductDto, Product>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Create(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Read(string stringId)
		{
			using(_conversation.SetAsCurrent())
			{
				Product item = _stringConverter.FromString(stringId);
				ProductDto itemDto = _mapper.Map<Product, ProductDto>(item);
				return Json(itemDto);
			}
		}

		public ActionResult Update(ProductDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Product itemMapped = _mapper.Map<ProductDto, Product>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Update(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Delete(ProductDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Product itemMapped = _mapper.Map<ProductDto, Product>(item);
				_repository.Delete(itemMapped);
				_conversation.Flush();
				return Json(new{ success = true });
			}
		}

		public ActionResult Search(int? productId, string productName, string quantityPerUnit, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool? discontinued, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Product> set = _repository.Search(productId, productName, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				ProductDto[] items = _mapper.Map<IEnumerable<Product>, ProductDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}