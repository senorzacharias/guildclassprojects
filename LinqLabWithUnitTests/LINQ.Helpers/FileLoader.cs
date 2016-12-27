using System.IO;
using System.Reflection;

namespace Linq.Helpers
{
    public static class FileLoader
    {
        public static string GetExpectedResults(string fileName)
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string expectedResults = currentDirectory + @"\ExpectedResults\";
            string path = Path.Combine(expectedResults, fileName);

            return File.Exists(path)
                ? File.ReadAllText(path)
                : null;
        }
    }
}
