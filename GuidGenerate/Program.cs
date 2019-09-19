﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace GuidGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the properties and its type
            Dictionary<string, string> props = InsertGuid.getProps(typeof(PersonStart));

            //get the GUID value of the properties
            Dictionary<string, string> attrs = InsertGuid.getAttrs(typeof(PersonStart));

            //Has the class GUID value or not
            Boolean classAttr = InsertGuid.hasClassAttr(typeof(PersonStart));

            GenerateClass.generateClass("Template", "js", "GuidGenerate", "Person", classAttr, props, attrs);

        }
    }
}
