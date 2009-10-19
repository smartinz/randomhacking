using System;
using System.Collections.Generic;
using NHibernate.Bytecode;
using NHibernate.Properties;

namespace SpikeNHibernateIoc
{
	public class CustomCreateInstanceByteCodeProvider : Dictionary<Type, Func<object>>, IBytecodeProvider, IInjectableCollectionTypeFactoryClass, IInjectableProxyFactoryFactory
	{
		private readonly IBytecodeProvider _bytecodeProvider;
		private readonly IInjectableCollectionTypeFactoryClass _injectableCollectionTypeFactoryClass;
		private readonly IInjectableProxyFactoryFactory _injectableProxyFactoryFactory;

		public CustomCreateInstanceByteCodeProvider()
		{
			_bytecodeProvider = NHibernate.Cfg.Environment.BytecodeProvider;
			_injectableCollectionTypeFactoryClass = (IInjectableCollectionTypeFactoryClass)NHibernate.Cfg.Environment.BytecodeProvider;
			_injectableProxyFactoryFactory = (IInjectableProxyFactoryFactory)NHibernate.Cfg.Environment.BytecodeProvider;
		}

		public IReflectionOptimizer GetReflectionOptimizer(Type clazz, IGetter[] getters, ISetter[] setters)
		{
			return ContainsKey(clazz) ? new DelegateReflectionOptimizer(clazz, getters, setters, base[clazz]) : _bytecodeProvider.GetReflectionOptimizer(clazz, getters, setters);
		}

		public IProxyFactoryFactory ProxyFactoryFactory
		{
			get { return _bytecodeProvider.ProxyFactoryFactory; }
		}

		public IObjectsFactory ObjectsFactory
		{
			get { return _bytecodeProvider.ObjectsFactory; }
		}

		public ICollectionTypeFactory CollectionTypeFactory
		{
			get { return _bytecodeProvider.CollectionTypeFactory; }
		}

		public void SetCollectionTypeFactoryClass(string typeAssemblyQualifiedName)
		{
			_injectableCollectionTypeFactoryClass.SetCollectionTypeFactoryClass(typeAssemblyQualifiedName);
		}

		public void SetCollectionTypeFactoryClass(Type type)
		{
			_injectableCollectionTypeFactoryClass.SetCollectionTypeFactoryClass(type);
		}

		public void SetProxyFactoryFactory(string typeName)
		{
			_injectableProxyFactoryFactory.SetProxyFactoryFactory(typeName);
		}
	}
}