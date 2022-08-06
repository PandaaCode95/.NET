using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Sevices
{
    public class CategoryService : ICategory
    {
        public IEnumerable<Curso> GetCursoCategory()
        {
            var categoryCursoList = new List<Curso>();

            IEnumerable<Curso> query = (IEnumerable<Curso>)categoryCursoList.Select(e => e.name == "Alpaca");

            return query;
        }
    }
}
