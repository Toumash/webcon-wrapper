using FluentAssertions;
using Moq;
using System;
using WebconWrapper.ConfigServices.DAL;
using Xunit;

namespace WebconWrapper.ConfigServices.IntegrationTests.DAL
{
    public class AttributesRepoTests : IDisposable
    {
        private MockRepository mockRepository;

        public AttributesRepoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private AttributesRepo CreateAttributesRepo()
        {
            return new AttributesRepo(""); // TODO
        }

        [Fact]
        public void GetAll_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateAttributesRepo();

            var result = unitUnderTest.GetAll();

            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
