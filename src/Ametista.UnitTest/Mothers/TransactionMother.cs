using Ametista.Core.Transactions;
using Ametista.UnitTest.Builders;
using System;

namespace Ametista.UnitTest.Mothers
{
    public static class TransactionMother
    {
        public static Transaction CreateSimpleTransaction()
        {
            return new TransactionBuilder()
                .ForCard(Guid.NewGuid())
                .HavingUniqueId(Guid.NewGuid().ToString("N"))
                .ChargedAt(DateTimeOffset.Now)
                .ContainingChargeAmount(new Ametista.Core.Money(100, "EUR"))
                .Build();
        }
    }
}
