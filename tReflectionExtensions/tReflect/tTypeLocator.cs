using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionExtensions;
using System.Linq;
using tReflectionExtensions.TestClasses;
using static ReflectionExtensions.ReflectionExtensions;

namespace tReflectionExtensions.tReflect {

    [TestClass]
    public class tTypeLocator {

        [TestMethod]
        public void tTypeLocator_ByAttribute(){
            var result = Reflect().Locate.Type.ByAttribute(typeof(TestAttribute));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void tTypeLocator_ByAttribute_WithPredicate() {
            var types = Reflect().Locate.Type.ByAttribute(typeof(TestAttribute),
                x => (string)Reflect((object)x)["Name"] == "Line"
            );
            Assert.AreEqual(1, types.Count());
        }
    }
}
