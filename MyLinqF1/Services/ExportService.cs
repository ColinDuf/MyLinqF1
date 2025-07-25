// Services/ExportService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using MyLinqF1.Models;

namespace MyLinqF1.Services
{
    public static class ExportService
    {
        public static void ExportAllFormats(
            List<object> items,
            string[] headers,
            Func<object,string>[] selectors,
            string basePathWithoutExtension)
        {
            // CSV
            var csvPath = basePathWithoutExtension + ".csv";
            EnsureDir(csvPath);
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(";", headers));
            foreach (var item in items)
                sb.AppendLine(string.Join(";", headers.Select((h,i) => selectors[i](item))));
            File.WriteAllText(csvPath, sb.ToString(), Encoding.UTF8);

            // JSON
            var list = items.Select(item => headers
                            .Select((h,i) => new KeyValuePair<string,string>(h, selectors[i](item)))
                            .ToDictionary(kv => kv.Key, kv => kv.Value))
                        .ToList();
            var jsonPath = basePathWithoutExtension + ".json";
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);

            // XML
            var xml = new XElement("Items",
                from item in items
                select new XElement("Item",
                    headers.Select((h,i) => new XElement(h, selectors[i](item)))
                )
            );
            var xmlPath = basePathWithoutExtension + ".xml";
            xml.Save(xmlPath);

            Console.WriteLine($"Export CSV → {csvPath}");
            Console.WriteLine($"Export JSON→ {jsonPath}");
            Console.WriteLine($"Export XML → {xmlPath}");
        }

        private static void EnsureDir(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
    }
}