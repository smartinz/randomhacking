using System;
using AutoMapper;
using ExtMvc.Domain;
using Microsoft.Practices.ServiceLocation;
using Nexida.Infrastructure;

namespace ExtMvc.Dtos
{
	public static class MappingEngineBuilder
	{
		public static IMappingEngine Build()
		{
			Mapper.Reset();
			DomainToDto();
			DtoToDomain();
			Mapper.AssertConfigurationIsValid();
			return Mapper.Engine;
		}

		private static void DomainToDto()
		{
			IServiceLocator sl = ServiceLocator.Current;

			Mapper.CreateMap<Category, CategoryDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Category>>().ToString(s)));
			Mapper.CreateMap<Category, CategoryReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Category>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<CustomerDemographic, CustomerDemographicDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<CustomerDemographic>>().ToString(s)));
			Mapper.CreateMap<CustomerDemographic, CustomerDemographicReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<CustomerDemographic>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Customer, CustomerDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Customer>>().ToString(s)));
			Mapper.CreateMap<Customer, CustomerReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Customer>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Employee, EmployeeDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Employee>>().ToString(s)));
			Mapper.CreateMap<Employee, EmployeeReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Employee>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<OrderDetail, OrderDetailDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<OrderDetail>>().ToString(s)));
			Mapper.CreateMap<OrderDetail, OrderDetailReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<OrderDetail>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Order, OrderDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Order>>().ToString(s)));
			Mapper.CreateMap<Order, OrderReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Order>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Product, ProductDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Product>>().ToString(s)));
			Mapper.CreateMap<Product, ProductReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Product>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Region, RegionDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Region>>().ToString(s)));
			Mapper.CreateMap<Region, RegionReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Region>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Shipper, ShipperDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Shipper>>().ToString(s)));
			Mapper.CreateMap<Shipper, ShipperReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Shipper>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Supplier, SupplierDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Supplier>>().ToString(s)));
			Mapper.CreateMap<Supplier, SupplierReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Supplier>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Sysdiagram, SysdiagramDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Sysdiagram>>().ToString(s)));
			Mapper.CreateMap<Sysdiagram, SysdiagramReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Sysdiagram>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));

			Mapper.CreateMap<Territory, TerritoryDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Territory>>().ToString(s)));
			Mapper.CreateMap<Territory, TerritoryReferenceDto>()
				.ForMember(d => d.StringId, o => o.ResolveUsing(s => sl.GetInstance<IStringConverter<Territory>>().ToString(s)))
				.ForMember(d => d.Description, o => o.ResolveUsing(s => s.ToString()));
		}

		private static void DtoToDomain()
		{
			IServiceLocator sl = ServiceLocator.Current;

			Mapper.CreateMap<CategoryDto, Category>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Category>>().FromString(s.StringId))
				.ForMember(d => d.CategoryId, o => o.Ignore())
				.ForMember(d => d.Picture, o => o.Ignore())
				.ForMember(d => d.Products, o => o.Ignore())
				;
			Mapper.CreateMap<CategoryReferenceDto, Category>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Category>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<CustomerDemographicDto, CustomerDemographic>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<CustomerDemographic>>().FromString(s.StringId))
				.ForMember(d => d.CustomerTypeId, o => o.Ignore())
				.ForMember(d => d.Customers, o => o.Ignore())
				;
			Mapper.CreateMap<CustomerDemographicReferenceDto, CustomerDemographic>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<CustomerDemographic>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<CustomerDto, Customer>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Customer>>().FromString(s.StringId))
				.ForMember(d => d.CustomerId, o => o.Ignore())
				.ForMember(d => d.Customerdemographics, o => o.Ignore())
				.ForMember(d => d.Orders, o => o.Ignore())
				;
			Mapper.CreateMap<CustomerReferenceDto, Customer>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Customer>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<EmployeeDto, Employee>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Employee>>().FromString(s.StringId))
				.ForMember(d => d.EmployeeId, o => o.Ignore())
				.ForMember(d => d.Photo, o => o.Ignore())
				.ForMember(d => d.Employee_1, o => o.Ignore())
				.ForMember(d => d.Employees, o => o.Ignore())
				.ForMember(d => d.Territories, o => o.Ignore())
				.ForMember(d => d.Orders, o => o.Ignore())
				;
			Mapper.CreateMap<EmployeeReferenceDto, Employee>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Employee>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<OrderDetailDto, OrderDetail>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<OrderDetail>>().FromString(s.StringId))
				.ForMember(d => d.OrderId, o => o.Ignore())
				.ForMember(d => d.ProductId, o => o.Ignore())
				;
			Mapper.CreateMap<OrderDetailReferenceDto, OrderDetail>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<OrderDetail>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<OrderDto, Order>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Order>>().FromString(s.StringId))
				.ForMember(d => d.OrderId, o => o.Ignore())
				.ForMember(d => d.Shipper, o => o.Ignore())
				;
			Mapper.CreateMap<OrderReferenceDto, Order>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Order>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<ProductDto, Product>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Product>>().FromString(s.StringId))
				.ForMember(d => d.ProductId, o => o.Ignore())
				.ForMember(d => d.Supplier, o => o.Ignore())
				;
			Mapper.CreateMap<ProductReferenceDto, Product>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Product>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<RegionDto, Region>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Region>>().FromString(s.StringId))
				.ForMember(d => d.RegionId, o => o.Ignore())
				.ForMember(d => d.Territories, o => o.Ignore())
				;
			Mapper.CreateMap<RegionReferenceDto, Region>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Region>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<ShipperDto, Shipper>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Shipper>>().FromString(s.StringId))
				.ForMember(d => d.ShipperId, o => o.Ignore())
				.ForMember(d => d.Orders, o => o.Ignore())
				;
			Mapper.CreateMap<ShipperReferenceDto, Shipper>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Shipper>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<SupplierDto, Supplier>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Supplier>>().FromString(s.StringId))
				.ForMember(d => d.SupplierId, o => o.Ignore())
				.ForMember(d => d.Products, o => o.Ignore())
				;
			Mapper.CreateMap<SupplierReferenceDto, Supplier>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Supplier>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<SysdiagramDto, Sysdiagram>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Sysdiagram>>().FromString(s.StringId))
				.ForMember(d => d.DiagramId, o => o.Ignore())
				.ForMember(d => d.Definition, o => o.Ignore())
				;
			Mapper.CreateMap<SysdiagramReferenceDto, Sysdiagram>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Sysdiagram>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());

			Mapper.CreateMap<TerritoryDto, Territory>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Territory>>().FromString(s.StringId))
				.ForMember(d => d.TerritoryId, o => o.Ignore())
				.ForMember(d => d.Employees, o => o.Ignore())
				;
			Mapper.CreateMap<TerritoryReferenceDto, Territory>()
				.ConstructUsing(s => sl.GetInstance<IStringConverter<Territory>>().FromString(s.StringId))
				.ForAllMembers(o => o.Ignore());
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