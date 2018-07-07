using FluentAssertions;
using Moq;
using System;
using WebconProxy;
using WebconWrapper;
using WebconWrapper.Exceptions;
using Xunit;

namespace WebconWrapper.Tests
{
    public class AttributesMapperAttributesFinderTests : IDisposable
    {
        private MockRepository mockRepository;



        public AttributesMapperAttributesFinderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GivenCommentAttributeWithId_WhenSearchingById_ShouldNotThrow()
        {
            NewElement element = AttributesMapperSettersTests.InitializeEmptyNewElement();
            int id = 5;
            var att = new CommentAttribute() { Id = id };
            att.Value = new Comments();
            element.CommentAttributes.Add(att);

            Action a = () => AttributesMapper.GetAttributeById<CommentAttribute>(element, id);
            a.Should().NotThrow<FieldNotFoundException>();
        }

        [Fact]
        public void GivenCommentAttributeWithName_WhenSearchingByName_ShouldNotThrow()
        {
            NewElement element = AttributesMapperSettersTests.InitializeEmptyNewElement();
            string fieldName = "WFD_Comment1";
            var att = new CommentAttribute() { FieldName = fieldName };
            att.Value = new Comments();
            element.CommentAttributes.Add(att);

            Action a = () => AttributesMapper.GetAttributeByName<CommentAttribute>(element, fieldName);
            a.Should().NotThrow<FieldNotFoundException>();
        }
    }
}
