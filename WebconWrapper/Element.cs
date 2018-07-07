using System;
using System.Collections.Generic;
using System.Text;
using WebconProxy;

namespace WebconWrapper
{
    public class Element
    {
        private readonly NewElement _element;

        internal NewElement SourceElement { get; }


        public Element()
        {
            _element = new NewElement();
        }

        internal Element(NewElement element)
        {
            _element = element;
        }

        public void SetValue(int id, int value)
            => _element.SetValue(id, value);

        public void SetValue(int id, string value)
            => _element.SetValue(id, value);

        public void SetValue(int id, bool value)
            => _element.SetValue(id, value);

        public void SetValue(int id, DateTime value)
            => _element.SetValue(id, value);

        public void SetValue(int id, decimal value)
            => _element.SetValue(id, value);

        public void AddComment(int id, string value)
            => _element.AddComment(id, value);
    }
}
