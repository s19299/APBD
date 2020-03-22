using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace APBDConsoleApp
{
    [Serializable]
    public class Student
    {
        
        [JsonPropertyName("name")] 
        [XmlElement(ElementName = "name")] public string name { get; set; }

        [JsonPropertyName("surname")] 
        [XmlElement(ElementName = "surname")] public string surname { get; set; }

        [JsonPropertyName("Course Name")] 
        [XmlElement(ElementName = "courseName")] public Studies courseName { get; set;}
        
        [JsonPropertyName("Mothers Name")]
        [XmlElement(ElementName = "mother")] public string mother { get; set; }

        [JsonPropertyName("Fathers Name")] 
        [XmlElement(ElementName = "father")] public string father { get; set; }
        
        [JsonPropertyName("Email Address")]
        [XmlElement(ElementName = "email")] public string email { get; set; }
        
        [JsonPropertyName("Index Number")]
        [XmlElement(ElementName = "index")] public string index { get; set; }
        
        [JsonPropertyName("Birthdate")]
        [XmlElement(ElementName = "birthdate")] public string birthdate { get; set; }
        
        public Student(string name, string surname, Studies courseName, string mother, string father, string email, string index, string birthdate)
        {
            this.name = name;
            this.surname = surname;
            this.courseName = courseName;
            this.mother = mother;
            this.father = father;
            this.email = email;
            this.index = index;
            this.birthdate = birthdate;
        }

        public Student()
        {
            
        }
        
    }
}