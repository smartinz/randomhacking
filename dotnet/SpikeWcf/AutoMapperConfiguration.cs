using System;
using AutoMapper;
using SpikeWcf.Domain;
using SpikeWcf.Dtos;

namespace SpikeWcf
{
	static public class AutoMapperConfiguration
	{
		static public void Configure()
		{
			Mapper.Reset();
			//Mapper.Initialize(c=>c.ConstructServicesUsing()); // For IoC container
			Mapper.CreateMap<RootEntity, RootEntityDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => s.Id.ToString()));
			Mapper.CreateMap<ExternalEntity, ExternalEntityRefDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => s.Id.ToString()));
			Mapper.CreateMap<DetailEntity, DetailEntityDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => s.Id.ToString()));
			Mapper.AssertConfigurationIsValid();
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