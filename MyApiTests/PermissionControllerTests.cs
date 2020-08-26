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
   public class PermissionControllerTests
    {
        private readonly IMapper _mapper;
        public PermissionControllerTests()
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


            var mock = new Mock<ICrudRepository<Permission>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestPermissions());
            var controller = new PermissionController(mock.Object, _mapper);

            var result = controller.GetAll();


            var model = Assert.IsAssignableFrom<IEnumerable<PermissionResponse>>(result);
            Assert.Equal(GetTestPermissions().Count(), result.Count());
        }
       

        [Fact]
        public void UserGetAllResultNotNull()
        {
            var mock = new Mock<ICrudRepository<Permission>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestPermissions());
            var controller = new PermissionController(mock.Object, _mapper);

            var result = controller.GetAll();

            Assert.NotNull(result);


        }
        private List<Permission> GetTestPermissions()
        {
            var permissions = new List<Permission>
            {
                new Permission {  Name="Tom",Description="Blos"},
                new Permission {  Name="Alice",Description="Fos"},
                new Permission {  Name="Sam",Description="Whis"},
                new Permission {  Name="Kate",Description="Bliss",}
            };
            return permissions;
        }
    }
}
