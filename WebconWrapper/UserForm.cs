using System;
using System.Collections.Generic;
using System.Text;
using WebconProxy;

namespace WebconWrapper
{
    public class UserForm : Element
    {

        public int xd = 5;

        private void Text(int id)
            => Attributes.Add(new TextAttribute() { Id = id });

        public List<WebconProxy.Attribute> Attributes { get; }

        public void Send()
        {
        }
    }
}
