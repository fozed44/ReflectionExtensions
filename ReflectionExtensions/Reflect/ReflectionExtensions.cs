

using System;

namespace ReflectionExtensions {
    public static class ReflectionExtensions {

        public static ReflectedObject Reflect(object o) {
            return new ReflectedObject(o);
        }

        public static ReflectionHelper Reflect() {
            return new ReflectionHelper();
        }

        public static ReflectedType Reflect(Type type) {
            return new ReflectedType(type);
        }

    }
}
