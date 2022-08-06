using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Sevices
{
    public class StudentService : IStudentService
    {
       
        IEnumerable<Curso> IStudentService.GetStudentNoCurso()
        {
            var studentN = new List<Student>();

            IEnumerable<Curso> query = (IEnumerable<Curso>)studentN.Select(e => e.curso == null);

            return query;
        }

        IEnumerable<Curso> IStudentService.GetCursoStudent()
        {
            var studentN = new List<Student>();

            IEnumerable<Curso> query = (IEnumerable<Curso>)studentN.Select(e => e.curso.Select(x=>x.name==".NET"));

            return query;
        }
    }
}
