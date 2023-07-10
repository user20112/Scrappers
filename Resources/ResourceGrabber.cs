using System.IO;
using System.Reflection;

namespace Scrappers.Resources
{
    public static class ResourceGrabber
    {
        public static byte[] GetResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("Scrappers.Resources." + name);
            if (stream == null)
                return null;
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}