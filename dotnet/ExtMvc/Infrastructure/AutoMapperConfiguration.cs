using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using ExtMvc.Domain;
using ExtMvc.Dtos;

namespace SpikeWcf
{
	public static class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Reset();
			//Mapper.Initialize(c=>c.ConstructServicesUsing()); // For IoC container
			DomainToDto();
			DtoToDomain();
			Mapper.AssertConfigurationIsValid();
		}

		private static void DomainToDto()
		{
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<Order, OrderDto>();
		}

		private static void DtoToDomain()
		{
		}

		private static void FillCollection<TSource, TDestination, TSourceItem, TDestinationItem>(TSource s, TDestination d, Func<TSource, IEnumerable<TSourceItem>> getSourceEnum, Func<TDestination, ICollection<TDestinationItem>> getDestinationColl)
		{
			ICollection<TDestinationItem> collection = getDestinationColl(d);
			collection.Clear();
			foreach(TSourceItem sourceItem in getSourceEnum(s) ?? new TSourceItem[0])
			{
				collection.Add(Mapper.Map<TSourceItem, TDestinationItem>(sourceItem));
			}
		}

		private static void ResolveUsing<TSource>(this IMemberConfigurationExpression<TSource> o, Func<TSource, object> func)
		{
			o.ResolveUsing(new FuncValueResolver<TSource, object>(func));
		}

		#region Nested type: FuncValueResolver

		private class FuncValueResolver<TSource, TDestination> : ValueResolver<TSource, TDestination>
		{
			private readonly Func<TSource, TDestination> _func;

			public FuncValueResolver(Func<TSource, TDestination> func)
			{
				_func = func;
			}

			protected override TDestination ResolveCore(TSource source)
			{
				return _func(source);
			}
		}

		#endregion

	}
}