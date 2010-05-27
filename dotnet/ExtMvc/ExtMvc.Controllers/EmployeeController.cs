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
	public class EmployeeController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(EmployeeController));
		private readonly EmployeeRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public EmployeeController(IConversation conversation, IMappingEngine mapper, EmployeeRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? employeeId, string lastName, string firstName, string title, string titleOfCourtesy, DateTime? birthDate, DateTime? hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, string photoPath, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Employee> set = _repository.Search(employeeId, lastName, firstName, title, titleOfCourtesy, birthDate, hireDate, address, city, region, postalCode, country, homePhone, extension, notes, photoPath);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				EmployeeDto[] items = _mapper.Map<IEnumerable<Employee>, EmployeeDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}