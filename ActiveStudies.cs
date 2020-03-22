using System;
using System.Reflection;

namespace APBDConsoleApp
{
    public class ActiveStudies
    {

        public int numOfStudents;
        public string nameOfCourse;

        public override bool Equals(Object obj)
        {
            if (!(obj is ActiveStudies))
            {
                return false;
            }

            return true;
        }
    }
}