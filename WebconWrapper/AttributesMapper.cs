using System;
using System.Collections.Generic;
using System.Linq;
using WebconProxy;
using WebconWrapper.Exceptions;

namespace WebconWrapper
{
    public static class AttributesMapper
    {
        public static void SetValue(this NewElement element, int id, int value)
            => GetAttributeById<IntegerAttribute>(element, id).Value = value;

        public static void SetValue(this NewElement element, int id, string value)
            => GetAttributeById<TextAttribute>(element, id).Value = value;

        public static void SetValue(this NewElement element, int id, bool value)
            => GetAttributeById<BoolAttribute>(element, id).Value = value;

        public static void SetValue(this NewElement element, int id, DateTime value)
            => GetAttributeById<DateTimeAttribute>(element, id).Value = value;

        public static void SetValue(this NewElement element, int id, decimal value)
            => GetAttributeById<DecimalAttribute>(element, id).Value = value;

        public static void AddComment(this NewElement element, int id, string value)
            => GetAttributeById<CommentAttribute>(element, id).Value.NewComment = value;



        internal static T GetAttributeById<T>(this NewElement element, int id)
            where T : WebconProxy.Attribute
        {
            try
            {
                return GetAttribute<T>(element, (a) => a.Id == id);
            }
            catch (MissingFieldException)
            {
                throw new FieldNotFoundException($"Could not find webcon attribute with id: ({id})");
            }
        }

        internal static T GetAttributeByName<T>(this NewElement element, string fieldName)
            where T : WebconProxy.Attribute
        {
            try
            {
                return GetAttribute<T>(element, (a) => a.FieldName == fieldName);
            }
            catch (MissingFieldException)
            {
                throw new FieldNotFoundException($"Could not find webcon attribute with name \"{fieldName}\"");
            }
        }

        private static T GetAttribute<T>(this NewElement element, Func<WebconProxy.Attribute, bool> selector)
            where T : WebconProxy.Attribute
        {
            var attributes = new List<WebconProxy.Attribute>();
            attributes.AddRange(element.BoolAttributes);
            attributes.AddRange(element.ChooseAttributes);
            attributes.AddRange(element.CommentAttributes);
            attributes.AddRange(element.DateTimeAttributes);
            attributes.AddRange(element.DecimalAttributes);
            attributes.AddRange(element.HyperLinkAttributes);
            attributes.AddRange(element.IntegerAttributes);
            attributes.AddRange(element.PeopleAttributes);
            attributes.AddRange(element.PickerAttributes);
            attributes.AddRange(element.SubElementAttributes);
            attributes.AddRange(element.TextAttributes);
            attributes.AddRange(element.TreeAttributes);
            var att = attributes.FirstOrDefault(selector);

            if (att == null)
                throw new MissingFieldException();

            return att as T;
        }
    }
}
