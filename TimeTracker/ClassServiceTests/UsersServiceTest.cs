using System;
using NSubstitute;
using NUnit.Framework;
using TimeTracker.Model;
using TimeTracker.Repository;
using TimeTracker.ClassService;

namespace ClassServiceTests
{
    [TestFixture]
    public class UsersServiceTest
    {
        private IUsersService _usersService;
        private IEntitiesRepository<UserProfile> _fakeRepo;

        [TestFixtureSetUp]
        public void StartUp()
        {
            _fakeRepo = Substitute.For<IEntitiesRepository<UserProfile>>();
            Func<IEntitiesRepository<UserProfile>> fakeGetRepository = () => _fakeRepo;

            _usersService = new UsersService(fakeGetRepository);
        }

        [Test]
        public void IsReturningUserByIdIfUserExist()
        {
        }
    }
}
