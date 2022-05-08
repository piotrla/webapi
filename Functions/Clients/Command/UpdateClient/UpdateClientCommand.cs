using MediatR;

public class UpdateClientCommand : IRequest
{
    public Client Client { get; set; }
}