using UniversityBackend.Models.DataModels;
namespace UniversityBackend.Sevices
{
    public interface IStudentService
    {
        IEnumerable<Curso> GetStudentNoCurso();
        IEnumerable<Curso> GetCursoStudent();
    }
}
