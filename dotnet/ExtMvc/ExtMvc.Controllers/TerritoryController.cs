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
	public class TerritoryController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(TerritoryController));
		private readonly TerritoryRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;
		private readonly IStringConverter<Territory> _stringConverter;

		public TerritoryController(IConversation conversation, IMappingEngine mapper, TerritoryRepository repository, IValidator validator, IStringConverter<Territory> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Create(TerritoryDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Territory itemMapped = _mapper.Map<TerritoryDto, Territory>(item);
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
				Territory item = _stringConverter.FromString(stringId);
				TerritoryDto itemDto = _mapper.Map<Territory, TerritoryDto>(item);
				return Json(itemDto);
			}
		}

		public ActionResult Update(TerritoryDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Territory itemMapped = _mapper.Map<TerritoryDto, Territory>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Update(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Delete(TerritoryDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Territory itemMapped = _mapper.Map<TerritoryDto, Territory>(item);
				_repository.Delete(itemMapped);
				_conversation.Flush();
				return Json(new{ success = true });
			}
		}

		public ActionResult Search(string territoryId, string territoryDescription, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Territory> set = _repository.Search(territoryId, territoryDescription);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				TerritoryDto[] items = _mapper.Map<IEnumerable<Territory>, TerritoryDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}