using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Sevices
{
    public interface ICategory
    {
        IEnumerable<Curso> GetCursoCategory();
    }
}
