using Ametista.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Command.Commands
{
    public class CreateCardResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
