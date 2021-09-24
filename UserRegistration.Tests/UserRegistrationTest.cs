using NUnit.Framework;
using Moq;
using UserBusinessLayer;
using System;

namespace UserRegistration.Tests
{
    [TestFixture]
    public class Tests
    {
       
        private Mock<IUserParams> mockObject_ClientId_1;
        private Mock<IUserParams> mockObject_ClientId_2;
        private Mock<IUserParams> mockObject_ClientId_3;
        [SetUp]
        public void Setup()
        {
            mockObject_ClientId_1 = new Mock<IUserParams>();
            mockObject_ClientId_1.Setup(x => x.FirstName).Returns("John");
            mockObject_ClientId_1.Setup(x => x.SurName).Returns("Deo");
            mockObject_ClientId_1.Setup(x => x.DateOfBirth).Returns(Convert.ToDateTime("07-01-1982"));
            mockObject_ClientId_1.Setup(x => x.Email).Returns("test@test.com");
            mockObject_ClientId_1.Setup(x => x.ClientId).Returns(1);

            mockObject_ClientId_2 = new Mock<IUserParams>();
            mockObject_ClientId_2.Setup(x => x.FirstName).Returns("Sally");
            mockObject_ClientId_2.Setup(x => x.SurName).Returns("McSally");
            mockObject_ClientId_2.Setup(x => x.DateOfBirth).Returns(Convert.ToDateTime("07-01-1952"));
            mockObject_ClientId_2.Setup(x => x.Email).Returns("test2@test.com");
            mockObject_ClientId_2.Setup(x => x.ClientId).Returns(2);

            mockObject_ClientId_3 = new Mock<IUserParams>();
            mockObject_ClientId_3.Setup(x => x.FirstName).Returns("John Q.");
            mockObject_ClientId_3.Setup(x => x.SurName).Returns("Public");
            mockObject_ClientId_3.Setup(x => x.DateOfBirth).Returns(Convert.ToDateTime("07-01-1965"));
            mockObject_ClientId_3.Setup(x => x.Email).Returns("test3@test.com");
            mockObject_ClientId_3.Setup(x => x.ClientId).Returns(3);

        }
        [Test]
        public void GetUser_Positive_ClientId_01()
        {
            //arrange
            var userBusinessObject = new UserService();
          //Act
            var result = userBusinessObject.GetUser(mockObject_ClientId_1.Object);
            //Assert
            Assert.AreEqual(result.CreditLimit, 1000);
        }
        [Test]
        public void GetUser_Positive_ClientId_02()
        {
            //arrange
            var userBusinessObject = new UserService();
            //Act
            var result = userBusinessObject.GetUser(mockObject_ClientId_2.Object);
            //Assert
            Assert.AreEqual(result.CreditLimit, 1500);
        }
        [Test]
        public void GetUser_Positive_ClientId_03()
        {
            //arrange
            var userBusinessObject = new UserService();
            //Act
            var result = userBusinessObject.GetUser(mockObject_ClientId_3.Object);
            //Assert
            Assert.NotNull(result.CreditLimit);
        }
    }
}