using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Moq;
using TimeTracker.Model;
using TimeTracker.Repository;
using TimeTracker.ClassService;
using System.Linq.Expressions;

namespace ClassServiceTests
{
    [TestFixture]
    public class UsersServiceTest
    {
        IQueryable<UserModel> _userProfilesWithRoles;
        IQueryable<UserModel> _userProfilesWitouthRoles;

        [TestFixtureSetUp]
        public void StartUp()
        {
            _userProfilesWithRoles = new [] 
            {
                new UserModel { UserId = 1 },
                new UserModel { UserId = 2 }
            }.AsQueryable();

            _userProfilesWitouthRoles = new[] 
            {
                new UserModel 
                { 
                    UserId = 1,  
                    webpages_Roles = new [] 
                    {
                        new RoleModel { RoleId = 1 }
                    }
                },
                new UserModel
                { 
                    UserId = 2,  
                    webpages_Roles = new [] 
                    {
                        new RoleModel { RoleId = 2 }
                    }
                }
            }.AsQueryable();
        }

        [Test]
        public void IsReturningUserByIdIfUserExist()
        {
            var mock = Substitute.For<IEntitiesRepository<UserModel>>();
            mock.Get(It.IsAny<Expression<Func<UserModel, RoleModel>>>()).Returns(_userProfilesWithRoles);

            Func<IEntitiesRepository<UserModel>> getFakeRepository = () => mock;
            //Subject of Unit Test
            var sut = new UsersService(getFakeRepository);

            var result = sut.GetAll();

            Assert.That(sut.GetAll().Count(), Is.EqualTo(2));
        }
    }
}
