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
	public class SysdiagramController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(SysdiagramController));
		private readonly SysdiagramRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;
		private readonly IStringConverter<Sysdiagram> _stringConverter;

		public SysdiagramController(IConversation conversation, IMappingEngine mapper, SysdiagramRepository repository, IValidator validator, IStringConverter<Sysdiagram> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Create(SysdiagramDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Sysdiagram itemMapped = _mapper.Map<SysdiagramDto, Sysdiagram>(item);
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
				Sysdiagram item = _stringConverter.FromString(stringId);
				SysdiagramDto itemDto = _mapper.Map<Sysdiagram, SysdiagramDto>(item);
				return Json(itemDto);
			}
		}

		public ActionResult Update(SysdiagramDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Sysdiagram itemMapped = _mapper.Map<SysdiagramDto, Sysdiagram>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Update(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Delete(SysdiagramDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Sysdiagram itemMapped = _mapper.Map<SysdiagramDto, Sysdiagram>(item);
				_repository.Delete(itemMapped);
				_conversation.Flush();
				return Json(new{ success = true });
			}
		}

		public ActionResult Search(string name, int? principalId, int? diagramId, int? version, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Sysdiagram> set = _repository.Search(name, principalId, diagramId, version);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				SysdiagramDto[] items = _mapper.Map<IEnumerable<Sysdiagram>, SysdiagramDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}