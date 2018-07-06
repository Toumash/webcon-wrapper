using FluentAssertions;
using Moq;
using System;
using System.Configuration;
using System.Threading.Tasks;
using WebconProxy;
using WebconWrapper;
using Xunit;

namespace WebconWrapper.IntegrationTests
{
    public class WebconClientConnectionTests : IDisposable
    {
        private MockRepository mockRepository;
        private Mock<BPSWebservice> mockBPSWebservice;

        public WebconClientConnectionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockBPSWebservice = this.mockRepository.Create<BPSWebservice>();
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private WebconClient CreateWebconClient()
        {
            var username = GetConfigString(ConfigEntries.WebconUsername);
            var password = GetConfigString(ConfigEntries.WebconPassword);
            var url = GetConfigString(ConfigEntries.WebconUrl);
            return WebconClient.WithPassword(url, username, password);
        }

        private string GetConfigString(string key)
            => ConfigurationManager.AppSettings[key];

        [InlineData(ConfigEntries.WebconUsername)]
        [InlineData(ConfigEntries.WebconPassword)]
        [InlineData(ConfigEntries.WebconUrl)]
        [Theory]
        public void WebconCredentialsShouldBeSet(string key)
        {
            var configEntry = GetConfigString(key);
            configEntry.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void WhenGettingNewWebconElement_DoesntThrow()
        {
            var unitUnderTest = CreateWebconClient();

            Func<Task> xd = async () =>
                await unitUnderTest.NewWorkflowAsync(
                    wfId: int.Parse(GetConfigString(TestConfigEntries.TestWfId)),
                    formId: int.Parse(GetConfigString(TestConfigEntries.TestFormId))
                );
            xd.Should().NotThrow();
        }
    }
}
