using System;
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
	public class OrderController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OrderController));
		private readonly OrderRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public OrderController(IConversation conversation, IMappingEngine mapper, OrderRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Order> set = _repository.Search(orderId, orderDate, requiredDate, shippedDate, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				OrderDto[] items = _mapper.Map<IEnumerable<Order>, OrderDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}