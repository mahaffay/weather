using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WeatherData
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"weather.dat");

            List<Temps> tempList = new List<Temps>();
            string[] files = File.ReadAllLines(path);
            
            for (int m = 2; m < files.Length - 1; m++)
            {
                string[] row = files[m].Replace("*", "").Trim().Split(' ');
                row = row.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                tempList.Add(new Temps()
                {
                    day = Convert.ToInt16(row[0]),
                    maxTemp = Convert.ToInt16(row[1]),
                    minTemp = Convert.ToInt16(row[2]), 
                    difference = Convert.ToInt16(row[1]) - Convert.ToInt16(row[2])
                });
            }

            var result = tempList.OrderBy(a => a.difference);

            var smallestDiff = result.Select(x => x.day).First();

            Console.WriteLine("June " + smallestDiff.ToString() + " had the smallest temperature change in 2002");
            Console.ReadKey();
        }
    }
}
