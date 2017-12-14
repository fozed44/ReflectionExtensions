using ReflectionExtensions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionExtensions {
    public class ReflectedObject {

        #region Ctor

        public ReflectedObject(object o) {
            _o = o;
        }

        #endregion

        #region Fields

        private object _o;

        #endregion

        #region Properties

        public IEnumerable<PropertyInfo> Properties {
            get { return GetProperties(); }
        }

        public IEnumerable<MethodInfo> Methods {
            get { return GetMethods(); }
        }

        #endregion

        #region Indexer

        public object this[string propertyName] {
            get { return GetPropVal(propertyName); }
            set { SetPropVal(propertyName, value); }
        }

        #endregion

        #region Public

        public PropertyInfo Property(string propertyName) {
            var property = GetProperties().Where(x => x.Name == propertyName).FirstOrDefault();
            if (property == null)
                throw new PropertyNotFoundException(_o, propertyName);
            return property;
        }

        public void SetPropVal(string propertyName, object value) {
            Property(propertyName).SetValue(_o, value);
        }

        public object GetPropVal(string propertyName) {
            return Property(propertyName).GetValue(_o);
        }

        public T GetPropVal<T>(string propertyName) {
            return (T)Property(propertyName).GetValue(_o);
        }

        #endregion

        #region Private

        private IEnumerable<PropertyInfo> GetProperties() {
            foreach (var property in _o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                yield return property;
        }

        private IEnumerable<MethodInfo> GetMethods() {
            foreach (var method in _o.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public))
                yield return method;
        }       

        #endregion
    }
}
