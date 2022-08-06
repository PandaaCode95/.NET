using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Sevices
{
    public interface ICourseService
    {
       
      
        IEnumerable<Curso> GetCursoNoTema();
        IEnumerable<Curso> GetTemaCurso();
       
    }
}
