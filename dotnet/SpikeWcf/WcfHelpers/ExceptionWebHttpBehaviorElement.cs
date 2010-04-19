using System;
using System.ServiceModel.Configuration;

namespace SpikeWcf.WcfHelpers
{
    public class ExceptionWebHttpBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ExceptionWebHttpBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ExceptionWebHttpBehavior();
        }
    }
}