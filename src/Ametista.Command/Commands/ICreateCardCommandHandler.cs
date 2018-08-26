using System.Threading.Tasks;

namespace Ametista.Command.Commands
{
    public interface ICreateCardCommandHandler
    {
        Task<CreateCardCommandResult> Handle(CreateCardCommand command);
    }
}