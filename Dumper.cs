using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Linq
{
    public static class Dumper
    {
        public static string ToPrettyString(this object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }

        public static T Dump<T>(this T value)
        {
            Console.WriteLine(value.ToPrettyString());
            return value;
        }

    }
}
