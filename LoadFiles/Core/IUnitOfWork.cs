using System.Threading.Tasks;

namespace LoadFiles.Core
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}