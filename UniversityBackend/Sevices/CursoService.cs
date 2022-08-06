using System.Linq;
using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Sevices
{
    public class CursoService : ICourseService
    {
        public IEnumerable<Curso> GetCursoNoTema()
        {
            var curso = new List<Curso>();

            IEnumerable<Curso> query = (IEnumerable<Curso>)curso.Select(e=>e.chapter==null);

            return query;
        }

        public IEnumerable<Curso> GetTemaCurso()
        {
            var curso = new List<Curso>();

            IEnumerable<Curso> query = (IEnumerable<Curso>)curso.Select(e => e.chapter.title == "C4");

            return query;
        }
    }
}
