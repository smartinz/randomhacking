using AutoMapper;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ExtMvc.Controllers;
using MvcContrib.Castle;
using SpikeWcf;

namespace ExtMvc.Infrastructure
{
	public class PresentationWindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
		}

	}
}