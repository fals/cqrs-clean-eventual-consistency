using System;

namespace Ametista.Query.Queries
{
    public class GetCardByIdQuery : IQuery<CardViewQueryModel>
    {
        public GetCardByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}