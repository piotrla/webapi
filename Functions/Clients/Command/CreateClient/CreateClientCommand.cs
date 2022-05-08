using MediatR;

public class CreateClientCommand : IRequest<Client>
{
    public Client Client { get; set; }
}

/*
-- or --
public record CreateClientCommand(Client client) : IRequest;
*/