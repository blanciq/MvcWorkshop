using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;

namespace MvcWorkshops.Tests
{
    [TestFixture]
    public class AutomapperTests
    {
        [TestFixtureSetUp]
        public void Before()
        {
            Mapper.CreateMap<UserModel, UserViewModel>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => string.Format("{0} {1}", x.Name, x.LastName)));
        }

        [Test]
        public void MappingUserTest()
        {
            var model = new UserModel()
            {
                Name = "Paweł",
                LastName = "Olesiejuk"
            };

            var viewModel = Mapper.Map<UserViewModel>(model);

            Assert.AreEqual(viewModel.FirstName, "Paweł");
            Assert.AreEqual(viewModel.LastName, "Olesiejuk");
            Assert.AreEqual(viewModel.FullName, "Paweł Olesiejuk");

        }
    }

    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }

    public class UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
