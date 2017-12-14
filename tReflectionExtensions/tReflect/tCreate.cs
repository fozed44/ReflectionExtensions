using Microsoft.VisualStudio.TestTools.UnitTesting;

using static ReflectionExtensions.ReflectionExtensions;
using tReflectionExtensions.TestClasses;

namespace tReflectionExtensions.tReflect {

    [TestClass]
    public class tCreate {

        [TestMethod]
        public void tCreate_create() {
            var testObject = Reflect(typeof(Point)).Create();
            Assert.IsNotNull(testObject);
            Assert.AreEqual(typeof(Point), testObject.GetType());
        }

        [TestMethod]
        public void tCreate_createTemplated() {
            var testObject = Reflect(typeof(Point)).Create<Point>();
            Assert.IsNotNull(testObject);
            Assert.AreEqual(typeof(Point), testObject.GetType());
        }

        [TestMethod]
        public void tCreate_createParams() {
            var testObject = Reflect(typeof(Point)).Create(10,20);
            Assert.IsNotNull(testObject);
            Assert.AreEqual(typeof(Point), testObject.GetType());
            Assert.AreEqual(10.0, Reflect(testObject)["X"]);
            Assert.AreEqual(20.0, Reflect(testObject)["Y"]);
        }

        [TestMethod]
        public void tCreate_createParamsTemplated() {
            var testObject = Reflect(typeof(Point)).Create<Point>(10,20);
            Assert.IsNotNull(testObject);
            Assert.AreEqual(typeof(Point), testObject.GetType());
            Assert.AreEqual(10.0, testObject.X);
            Assert.AreEqual(20.0, testObject.Y);
        }

    }
}
