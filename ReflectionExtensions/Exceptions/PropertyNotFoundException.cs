using System;

namespace ReflectionExtensions.Exceptions {

    [Serializable]
    public class PropertyNotFoundException : Exception {
        public PropertyNotFoundException() { }
        public PropertyNotFoundException(string message) : base(message) { }
        public PropertyNotFoundException(string message, Exception inner) : base(message, inner) { }
        public PropertyNotFoundException(object @object, string propertyName)
            : base($"Type {@object.GetType().Name} does not have a property '{propertyName}'.") { }
        protected PropertyNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
