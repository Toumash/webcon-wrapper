using Moq;
using System;
using WebconProxy;
using WebconWrapper;
using Xunit;
using System.Collections.Generic;
using WebconWrapper.Exceptions;

namespace WebconWrapper.Tests
{
    public class AttributesMapperSettersTests : IDisposable
    {
        private MockRepository mockRepository;

        public AttributesMapperSettersTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private NewElement InitializeEmptyNewElement(NewElement element = null)
        {
            if (element == null)
                element = new NewElement();

            element.BoolAttributes = new List<BoolAttribute>();
            element.ChooseAttributes = new List<ChooseAttribute>();
            element.DateTimeAttributes = new List<DateTimeAttribute>();
            element.DecimalAttributes = new List<DecimalAttribute>();
            element.HyperLinkAttributes = new List<HyperLinkAttribute>();
            element.IntegerAttributes = new List<IntegerAttribute>();
            element.PeopleAttributes = new List<PeopleAttribute>();
            element.PickerAttributes = new List<PickerAttribute>();
            element.SubElementAttributes = new List<SubelementAttribute>();
            element.TextAttributes = new List<TextAttribute>();
            element.TreeAttributes = new List<TreeAttribute>();
            element.CommentAttributes = new List<CommentAttribute>();
            return element;
        }

        private AttributesMapper CreateAttributesMapper()
        {
            return new AttributesMapper();
        }


        [Fact]
        public void SetValue_WhenNoFieldWithGivenId_ShouldThrowFieldNotFoundException()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int nonExistingId = 15;
            int whateverValue = 150;

            Assert.ThrowsAny<FieldNotFoundException>(() =>
            {
                // Act
                unitUnderTest.SetValue(
                    element,
                    nonExistingId,
                    whateverValue);
            });
        }


        [Fact]
        public void SetValue_SetsIntegerAttribute()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new IntegerAttribute() { Id = id };
            element.IntegerAttributes.Add(att);
            int value = 150;

            // Act
            unitUnderTest.SetValue(
                element,
                id,
                value);

            // Assert
            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsBooleanAttribute()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new BoolAttribute() { Id = id };
            element.BoolAttributes.Add(att);
            bool value = true;

            // Act
            unitUnderTest.SetValue(
                element,
                id,
                value);

            // Assert
            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsStringAttribute()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new TextAttribute() { Id = id };
            element.TextAttributes.Add(att);
            string value = "test string";

            // Act
            unitUnderTest.SetValue(
                element,
                id,
                value);

            // Assert
            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsDateTimeAttribute()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new DateTimeAttribute() { Id = id };
            element.DateTimeAttributes.Add(att);
            DateTime value = DateTime.Now;

            // Act
            unitUnderTest.SetValue(
                element,
                id,
                value);

            // Assert
            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsDecimalAttribute()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new DecimalAttribute() { Id = id };
            element.DecimalAttributes.Add(att);
            decimal value = 15.15m;

            // Act
            unitUnderTest.SetValue(
                element,
                id,
                value);

            // Assert
            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void AddComment_AddsComment()
        {
            // Arrange
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new CommentAttribute() { Id = id };
            att.Value = new Comments();
            element.CommentAttributes.Add(att);
            string value = "test string";

            // Act
            unitUnderTest.AddComment(
                element,
                id,
                value);

            // Assert
            Assert.Equal(value, att.Value.NewComment);
        }
    }
}
