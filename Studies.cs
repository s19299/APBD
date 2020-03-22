using System;
using System.Xml.Serialization;

namespace APBDConsoleApp
{
    [Serializable]
    public class Studies
    {
        [XmlAttribute(AttributeName = "course")] public string course { get; set;}
        [XmlAttribute(AttributeName = "mode")] public string mode { get; set; }
        public string numOfStudents;

        
        public Studies()
        {
            course= "nieznany";
            mode = "nieznany";
        }

        public Studies(string course, string mode)
        {
            this.course = course;
            this.mode = mode;
        }

        
    }
}