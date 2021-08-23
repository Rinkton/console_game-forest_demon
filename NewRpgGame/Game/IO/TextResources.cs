using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace Game.IO
{
    public static class TextResources
    {
        private static ResourceManager rm = new ResourceManager("Game.text", Assembly.GetExecutingAssembly());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName">Имя ресурса, что принадлежит <see cref="text"/>.resx</param>
        public static string GetStringByResourceName(string resourceName)
        {
            string str = rm.GetString(resourceName);
            throwExceptionIfResourceDontExist(str);
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName">
        /// Общее слово, что в <see cref="text"/>.resx имеет после себя счётчик 
        /// (вы можете найти это в <see cref="text"/>.resx с именами "test0", "test1" т.д.)
        /// </param>
        /// <returns></returns>
        public static string[] GetStringsByResourceGroupName(string resourceGroupName)
        {
            List<string> stringList = new List<string>();

            try
            {
                int i = 0;
                while(true)
                {
                    string str = GetStringByResourceName(resourceGroupName + i);
                    if (str == null)
                    {
                        break;
                    }
                    stringList.Add(str);
                    i++;
                }
            }
            catch { }

            throwExceptionIfResourceDontExist(stringList);
            return stringList.ToArray();
        }

        private static void throwExceptionIfResourceDontExist(string str)
        {
            if (str == null)
            {
                throw new Exception("В ресурсах не было найдено строки под таким именем ресурса.");
            }
        }
        private static void throwExceptionIfResourceDontExist(List<string> stringList)
        {
            if (stringList.Count == 0)
            {
                throw new Exception("В ресурсах не было найдено никаких строк с таким именем группы ресурсов.");
            }
        }
    }
}
