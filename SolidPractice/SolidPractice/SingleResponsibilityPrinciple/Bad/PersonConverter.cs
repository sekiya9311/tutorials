using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SolidPractice.SingleResponsibilityPrinciple.Bad
{
    public class PersonConverter
    {
        public void CsvToJson(Stream inputStream, Stream outputStream)
        {
            // 入力ストリームからCSVデータの読み取り
            var lines = new List<string>();
            using (var reader = new StreamReader(inputStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
            }

            // CSVデータを解析し、Entityに変換
            var persons = new List<Person>();
            foreach (var line in lines)
            {
                var fields = line.Split(",".ToCharArray());

                if (fields.Length != 4)
                {
                    Console.WriteLine("invalid");
                    continue;
                }
                if (!int.TryParse(fields[1], out var age))
                {
                    Console.WriteLine("invalid");
                    continue;
                }
                if (!double.TryParse(fields[2], out var height))
                {
                    Console.WriteLine("invalid");
                    continue;
                }
                if (!double.TryParse(fields[3], out var weight))
                {
                    Console.WriteLine("invalid");
                    continue;
                }

                var person = new Person()
                {
                    Name = fields[0],
                    Age = age,
                    Height = height,
                    Weight = weight
                };
                persons.Add(person);
            }

            // Entityデータをjsonに変換し出力ストリームに出力
            using (var writer = new StreamWriter(outputStream))
            {
                var personArrayOfJson = JsonConvert.SerializeObject(persons);
                writer.WriteLine(personArrayOfJson);
            }
        }
    }
}
