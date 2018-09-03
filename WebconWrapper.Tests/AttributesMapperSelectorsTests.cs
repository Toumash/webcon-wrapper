using FluentAssertions;
using Moq;
using System;
using WebconProxy;
using WebconWrapper;
using WebconWrapper.Exceptions;
using Xunit;

namespace WebconWrapper.Tests
{
    public class AttributesMapperSelectorsTests
    {
        [Fact]
        public void GivenCommentAttributeWithId_WhenSearchingById_ShouldNotThrow()
        {
            NewElement element = AttributesMapperSettersTests.InitializeEmptyNewElement();
            int id = 5;
            var att = new CommentAttribute() { Id = id };
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
            element.CommentAttributes.Add(att);

            Action a = () => AttributesMapper.GetAttributeByName<CommentAttribute>(element, fieldName);
            a.Should().NotThrow<FieldNotFoundException>();
        }

        [Fact]
        public void GivenCommentAttributeWithName_WhenSearchingByName_ShouldBeSameAsTheAddedOne()
        {
            NewElement element = AttributesMapperSettersTests.InitializeEmptyNewElement();
            string fieldName = "WFD_Comment1";
            var att = new CommentAttribute() { FieldName = fieldName };
            element.CommentAttributes.Add(att);

            var foundAttribute = AttributesMapper.GetAttributeByName<CommentAttribute>(element, fieldName);
            foundAttribute.Should().Be(att);
        }

        [Fact]
        public void GivenCommentAttributeWithId_WhenSearchingById_ShouldBeSameAsTheAddedOne()
        {
            NewElement element = AttributesMapperSettersTests.InitializeEmptyNewElement();
            int id = 5;
            var att = new CommentAttribute() { Id = id };
            element.CommentAttributes.Add(att);

            var foundAttribute = AttributesMapper.GetAttributeById<CommentAttribute>(element, id);
            foundAttribute.Should().Be(att);
        }
    }
}

