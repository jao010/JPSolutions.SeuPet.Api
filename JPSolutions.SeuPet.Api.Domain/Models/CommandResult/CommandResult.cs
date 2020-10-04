using JPSolutions.SeuPet.Api.Domain.Interfaces.ICommandResult;

namespace JPSolutions.SeuPet.Api.Domain.Models.CommandResult
{
    public class CommandResult<T> : ICommandResult
    {

        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
