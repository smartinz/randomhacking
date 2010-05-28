using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Conversation;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using log4net;
using Nexida.Infrastructure;
using Nexida.Infrastructure.Mvc;

namespace ExtMvc.Controllers
{
	public class CustomerDemographicController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CustomerDemographicController));
		private readonly CustomerDemographicRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;
		private readonly IStringConverter<CustomerDemographic> _stringConverter;

		public CustomerDemographicController(IConversation conversation, IMappingEngine mapper, CustomerDemographicRepository repository, IValidator validator, IStringConverter<CustomerDemographic> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Create(CustomerDemographicDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				CustomerDemographic itemMapped = _mapper.Map<CustomerDemographicDto, CustomerDemographic>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Create(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Read(string stringId)
		{
			using(_conversation.SetAsCurrent())
			{
				CustomerDemographic item = _stringConverter.FromString(stringId);
				CustomerDemographicDto itemDto = _mapper.Map<CustomerDemographic, CustomerDemographicDto>(item);
				return Json(itemDto);
			}
		}

		public ActionResult Update(CustomerDemographicDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				CustomerDemographic itemMapped = _mapper.Map<CustomerDemographicDto, CustomerDemographic>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Update(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Delete(CustomerDemographicDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				CustomerDemographic itemMapped = _mapper.Map<CustomerDemographicDto, CustomerDemographic>(item);
				_repository.Delete(itemMapped);
				_conversation.Flush();
				return Json(new{ success = true });
			}
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