using System.Reflection;
using System.Resources;

namespace Game
{
    public static class Text
    {
        private static ResourceManager rm = new ResourceManager("Game.text", Assembly.GetExecutingAssembly());

        /// <summary>
        /// Write string into console by resource name
        /// </summary>
        /// <param name="resourceName">Resource name, that related to <see cref="text"/>.rsx</param>
        public static string GetStringByResourceName(string resourceName)
        {
            return rm.GetString(resourceName);
        }
    }
}
