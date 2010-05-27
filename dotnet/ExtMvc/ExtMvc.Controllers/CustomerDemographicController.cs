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
	public class CustomerDemographicController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CustomerDemographicController));
		private readonly CustomerDemographicRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public CustomerDemographicController(IConversation conversation, IMappingEngine mapper, CustomerDemographicRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(string customerTypeId, string customerDesc, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<CustomerDemographic> set = _repository.Search(customerTypeId, customerDesc);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				CustomerDemographicDto[] items = _mapper.Map<IEnumerable<CustomerDemographic>, CustomerDemographicDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}