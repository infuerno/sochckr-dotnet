using System;
using Nancy;
using Nancy.Testing;
using Xunit;
using Moq;

namespace Sochckr.PostsChecker.Tests
{
    public class PostsCheckerModuleTests
    {
       [Fact]
        public void GetReturnsStatusOkWhenRouteExists()
       {
           var mockSeClient = new Mock<IStackExchangeClient>();
           mockSeClient.Setup(m => m.GetPosts(null, DateTime.Now, null)).Returns(null);
           
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, 
                defaults: to => to.Accept("application/json"),
                with => with.Dependency<IStackExchangeClient>(mockSeClient.Object));

            // When
            var result = browser.Get("/check/posts/sitename", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);

        }

        [Fact]
        public void GetReturnsStatusNotFoundWhenNoRouteExists()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, defaults: to => to.Accept("application/json"));

            // When
            var result = browser.Get("/donotexist", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.NotFound, result.Result.StatusCode);
        }

        [Fact]
        public void GetReturnsShoppingCartWhenUserExists()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, defaults: to => to.Accept("application/json"));

            // When
            var result = browser.Get("/shoppingcart/1", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.Equal("json", result.Result.Body.ToString());
        }

        [Fact]
        public void GetReturnsNotFoundWhenNoUserExists()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, defaults: to => to.Accept("application/json"));

            // When
            var result = browser.Get("/shoppingcart/123", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.NotFound, result.Result.StatusCode);
        }    }
}