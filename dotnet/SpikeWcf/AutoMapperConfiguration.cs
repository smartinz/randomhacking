using System;
using System.Collections.Generic;
using AutoMapper;
using SpikeWcf.Domain;
using SpikeWcf.Domain.Northwind;
using SpikeWcf.Dtos;
using SpikeWcf.Dtos.Northwind;

namespace SpikeWcf
{
	static public class AutoMapperConfiguration
	{
		static public void Configure()
		{
			Mapper.Reset();
			//Mapper.Initialize(c=>c.ConstructServicesUsing()); // For IoC container
			DomainToDto();
			DtoToDomain();
			Mapper.AssertConfigurationIsValid();
		}

		static private void DomainToDto()
		{
			Mapper.CreateMap<RootEntity, RootEntityDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => s.Id.ToString()));
			Mapper.CreateMap<ExternalEntity, ExternalEntityRefDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => s.Id.ToString()));
			Mapper.CreateMap<DetailEntity, DetailEntityDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => s.Id.ToString()));

			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<Order, OrderDto>();
		}

		static private void DtoToDomain()
		{
			Mapper.CreateMap<RootEntityDto, RootEntity>()
				.ConstructUsing(s => new RootEntity{ Id = int.Parse(s.StringId) })
				.ForMember(d => d.Id, o => o.Ignore())
				.ForMember(d => d.ExternalEntities, o => o.Ignore())
				.ForMember(d => d.DetailEntities, o => o.Ignore())
				.AfterMap((s, d) => FillCollection(s, d, ss => ss.DetailEntities, dd => dd.DetailEntities));
			Mapper.CreateMap<ExternalEntityRefDto, ExternalEntity>()
				.ConstructUsing(s => new ExternalEntity{ Id = int.Parse(s.StringId) })
				.ForMember(d => d.Id, o => o.Ignore());
			Mapper.CreateMap<DetailEntityDto, DetailEntity>()
				.ConstructUsing(d => new DetailEntity{ Id = int.Parse(d.StringId) })
				.ForMember(d => d.Id, o => o.Ignore());
		}

		static private void FillCollection<TSource, TDestination, TSourceItem, TDestinationItem>(TSource s, TDestination d, Func<TSource, IEnumerable<TSourceItem>> getSourceEnum, Func<TDestination, ICollection<TDestinationItem>> getDestinationColl)
		{
			ICollection<TDestinationItem> collection = getDestinationColl(d);
			collection.Clear();
			foreach(TSourceItem sourceItem in getSourceEnum(s) ?? new TSourceItem[0])
			{
				collection.Add(Mapper.Map<TSourceItem, TDestinationItem>(sourceItem));
			}
		}

		static private void ResolveUsing<TSource>(this IMemberConfigurationExpression<TSource> o, Func<TSource, object> func)
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