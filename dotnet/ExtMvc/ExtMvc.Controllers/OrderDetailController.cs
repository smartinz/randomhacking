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
	public class OrderDetailController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OrderDetailController));
		private readonly OrderDetailRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public OrderDetailController(IConversation conversation, IMappingEngine mapper, OrderDetailRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? orderId, int? productId, decimal? unitPrice, short? quantity, float? discount, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<OrderDetail> set = _repository.Search(orderId, productId, unitPrice, quantity, discount);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				OrderDetailDto[] items = _mapper.Map<IEnumerable<OrderDetail>, OrderDetailDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}