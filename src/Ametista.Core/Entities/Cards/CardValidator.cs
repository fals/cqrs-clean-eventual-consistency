using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.Entities.Cards
{
    public class CardValidator : Validator<Card>
    {
        public CardValidator(ValidationNotificationHandler notificationHandler) : base(notificationHandler)
        {
        }

        public override void Validate(Card entity)
        {
            CheckRule<CardHasValidCardNumberSpec>(entity, nameof(Card.Number), $"Ivalid Card Number {entity.Number}");
        }
    }
}
