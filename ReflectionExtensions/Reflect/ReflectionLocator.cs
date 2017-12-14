
namespace ReflectionExtensions {
    public class ReflectionLocator {

        public TypeLocator Type { get { return new TypeLocator(); } }

        public AssemblyLocator Assembly { get { return new AssemblyLocator(); } }

    }
}
