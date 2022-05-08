using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
{
    private readonly DatabaseContext _dbContext;
    public CreateClientCommandHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(request.Client);
        await _dbContext.SaveChangesAsync();

        return request.Client;
    }
}