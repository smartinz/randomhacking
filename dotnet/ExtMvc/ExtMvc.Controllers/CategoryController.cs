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
	public class CategoryController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CategoryController));
		private readonly CategoryRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;

		public CategoryController(IConversation conversation, IMappingEngine mapper, CategoryRepository repository, IValidator validator)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
		}

		public ActionResult Search(int? categoryId, string categoryName, string description, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");


			using(_conversation.SetAsCurrent())
			{
				IPresentableSet<Category> set = _repository.Search(categoryId, categoryName, description);
				set = set.Skip(start).Take(limit).Sort(sort, dir == "ASC");
				CategoryDto[] items = _mapper.Map<IEnumerable<Category>, CategoryDto[]>(set.AsEnumerable());
				return Json(new{ items, count = set.Count() });
			}
		}
	}
}