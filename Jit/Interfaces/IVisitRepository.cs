using Jit.Dtos;
using Jit.Models;

namespace Jit.Interfaces
{
    public interface IVisitRepository : IGenericRepository<Visit>
    {
        bool VisitExists(DateTime date);
        bool DateOfVisitValidator(DateTime value);
    }
}
