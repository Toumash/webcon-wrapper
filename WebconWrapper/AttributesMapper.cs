using System;
using System.Collections.Generic;
using System.Linq;
using WebconProxy;

namespace WebconWrapper
{
    public class AttributesMapper
    {
        public void SetValue(NewElement element, int id, int value)
            => GetAttributeById<IntegerAttribute>(element, id).Value = value;

        public void SetValue(NewElement element, int id, string value)
            => GetAttributeById<TextAttribute>(element, id).Value = value;

        public void SetValue(NewElement element, int id, bool value)
            => GetAttributeById<BoolAttribute>(element, id).Value = value;

        public void SetValue(NewElement element, int id, DateTime value)
            => GetAttributeById<DateTimeAttribute>(element, id).Value = value;

        public void SetValue(NewElement element, int id, decimal value)
            => GetAttributeById<DecimalAttribute>(element, id).Value = value;

        public void AddComment(NewElement element, int id, string value)
            => GetAttributeById<CommentAttribute>(element, id).Value.NewComment = value;



        internal T GetAttributeById<T>(NewElement element, int id)
            where T : WebconProxy.Attribute
            => GetAttribute<T>(element, (a) => a.Id == id);

        internal T GetAttributeByName<T>(NewElement element, string fieldName)
            where T : WebconProxy.Attribute
            => GetAttribute<T>(element, (a) => a.FieldName == fieldName);

        private T GetAttribute<T>(NewElement element, Func<WebconProxy.Attribute, bool> selector)
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
            var att = attributes.First(selector);
            return att as T;
        }
    }
}
