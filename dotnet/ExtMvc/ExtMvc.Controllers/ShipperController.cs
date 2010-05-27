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
	public class ShipperController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ShipperController));
		private readonly ShipperRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public ShipperController(IConversation conversation, IMappingEngine mapper, ShipperRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? shipperId, string companyName, string phone, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Shipper> set = _repository.Search(shipperId, companyName, phone);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				ShipperDto[] items = _mapper.Map<IEnumerable<Shipper>, ShipperDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}