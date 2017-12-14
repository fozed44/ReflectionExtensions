using System;
using Verification;

namespace ReflectionExtensions{
    public class ReflectedType {

        public ReflectedType(Type t) {
            _t = t;
        }

        private Type _t;

        public object Create() {
            Verify.True(_t.IsClass, $"{_t.Name} is not a class.");
            return Activator.CreateInstance(_t);
        }

        public T Create<T>() {
            Verify.True(_t.IsClass, $"{_t.Name} is not a class.");
            Verify.True(typeof(T) == _t, $"{_t.Name} and {typeof(T).Name} are different types.");
            return Activator.CreateInstance<T>();
        }

        public object Create(params object[] @params) {
            Verify.True(_t.IsClass, $"{_t.Name} is not a class.");
            return Activator.CreateInstance(_t, @params);
        }

        public T Create<T>(params object[] @params) {
            Verify.True(_t.IsClass, $"{_t.Name} is not a class.");
            Verify.True(typeof(T) == _t, $"{_t.Name} and {typeof(T).Name} are different types.");
            return (T)Activator.CreateInstance(_t, @params);
        }
    }
}
