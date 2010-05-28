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
	public class CategoryController : Controller
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CategoryController));
		private readonly CategoryRepository _repository;
		private readonly IMappingEngine _mapper;
		private readonly IValidator _validator;
		private readonly IConversation _conversation;
		private readonly IStringConverter<Category> _stringConverter;

		public CategoryController(IConversation conversation, IMappingEngine mapper, CategoryRepository repository, IValidator validator, IStringConverter<Category> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Create(CategoryDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Category itemMapped = _mapper.Map<CategoryDto, Category>(item);
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
				Category item = _stringConverter.FromString(stringId);
				CategoryDto itemDto = _mapper.Map<Category, CategoryDto>(item);
				return Json(itemDto);
			}
		}

		public ActionResult Update(CategoryDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Category itemMapped = _mapper.Map<CategoryDto, Category>(item);
				ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if(ModelState.IsValid)
				{
					_repository.Update(itemMapped);
					_conversation.Flush();
				}
				return Json(new{ success = true });
			}
		}

		public ActionResult Delete(CategoryDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				Category itemMapped = _mapper.Map<CategoryDto, Category>(item);
				_repository.Delete(itemMapped);
				_conversation.Flush();
				return Json(new{ success = true });
			}
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