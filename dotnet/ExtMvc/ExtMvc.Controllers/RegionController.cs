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
	public class RegionController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(RegionController));
		private readonly RegionRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public RegionController(IConversation conversation, IMappingEngine mapper, RegionRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? regionId, string regionDescription, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Region> set = _repository.Search(regionId, regionDescription);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				RegionDto[] items = _mapper.Map<IEnumerable<Region>, RegionDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}