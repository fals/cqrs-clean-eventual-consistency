
using Ametista.Core.Interfaces;

namespace Ametista.Core.Cards
{
    public interface ICardWriteOnlyRepository : IWriteOnlyRepository<Card>
    {
        bool IsDuplicatedCardNumber(string cardNamber);
    }
}