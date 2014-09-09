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
        IQueryable<UserProfile> _userProfilesWithRoles;
        IQueryable<UserProfile> _userProfilesWitouthRoles;

        [TestFixtureSetUp]
        public void StartUp()
        {
            _userProfilesWithRoles = new [] 
            {
                new UserProfile { UserId = 1 },
                new UserProfile { UserId = 2 }
            }.AsQueryable();

            _userProfilesWitouthRoles = new[] 
            {
                new UserProfile 
                { 
                    UserId = 1,  
                    webpages_Roles = new [] 
                    {
                        new RoleModel { RoleId = 1 }
                    }
                },
                new UserProfile
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
            var mock = Substitute.For<IEntitiesRepository<UserProfile>>();
            mock.Get(It.IsAny<Expression<Func<UserProfile, RoleModel>>>()).Returns(_userProfilesWithRoles);

            Func<IEntitiesRepository<UserProfile>> getFakeRepository = () => mock;
            //Subject of Unit Test
            var sut = new UsersService(getFakeRepository);

            var result = sut.GetAll();

            Assert.That(sut.GetAll().Count(), Is.EqualTo(2));
        }
    }
}
