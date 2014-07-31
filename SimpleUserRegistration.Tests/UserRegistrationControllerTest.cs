using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleUserRegistration.Business;
using Rhino.Mocks;
using SimpleUserRegistration.UI.Controllers;
using SimpleUserRegistration.UI.Models;
using System.Collections.Generic;
using SimpleUserRegistration.Data.Repository;
using SimpleUserRegistration.Data.DataEntities;

namespace SimpleUserRegistration.Tests
{
    [TestClass]
    public class UserRegistrationControllerTest
    {
        private IUserService mockUserService;
        private IUserRepository mockUserRepository;

        [TestInitialize]
        public void Initialize()
	    {
            mockUserService = MockRepository.GenerateMock<IUserService>();
            mockUserRepository = MockRepository.GenerateMock<IUserRepository>();
	    }
        
         
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            UserEntity user1 = new UserEntity()
            {
                Id = 1,
                Name = "User1",
                EmailAddress = "user1@email.com",
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                Postcode = "EC1 111"
            };
            UserEntity user2 = new UserEntity()
            {
                Id = 2,
                Name = "User2",
                EmailAddress = "user2@email.com",
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                Postcode = "EC1 111"
            };
  
            var controller = new UserRegistrationController();
            mockUserRepository.Expect(x => x.GetUsers()).Return(new List<UserEntity> {user1, user2});
            // Act
            var response = controller.Get();

            // Assert          
            Assert.AreEqual(response.Count(), 2);
            mockUserService.AssertWasCalled(x => x.GetUsers());
            mockUserRepository.AssertWasCalled(x => x.GetUsers());
        }
    }
}

