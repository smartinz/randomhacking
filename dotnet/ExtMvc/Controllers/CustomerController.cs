﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Castle.Core.Logging;
using Conversation;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using ExtMvc.Infrastructure;

namespace ExtMvc.Controllers
{
	public class CustomerController : Controller
	{
		private readonly IConversation _conversation;
		private readonly IMappingEngine _mapper;
		private readonly CustomerRepository _customerRepository;
		public ILogger Logger = NullLogger.Instance;

		public CustomerController(IConversation conversation, IMappingEngine mapper, CustomerRepository customerRepository)
		{
			_conversation = conversation;
			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		public ActionResult Find(string companyName, string contactName, string contactTitle, int start, int limit, string sort, string dir)
		{
			using(_conversation.SetAsCurrent())
			{
				Tuple<IEnumerable<Customer>, int> tuple = _customerRepository.Find(companyName, contactName, contactTitle, start, limit, sort, dir);
				CustomerDto[] items = _mapper.Map<IEnumerable<Customer>, CustomerDto[]>(tuple.Item1);
				return Json(new{ items, count = tuple.Item2 });
			}
		}

		public ActionResult Get(string id)
		{
			Logger.DebugFormat("Get(id: {0}", id);
			using(_conversation.SetAsCurrent())
			{
				Customer customer = _customerRepository.Read(id);
				CustomerDto data = _mapper.Map<Customer, CustomerDto>(customer);
				return Json(new{ success = true, data });
			}
		}

		public ActionResult Update(CustomerDto item)
		{
			Logger.DebugFormat("Update(item: {0})", item);
			ValidationManager.Validate(ModelState, item, "item");
			return Json(ValidationManager.BuildResponse(ModelState));
		}
	}
}