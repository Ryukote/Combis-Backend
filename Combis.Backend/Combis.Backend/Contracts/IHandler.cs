using System.Threading.Tasks;

namespace Combis.Backend.Contracts
{
    public interface IHandler<T> where T : IDTO
    {
        Task<int> AddAsync(T dto);
    }
}
