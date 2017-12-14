using System;

namespace tReflectionExtensions.TestClasses {

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class TestAttribute : Attribute {

        readonly string _name;

        // This is a positional argument
        public TestAttribute(string name) {
            this._name = name;
        }

        public string Name {
            get { return _name; }
        }
    }
}
