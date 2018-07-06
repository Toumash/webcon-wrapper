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
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int nonExistingId = 15;

            Assert.ThrowsAny<FieldNotFoundException>(() =>
            {
                unitUnderTest.SetValue(element, nonExistingId, 150);
            });
        }


        [Fact]
        public void SetValue_SetsIntegerAttribute()
        {
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new IntegerAttribute() { Id = id };
            element.IntegerAttributes.Add(att);
            int value = 150;

            unitUnderTest.SetValue(element, id, value);

            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsBooleanAttribute()
        {
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new BoolAttribute() { Id = id };
            element.BoolAttributes.Add(att);
            bool value = true;

            unitUnderTest.SetValue(element, id, value);

            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsStringAttribute()
        {
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new TextAttribute() { Id = id };
            element.TextAttributes.Add(att);
            string value = "test string";

            unitUnderTest.SetValue(element, id, value);

            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsDateTimeAttribute()
        {
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new DateTimeAttribute() { Id = id };
            element.DateTimeAttributes.Add(att);
            DateTime value = DateTime.Now;

            unitUnderTest.SetValue(element,id,value);

            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void SetValue_SetsDecimalAttribute()
        {
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new DecimalAttribute() { Id = id };
            element.DecimalAttributes.Add(att);
            decimal value = 15.15m;

            unitUnderTest.SetValue(element,id,value);

            Assert.Equal(value, att.Value);
        }

        [Fact]
        public void AddComment_AddsComment()
        {
            var unitUnderTest = CreateAttributesMapper();
            NewElement element = InitializeEmptyNewElement();
            int id = 15;
            var att = new CommentAttribute() { Id = id };
            att.Value = new Comments();
            element.CommentAttributes.Add(att);
            string value = "test string";

            unitUnderTest.AddComment(element,id,value);

            Assert.Equal(value, att.Value.NewComment);
        }
    }
}
