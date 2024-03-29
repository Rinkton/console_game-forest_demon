﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Game.IO
{
    public static class TextResources
    {
        private static string text;

        static TextResources()
        {
            string rawText = resources.text;
            byte[] bytes = Encoding.Default.GetBytes(rawText);
            string cyrillicText = Encoding.UTF8.GetString(bytes);

            text = cyrillicText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName">Имя ресурса, содержащегося в файле text.csv в колонке resourceName</param>
        public static string GetStringByResourceName(string resourceName)
        {
            string[] rows = text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            foreach(string row in rows)
            {
                string[] columns = row.Split(';');
                if(resourceName == columns[0])
                {
                    return columns[1];
                }
            }
            throw new Exception($"В ресурсах не было найдено строки под таким именем ресурса ({resourceName}).");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName">
        /// Общее слово, что в файле text.csv в колонке resourceName имеет после себя счётчик 
        /// (вы можете найти это в text.csv с именами "test0", "test1" т.д.)
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

            throwExceptionIfResourceDontExist(stringList, resourceGroupName);
            return stringList.ToArray();
        }

        private static void throwExceptionIfResourceDontExist(string str, string resourceName)
        {
            if (str == null)
            {
                throw new Exception($"В ресурсах не было найдено строки под таким именем ресурса ({resourceName}).");
            }
        }
        private static void throwExceptionIfResourceDontExist(List<string> stringList, string groupResourceName)
        {
            if (stringList.Count == 0)
            {
                throw new Exception($"В ресурсах не было найдено никаких строк с таким именем группы ресурсов ({groupResourceName}).");
            }
        }
    }
}
