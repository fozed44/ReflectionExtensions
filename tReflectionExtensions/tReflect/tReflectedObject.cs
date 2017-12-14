using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionExtensions;
using ReflectionExtensions.Exceptions;
using System;
using System.Linq;
using tReflectionExtensions.TestClasses;
using static ReflectionExtensions.ReflectionExtensions;

namespace tReflectionExtensions.tReflect {

    [TestClass]
    public class tReflectedObject {

        [TestMethod]
        public void tProperties() {
            var testObject = new DateTime();
            var properties = Reflect(testObject).Properties;

            Assert.IsNotNull(properties);
            Assert.IsTrue(properties.FirstOrDefault(x => x.Name == "Day") != null);
        }

        [TestMethod]
        public void tMethods() {
            var testObject = new DateTime();
            var methods = Reflect(testObject).Methods;

            Assert.IsNotNull(methods);
            Assert.IsTrue(methods.FirstOrDefault(x => x.Name == "AddHours") != null);
        }

        [TestMethod]
        public void tIndexer_GetPropertyValue() {
            var testObject = new DateTime( 2000, 12, 12);
            var day = (int)Reflect(testObject)["Day"];

            Assert.AreEqual(12, day);
        }

        [TestMethod]
        public void tIndexer_SetPropertyValue() {
            var testObject = new Point();            
            Reflect(testObject)["X"] = 11;

            Assert.AreEqual(11, testObject.X);
        }

        [TestMethod]
        public void tSetPropVal() {
            var testObject = new Point();
            Reflect(testObject).SetPropVal("X", 11);

            Assert.AreEqual(11, testObject.X);
        }

        [TestMethod]
        public void tGetPropVal() {
            var testObject = new Point();
            testObject.X = 12;
            var testValue = Reflect(testObject).GetPropVal("X");

            Assert.AreEqual(12, (double)testValue);
        }

        public void tGetPropVal_Generic() {
            var testObject = new Point();
            testObject.X = 12;
            var testValue = Reflect(testObject).GetPropVal<double>("X");
            Assert.AreEqual(12, testValue);
        }

        // Trying to get/set a property that does not exist throws a PropertyNotFoundException.
        [TestMethod]
        public void tIndexer_PropertyNotFoundException() {
            var testObject = new Point();
            try {
                Reflect(testObject)["Z"] = 11;
            } catch (Exception e) {
                Assert.AreEqual(typeof(PropertyNotFoundException), e.GetType());
            }
        }
    }
}
