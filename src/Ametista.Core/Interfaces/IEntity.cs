namespace Ametista.Core
{
    public interface IEntity
    {
        bool Valid { get; }
        void Validate(ValidationNotificationHandler notificationHandler);
    }

    public interface IEntity<T> : IEntity
    {
        T Id { get; }
    }
}