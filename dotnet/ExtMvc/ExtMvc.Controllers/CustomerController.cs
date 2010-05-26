using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Conversation;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using ExtMvc.Infrastructure;
using log4net;
using System.Linq;

namespace ExtMvc.Controllers
{
	public class CustomerController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CustomerController));
		private readonly IConversation _conversation;
		private readonly IMappingEngine _mapper;
		private readonly CustomerRepository _customerRepository;
		private readonly ValidationManager _validationManager;

		public CustomerController(IConversation conversation, IMappingEngine mapper, CustomerRepository customerRepository, ValidationManager validationManager)
		{
			_conversation = conversation;
			_mapper = mapper;
			_customerRepository = customerRepository;
			_validationManager = validationManager;
		}

		public ActionResult Find(string companyName, string contactName, string contactTitle, int start, int limit, string sort, string dir)
		{
			using(_conversation.SetAsCurrent())
			{
				var set = _customerRepository.Search(null, companyName, contactName, contactTitle, null, null, null, null, null, null, null);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				var customers = set.AsEnumerable().ToArray();
				CustomerDto[] items = _mapper.Map<IEnumerable<Customer>, CustomerDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}

		public ActionResult Get(string id)
		{
			Log.DebugFormat("Get(id: {0}", id);
			using(_conversation.SetAsCurrent())
			{
				Customer customer = _customerRepository.Read(id);
				CustomerDto data = _mapper.Map<Customer, CustomerDto>(customer);
				return Json(new{ success = true, data });
			}
		}

		public ActionResult Update(CustomerDto item)
		{
			Log.DebugFormat("Update(item: {0})", item);
			_validationManager.Validate(ModelState, item, "item");
			return Json(ValidationManager.BuildResponse(ModelState));
		}
	}
}