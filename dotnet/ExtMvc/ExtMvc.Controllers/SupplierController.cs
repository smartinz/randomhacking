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
	public class SupplierController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(SupplierController));
		private readonly SupplierRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public SupplierController(IConversation conversation, IMappingEngine mapper, SupplierRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Supplier> set = _repository.Search(supplierId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax, homePage);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				SupplierDto[] items = _mapper.Map<IEnumerable<Supplier>, SupplierDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}