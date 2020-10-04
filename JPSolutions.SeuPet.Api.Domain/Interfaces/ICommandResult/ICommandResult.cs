namespace JPSolutions.SeuPet.Api.Domain.Interfaces.ICommandResult
{
    public interface ICommandResult
    {
        bool IsSucess { get; set; }
        string Message { get; set; }
        //T Data { get; set; }
    }
}
