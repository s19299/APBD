using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace APBDConsoleApp
{
    public class University
    {
        
        [JsonPropertyName("Author")]
        [XmlElement(ElementName = "author")] public string author { get; set; }

        [JsonPropertyName("CreatedAt")] 
        [XmlElement(ElementName = "createdAt")]
        public string createdAt { get; set; }
        
        public HashSet<Student> students { get; set; }
        public HashSet<Studies> activeCourses { get; set; }
        public University()
        {
             students = new HashSet<Student>();
             activeCourses = new HashSet<Studies>();
             createdAt = DateTime.Now.ToString("dd-mm-yyyy");

        }
    }
}