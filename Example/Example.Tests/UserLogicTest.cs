using System;
using Example.Tests.Mocks;
using Xunit;

namespace Example.Tests
{
    public class UserLogicTest
    {
        private readonly UserLogic _userLogic;
        
        public UserLogicTest()
        {
            _userLogic = new UserLogic(new UserRepository(), new NullPasswordGenerator(), new NullPasswordHasher(), new AesTransformer());
        }
        
        
        [Fact]
        public void TestCreateUser()
        {
            User user = new()
            {
                Email = "info@example.com",
                Secret = "secret"
            };

            bool created = _userLogic.Create(user);
            
            Assert.True(created);
            
            Assert.True(user.Id != Guid.Empty);
            Assert.NotNull(user.Secret);
            Assert.NotEmpty(user.Secret);
            Assert.NotEqual("secret", user.Secret);
            Assert.NotNull(user.Password);
            Assert.NotNull(user.Salt);
            Assert.NotEmpty(user.SecretIv);
            Assert.NotNull(user.SecretKey);
        }

        [Fact]
        public void TestCreateUser_EmailExists_ShouldFail()
        {
            User user = new()
            {
                Email = "exists@example.com",
                Secret = "secret"
            };

            bool created = _userLogic.Create(user);
            
            Assert.False(created);
        }

        [Fact]
        public void TestGetUserId()
        {
            User user = _userLogic.Get(Guid.Parse("B243192F-372D-4261-8107-C05A0A983961"));
            
            Assert.NotNull(user);
            
            Assert.Null(user.Password);
            Assert.Null(user.Salt);
        }

        [Fact]
        public void TestGetUserEmail()
        {
            User user = _userLogic.Get("exists@example.com");
            
            Assert.NotNull(user);
            
            Assert.Null(user.Password);
            Assert.Null(user.Salt);
        }
    }
}