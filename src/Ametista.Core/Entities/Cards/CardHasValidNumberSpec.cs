using System.Linq;

namespace Ametista.Core.Entities.Cards
{
    public class CardHasValidNumberSpec : CompositeSpecification<Card>
    {
        public CardHasValidNumberSpec()
        {

        }

        public override bool IsSatisfiedBy(Card candidate)
        {
            if (string.IsNullOrEmpty(candidate.Number) || candidate.Number.Length < 13)
            {
                return false;
            }

            // 
            // https://stackoverflow.com/questions/21249670/implementing-luhn-algorithm-using-c-sharp
            // https://en.wikipedia.org/wiki/Luhn_algorithm
            //
            var digits = candidate.Number;

            return digits.All(char.IsDigit) && digits.Reverse()
            .Select(c => c - 48)
            .Select((thisNum, i) => i % 2 == 0
                ? thisNum
                : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
            ).Sum() % 10 == 0;
        }
    }
}
