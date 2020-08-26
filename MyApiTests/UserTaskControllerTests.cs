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
   public class UserTaskControllerTests
    {
        private readonly IMapper _mapper;
        public UserTaskControllerTests()
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


            var mock = new Mock<ICrudRepository<UserTask>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUserTasks());
            var controller = new UserTaskController(mock.Object, _mapper);

            var result = controller.GetAll();


            var model = Assert.IsAssignableFrom<IEnumerable<UserTaskResponse>>(result);
            Assert.Equal(GetTestUserTasks().Count(), result.Count());
        }

       

        [Fact]
        public void UserGetAllResultNotNull()
        {
            var mock = new Mock<ICrudRepository<UserTask>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUserTasks());
            var controller = new UserTaskController(mock.Object, _mapper);

            var result = controller.GetAll();

            Assert.NotNull(result);


        }

        private List<UserTask> GetTestUserTasks()
        {
            var permissions = new List<UserTask>
            {
                new UserTask {  TaskDescription = "first"},
                new UserTask {  TaskDescription = "second"},
                new UserTask {  TaskDescription = "third"},
                new UserTask {  TaskDescription = "fourth"}
            };
            return permissions;
        }
    }
}
