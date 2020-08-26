using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Responses;
using Moq;
using MyApi.Controllers;
using MyApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MyApiTests
{
    public class OfficeControllerTests
    {

        private readonly IMapper _mapper;
        public OfficeControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Fact]
        public void UserGetAllResult()
        {


            var mock = new Mock<ICrudRepository<Office>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestOffices());
            var controller = new OfficeController(mock.Object, _mapper);

            var result = controller.GetAll();


            var model = Assert.IsAssignableFrom<IEnumerable<OfficeResponse>>(result);
            Assert.Equal(GetTestOffices().Count(), result.Count());
        }
      

        [Fact]
        public void UserGetAllResultNotNull()
        {
            var mock = new Mock<ICrudRepository<Office>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestOffices());
            var controller = new OfficeController(mock.Object, _mapper);

            var result = controller.GetAll();

            Assert.NotNull(result);

        }

        private List<Office> GetTestOffices()
        {
            var offices = new List<Office>
            {
                new Office {  Name="Office1"},
                new Office {  Name="Soffice"},
                new Office {  Name="loffice"},
                new Office {  Name="poffice"}
            };
            return offices;
        }

    }
}
