using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using log4net;

namespace ExtMvc.Controllers
{
	public class OrderController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OrderController));
		private readonly IMappingEngine _mapper;
		private readonly OrderRepository _orderRepository;

		public OrderController(IMappingEngine mapper, OrderRepository orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}

		public ActionResult Find(int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Find(start: {0}, limit: {1}, sort: {2}, dir: {3})", start, limit, sort, dir);
			Tuple<IEnumerable<Order>, int> tuple = _orderRepository.Find(start, limit, sort, dir);
			OrderDto[] items = _mapper.Map<IEnumerable<Order>, OrderDto[]>(tuple.Item1);
			return Json(new{ items, tuple.Item2 });
		}
	}
}