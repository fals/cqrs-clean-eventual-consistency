using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IMaterialize<TData>
    {
        Task<bool> Materialize(TData data);
    }
}
