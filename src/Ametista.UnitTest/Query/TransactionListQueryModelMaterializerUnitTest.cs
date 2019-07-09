using Ametista.Core.Transactions;
using Ametista.Query.Materializers;
using Ametista.Query.QueryModel;
using Ametista.UnitTest.Mothers;
using Xunit;

namespace Ametista.UnitTest.Query
{
    public class TransactionListQueryModelMaterializerUnitTest
    {
        private readonly ITransactionListQueryModelMaterializer materializer;

        public TransactionListQueryModelMaterializerUnitTest()
        {
            materializer = new TransactionListQueryModelMaterializer();
        }

        [Fact]
        public void Should_Create_Model_With_Right_Data()
        {
            // Arrange
            var transaction = TransactionMother.CreateSimpleTransaction();
            var cardList = new CardListQueryModel()
            {
                CardHolder = "Name",
                Number = "12345678910"
            };

            // Act

            var queryModel = materializer.Materialize(transaction, cardList);

            // Assert
            AssertProperties(queryModel, transaction, cardList);
        }

        private void AssertProperties(TransactionListQueryModel queryModel, Transaction transaction, CardListQueryModel cardList)
        {
            Assert.Equal(queryModel.Id, transaction.Id);
            Assert.Equal(queryModel.Amount, transaction.Charge.Amount);
            Assert.Equal(queryModel.CurrencyCode, transaction.Charge.CurrencyCode);
            Assert.Equal(queryModel.ChargeDate, transaction.ChargeDate);
            Assert.Equal(queryModel.UniqueId, transaction.UniqueId);
            Assert.Equal(queryModel.CardHolder, cardList.CardHolder);
            Assert.Equal(queryModel.CardNumber, cardList.Number);
            
        }
    }
}
