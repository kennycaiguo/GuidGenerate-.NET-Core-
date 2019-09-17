﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GuidGenerate
{
    public class InsertGuid
    {

        public static Dictionary<string, string> getProps(Type anyType)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            PropertyInfo[] prop = anyType.GetProperties();

            foreach(var p in prop)
            {
                props.Add(p.Name, p.PropertyType.ToString().Substring(p.PropertyType.ToString().IndexOf(".") + 1));
            }

            return props;
        }

        public static Dictionary<string, string> getAttrs(Type anyType)
        {
            Dictionary<string, string> attrs = new Dictionary<string, string>();

            PropertyInfo[] prop = anyType.GetProperties();

            foreach (var p in prop)
            {
                Object[] attr = p.GetCustomAttributes(typeof(GUID), false);
                if(attr.Length != 0)
                {
                    GUID guid = (GUID)attr[0];
                    attrs.Add(p.Name, guid.getGuid());
                }
                else
                {
                    attrs.Add(p.Name, "");
                }
            }

            return attrs;
        }

        public static Boolean hasClassAttr(Type anyType)
        {
            Boolean value = false;

            Attribute classAttr = anyType.GetCustomAttribute(typeof(GUID), false);

            if(classAttr != null)
            {
                value = true;
            }

            return value;
        }
       
        public static string[] readIn(string fileName)
        {

            string textFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, fileName + ".txt");
            Console.WriteLine(textFile);

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName)
        {
            System.IO.File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\" + fileName + ".cs"), text);
            
        }
    }
}
