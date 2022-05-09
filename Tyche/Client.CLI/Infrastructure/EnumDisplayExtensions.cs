using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Client.CLI.Infrastructure
{
    public static class EnumDisplayExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var attributeType = typeof(DisplayAttribute);

            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            var attributes = fi.GetCustomAttributes(attributeType, false)
                               .Cast<DisplayAttribute>()
                               .ToList();

            List<string> names = new List<string>();
            foreach (var attribute in attributes)
            {
                string name = attribute.Name;
                names.Add(name);
            }

            return String.Join("", names);
        }
    }
}
