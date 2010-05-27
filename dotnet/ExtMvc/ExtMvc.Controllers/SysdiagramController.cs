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
	public class SysdiagramController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(SysdiagramController));
		private readonly SysdiagramRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public SysdiagramController(IConversation conversation, IMappingEngine mapper, SysdiagramRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
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