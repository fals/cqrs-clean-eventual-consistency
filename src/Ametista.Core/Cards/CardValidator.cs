namespace Ametista.Core.Cards
{
    public class CardValidator : Validator<Card>
    {
        public CardValidator(ValidationNotificationHandler notificationHandler) : base(notificationHandler)
        {
        }

        public override void Validate(Card entity)
        {
            CheckRule<HasValidNumberSpec>(entity, nameof(Card.Number), $"Ivalid Card Number {entity.Number}");
        }
    }
}
