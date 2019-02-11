using System;

namespace Ametista.Core
{
    public abstract class Validator<TEntity>
    {
        private readonly ValidationNotificationHandler notificationHandler;

        protected Validator(ValidationNotificationHandler notificationHandler)
        {
            this.notificationHandler = notificationHandler ?? throw new ArgumentNullException(nameof(notificationHandler));
        }

        public abstract bool Validate(TEntity entity);

        protected void CheckRule(TEntity entity, ISpecification<TEntity> specification, string code, string message)
        {
            var isSatisfied = specification.IsSatisfiedBy(entity);

            if (!isSatisfied)
            {
                notificationHandler.AddNotification(code, message);
            }
        }

        protected void CheckRule<TSpecification>(TEntity entity, string code, string message) where TSpecification : CompositeSpecification<TEntity>, new()
        {
            var spec = new TSpecification();

            CheckRule(entity, spec, code, message);
        }
    }
}
