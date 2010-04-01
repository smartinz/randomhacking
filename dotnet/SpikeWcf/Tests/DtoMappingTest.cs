using AutoMapper;
using NUnit.Framework;
using SpikeWcf.Domain;
using SpikeWcf.Dtos;
using System.Linq;

namespace SpikeWcf.Tests
{
	[TestFixture]
	public class DtoMappingTest
	{
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			AutoMapperConfiguration.Configure();
		}

		[Test]
		public void FromDomainToDto()
		{
			var src = new RootEntity{
				Id = 1,
				Name = "root entity",
				ExternalEntity = new ExternalEntity{
					Id = 2,
					Description = "external entity"
				}
			};
			src.ExternalEntities.Add(new ExternalEntity{ Id = 3, Description = "external entity coll 1" });
			src.ExternalEntities.Add(new ExternalEntity{ Id = 4, Description = "external entity coll 2" });
			src.DetailEntities.Add(new DetailEntity{ Id = 5, Description = "detail entity coll 1" });
			src.DetailEntities.Add(new DetailEntity{ Id = 6, Description = "detail entity coll 2" });

			RootEntityDto dest = Mapper.Map<RootEntity, RootEntityDto>(src);

			Assert.That(dest.StringId, Is.EqualTo(src.Id.ToString()));
			Assert.That(dest.Name, Is.EqualTo(src.Name));
			Assert.That(dest.ExternalEntity.StringId, Is.EqualTo(src.ExternalEntity.Id.ToString()));
			Assert.That(dest.ExternalEntity.Description, Is.EqualTo(src.ExternalEntity.Description));
			Assert.That(dest.DetailEntities.Count(), Is.EqualTo(src.DetailEntities.Count()));
			Assert.That(dest.DetailEntities.First().StringId, Is.EqualTo(src.DetailEntities.First().Id.ToString()));
		}
	}
}