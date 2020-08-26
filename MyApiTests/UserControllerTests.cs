using DataLayer.Interfaces;
using DataLayer.Models;
using MyApi.Controllers;
using AutoMapper;
using Xunit;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using LogicLayer.Responses;
using Moq;
using System.Diagnostics.Contracts;
using System.Linq;
using MyApi.Mapping;

namespace MyApiTests
{
    public class UserControllerTests
    {
       
        private readonly IMapper _mapper;
        public UserControllerTests()
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


            var mock = new Mock<ICrudRepository<User>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var controller = new UserController(mock.Object , _mapper);

            var result = controller.GetAll();

          
            var model = Assert.IsAssignableFrom<IEnumerable<UserShortResponse>>(result);
            Assert.Equal(GetTestUsers().Count(), result.Count());
        }
       

        [Fact]
        public void UserGetAllResultNotNull()
        { 
            var mock = new Mock<ICrudRepository<User>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var controller = new UserController(mock.Object, _mapper);

            var result = controller.GetAll();

            Assert.NotNull(result);
            
            
        }

        [Fact]
        public void UserGetResultNotNull()
        {
            var mock = new Mock<ICrudRepository<User>>();
            mock.Setup(repo => repo.Get(2)).Returns(GetUserTest(1));
            var controller = new UserController(mock.Object, _mapper);

            var result = controller.Get(2);

            Assert.NotNull(result);


        }

       /* [Fact]
        [InlineData(1,1)]
        public void UserGetResult(int IdToFind, int TestMethodId)
        {
            int id;

            var mock = new Mock<ICrudRepository<User>>();
            mock.Setup(repo => repo.Get(IdToFind)).Returns(GetUserTest(TestMethodId));
            var controller = new UserController(mock.Object, _mapper);

            var result = controller.Get(IdToFind);


            Assert.Equal(GetUserTest(TestMethodId), result);
        } */

        private User GetUserTest(int id)
        {
            var users = new List<User>
            {
                new User {  Id=1,Name="Tom",Surname="Blos", Age=35},
                new User { Id=2 ,Name="Alice",Surname="Fos", Age=29},
                new User {  Id=3,Name="Sam",Surname="Whis", Age=32},
                new User {  Id=4,Name="Kate",Surname="Bliss", Age=30}
            };

            ;
            return users.ToArray()[id];
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User {  Name="Tom",Surname="Blos", Age=35},
                new User {  Name="Alice",Surname="Fos", Age=29},
                new User {  Name="Sam",Surname="Whis", Age=32},
                new User {  Name="Kate",Surname="Bliss", Age=30}
            };
            return users;
        }
    }
}
