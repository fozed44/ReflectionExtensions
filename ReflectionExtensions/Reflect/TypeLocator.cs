using System;
using System.Collections.Generic;
using AssemblyLocation;
using System.Reflection;
using Verification;
using System.Linq;

namespace ReflectionExtensions {
    public class TypeLocator {

        public IEnumerable<Type> ByAttribute(Type attributeType) {
            Verify.True(attributeType.IsSubclassOf(typeof(Attribute)),
                $"{attributeType.Name} is not a subclass of Attribute."                
            );
            return GetTypesWithAttribute(attributeType);
        }

        public IEnumerable<Type> ByAttribute(Type attributeType, Predicate<Type> where) {
            foreach(var type in ByAttribute(attributeType)) {
                if (where(type))
                    yield return type;
            }
        }

        #region Private

        private IEnumerable<Type> GetTypesWithAttribute(Type attributeType) {
            var locater = new AssemblyLocater();
            foreach(var assembly in locater.LocateAssemblyWithAttributedTypes(attributeType.Name)) {
                foreach(var type in assembly.ExportedTypes) {
                    if (Attribute.IsDefined(type, attributeType))
                        yield return type;
                }
            }
        }
        

        #endregion

    }
}
