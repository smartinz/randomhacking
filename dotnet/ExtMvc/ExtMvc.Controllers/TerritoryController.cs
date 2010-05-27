using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Conversation;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using log4net;
using Nexida.Infrastructure;

namespace ExtMvc.Controllers
{
	public class TerritoryController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(TerritoryController));
		private readonly TerritoryRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public TerritoryController(IConversation conversation, IMappingEngine mapper, TerritoryRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
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