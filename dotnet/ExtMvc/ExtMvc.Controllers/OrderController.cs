using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
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
			IPresentableSet<Order> set = _orderRepository.Search(null, null, null, null, null, null, null, null, null, null, null);
			set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
			OrderDto[] items = _mapper.Map<IEnumerable<Order>, OrderDto[]>(set.AsEnumerable());
			return Json(new{ items, count = set.Count() });
		}
	}
}