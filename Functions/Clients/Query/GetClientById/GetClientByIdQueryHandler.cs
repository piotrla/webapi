using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
{
    private readonly DatabaseContext _dbContext;
    public GetClientByIdQueryHandler(DatabaseContext dbConext) => _dbContext = dbConext;

    public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Clients.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
    }
}