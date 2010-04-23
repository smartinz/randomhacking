using System;
using System.Globalization;
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

		[Test]
		public void FromDtoToDomain()
		{
			var src = new RootEntityDto{
				StringId = "1",
				Name = "root entity",
				ExternalEntity = new ExternalEntityRefDto{
					StringId = "2",
					Description = "external entity",
				},
				DetailEntities = new[]{
					new DetailEntityDto{ StringId = "3", Description = "detail entity coll 1" },
					new DetailEntityDto{ StringId = "4", Description = "detail entity coll 2" },
				},
			};

			var dest = Mapper.Map<RootEntityDto, RootEntity>(src);

			Assert.That(dest.Id, Is.EqualTo(1));
			Assert.That(dest.Name, Is.EqualTo("root entity"));
			Assert.That(dest.ExternalEntities, Is.Not.Null);
			Assert.That(dest.DetailEntities.Count(), Is.EqualTo(2));
		}

		[Test]
		[Ignore("Test for IsoDateTimeTypeConverter")]
		public void DateTimeMapping()
		{
			Assert.That(Mapper.Map<DateTime, string>(new DateTime(2010, 4, 23, 13, 37, 0, 141, DateTimeKind.Unspecified)), Is.EqualTo("2010-04-23T13:37:00.1410000"));
			Assert.That(Mapper.Map<DateTime, string>(new DateTime(2010, 4, 23, 13, 37, 0, 141, DateTimeKind.Utc)), Is.EqualTo("2010-04-23T13:37:00.1410000Z"));
			Assert.That(Mapper.Map<DateTime, string>(new DateTime(2010, 4, 23, 13, 37, 0, 141, DateTimeKind.Local)), Is.EqualTo("2010-04-23T13:37:00.1410000+02:00"));
			Assert.That(Mapper.Map<string, DateTime>("2010-04-23T14:28:30.141"), Is.EqualTo(new DateTime(2010, 4, 23, 14, 28, 30, 141)));
			Assert.That(Mapper.Map<string, DateTime>("2010-04-23T14:28:30.141+02:00").Kind, Is.EqualTo(DateTimeKind.Local));
			Assert.That(Mapper.Map<string, DateTime>("2010-04-23T14:28:30.141").Kind, Is.EqualTo(DateTimeKind.Unspecified));
			Assert.That(Mapper.Map<string, DateTime>("2010-04-23T14:28:30.141Z").Kind, Is.EqualTo(DateTimeKind.Utc));
		}
	}
}