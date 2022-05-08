using MediatR;

public class GetClientByIdQuery : IRequest<Client>
{
    //Client Id
    public int Id { get; set; }
}