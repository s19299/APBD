using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;


namespace APBDConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = (args.Length > 0) ? args[0] : @"Files\dane.csv";
                var outputPath = (args.Length > 1) ? args[1] : @"Files\Result.xml";
                var outputFormat = (args.Length > 2) ? args[2] : "json";


                if (!(File.Exists(inputPath)))
                {
                    throw new FileNotFoundException("nie ma pliku po sciezce " + inputPath);
                }

                var university = new University();
                var actCourses = new Dictionary<string, int>();

                string[] infomations;
                foreach (string line in File.ReadLines(@"Files\dane.csv"))
                {

                    infomations = line.Split(",");


                    if (infomations.Length != 9)
                    {
                        File.AppendAllText("log.txt",
                            $"brak wystarczajacej ilosci kolumn w wierszu: {line} {DateTime.UtcNow}" + "\n");
                        continue;
                    }

                    bool isValid = true;

                    if (infomations.Contains(String.Empty) || infomations.Contains(null))
                    {
                        File.AppendAllText("log.txt", $"jedna z wartosci jest brakujaca {DateTime.UtcNow}" + "\n");
                        isValid = false;
                        continue;
                    }

                    var student = new Student
                    {
                        name = infomations[0],
                        surname = infomations[1],
                        courseName = new Studies
                        {
                            course = infomations[2],
                            mode = infomations[3]
                        },
                        index = infomations[4],
                        birthdate = infomations[5],
                        email = infomations[6],
                        mother = infomations[7],
                        father = infomations[8]
                    };

                    if (isValid)
                    {
                        university.students.Add(student);

                        if (!(actCourses.ContainsKey(infomations[2])))
                        {
                            actCourses.Add(infomations[2], 1);
                        }
                        if (actCourses.ContainsKey(infomations[2]) && infomations[2] != null)
                        {
                            actCourses[infomations[2]]++;
                        }
                    }
                    
                }

                foreach (string key in actCourses.Keys)
                {
                    university.activeCourses.Add(new Studies()
                        {course = key, numOfStudents = actCourses[key].ToString()});
                }

                university.author = "Robert DeNiro";
                
                if (outputFormat.Equals("xml"))
                
                {
                    var serializer = new XmlSerializer(typeof(University));
                    var serializerSettings = new XmlWriterSettings();
                    serializerSettings.OmitXmlDeclaration = true;
                    serializerSettings.Indent = true;
                    var emptySpaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                    var writer = XmlWriter.Create(new FileStream($"{outputPath}", FileMode.Create), serializerSettings);
                    serializer.Serialize(writer, university, emptySpaces);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("nie ma takiego pliku");
            }
        }
    }
}