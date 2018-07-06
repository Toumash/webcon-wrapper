using System;
using System.Collections.Generic;
using System.Text;

namespace WebconWrapper.Exceptions
{

    [Serializable]
    public class FieldNotFoundException : Exception
    {
        public FieldNotFoundException() { }
        public FieldNotFoundException(string message) : base(message) { }
        public FieldNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected FieldNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
