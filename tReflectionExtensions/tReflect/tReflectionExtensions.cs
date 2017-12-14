using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionExtensions;

using static ReflectionExtensions.ReflectionExtensions;

namespace tReflectionExtensions.tReflect {

    [TestClass]
    public class tReflectionExtensions {

        [TestMethod]
        public void tReflect() {
            var test = "";
            var reflectedObject = Reflect(test);

            Assert.IsNotNull(reflectedObject);
            Assert.AreEqual(typeof(ReflectedObject), reflectedObject.GetType());
        }
    }
}
