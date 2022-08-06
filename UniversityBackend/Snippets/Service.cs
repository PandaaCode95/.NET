using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityBackend.Models.DataModels;

namespace LinQSnippets
{
    internal class Service
    {
        
        public static void busqueda()
        {
            var userList = new List<User>();
            string mail = "hola@gmail.com";

            var bEmail = from user in userList
                         where user.email == mail
                         select user;

            var studentList = new List<Student>();

            var GrtrThan = from student in studentList
                           where student.birth.Year<2004
                           select student;

            var oneCourse = from student in studentList
                            where student.curso.Count>0
                            select student;

            var courseList = new List<Curso>();

            var courseUno = from curso in courseList 
                            where curso.level == Nivel.Basico &&
                            curso.students.Count > 0
                            select curso;

            var courseDos = courseList.Select(e => (e.level == Nivel.Intermedio) && (e.categories.Any(cat => cat.Id == 1)));



            var courseTres = from curso in courseList
                             where curso.students.Count == 0
                             select curso;


        }
    }
}
