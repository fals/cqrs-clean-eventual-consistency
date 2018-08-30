using System;

namespace Ametista.Core
{
    public interface IEvent
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
    }
}