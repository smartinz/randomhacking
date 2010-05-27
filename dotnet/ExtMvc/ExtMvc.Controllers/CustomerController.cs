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
	public class CustomerController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CustomerController));
		private readonly CustomerRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public CustomerController(IConversation conversation, IMappingEngine mapper, CustomerRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Customer> set = _repository.Search(customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				CustomerDto[] items = _mapper.Map<IEnumerable<Customer>, CustomerDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}