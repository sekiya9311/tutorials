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
        public void Convert(Stream inputStream, Stream outputStream)
        {
            // 入力ストリームからCSVデータの読み取り
            var lines = InputFromStream(inputStream);

            // CSVデータを解析し、Entityに変換
            var persons = ParseToPersonEntity(lines);

            // Entityデータをjsonに変換し出力ストリームに出力
            OutputPersonsToStream(persons, outputStream);
        }

        private IEnumerable<string> InputFromStream(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
                // Streamで遅延処理はなんか怖い
                return lines;
            }
        }

        private IEnumerable<Person> ParseToPersonEntity(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var fields = line.Split(",".ToCharArray());

                if (fields.Length != 4)
                {
                    continue;
                }
                if (!int.TryParse(fields[1], out var age))
                {
                    continue;
                }
                if (!double.TryParse(fields[2], out var height))
                {
                    continue;
                }
                if (!double.TryParse(fields[3], out var weight))
                {
                    continue;
                }

                var person = new Person()
                {
                    Name = fields[0],
                    Age = age,
                    Height = height,
                    Weight = weight
                };
                
                yield return person;
            }
        }

        private void OutputPersonsToStream(IEnumerable<Person> persons, Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                var personArrayOfJson = JsonConvert.SerializeObject(persons);
                writer.WriteLine(personArrayOfJson);
            }
        }
    }
}
