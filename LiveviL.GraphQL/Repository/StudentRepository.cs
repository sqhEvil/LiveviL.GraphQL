using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveviL.GraphQL.Repository
{
    public class Student
    {
        public int id { get; set; }

        public string name { get; set; }

        public int score { get; set; }

    }

    public class StudentRepository
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){ id=1 , name="张三" , score=66},
            new Student(){ id=2 , name="李四" , score=77},
            new Student(){ id=3 , name="王五" , score=88}
        };

        public Student GetById(int id)
        {
            return students.Where(s => s.id == id).FirstOrDefault();
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public bool Update(int id, Student student)
        {
            var stu = students.Where(s => s.id == id).FirstOrDefault();
            if (stu == null)
            {
                return false;
            }
            else
            {
                stu.name = student.name;
                stu.score = student.score;
                return true;
            }
        }
        public bool Add(Student student)
        {
            student.id = students.Max(x => x.id) + 1;
            if (students.Count < 10)
            {
                students.Add(student);
            }
            else
            {
                students.RemoveRange(0, students.Count - 9);
                students.Add(student);
            }
            return true;
        }
    }
}
