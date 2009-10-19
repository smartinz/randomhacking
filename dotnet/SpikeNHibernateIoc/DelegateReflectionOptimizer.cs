using System;
using NHibernate.Bytecode.Lightweight;
using NHibernate.Properties;

namespace SpikeNHibernateIoc
{
	public class DelegateReflectionOptimizer : ReflectionOptimizer
	{
		private readonly Func<object> _createInstanceDelegate;

		public DelegateReflectionOptimizer(Type mappedType, IGetter[] getters, ISetter[] setters, Func<object> createInstance)
			: base(mappedType, getters, setters)
		{
			_createInstanceDelegate = createInstance;
		}

		protected override void ThrowExceptionForNoDefaultCtor(Type type) {}

		public override object CreateInstance()
		{
			return _createInstanceDelegate();
		}
	}
}