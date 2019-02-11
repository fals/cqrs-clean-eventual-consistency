using Ametista.Core.Entities.Cards;
using Ametista.Core.Interfaces;

namespace Ametista.Core.Repository
{
    public interface ICardWriteOnlyRepository : IWriteOnlyRepository<Card>
    {
        bool IsDuplicatedCardNumber(string cardNamber);
    }
}