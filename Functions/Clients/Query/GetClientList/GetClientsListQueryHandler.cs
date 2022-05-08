using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, IEnumerable<Client>>
{
    private readonly DatabaseContext _dbContext;
    public GetClientsListQueryHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Client>> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
    {
        if (request.OrderBy == OrderByClientOptions.ByCity)
        {
            return await _dbContext.Clients.OrderBy(x => x.Miejscowosc).ToListAsync(cancellationToken);
        }
        else if (request.OrderBy == OrderByClientOptions.ByName)
        {
            return await _dbContext.Clients.OrderBy(x => x.NazwaKlienta).ToListAsync(cancellationToken);
        }
        else if (request.OrderBy == OrderByClientOptions.ByType)
        {
            return await _dbContext.Clients.OrderBy(x => x.RodzajKlienta).ToListAsync(cancellationToken);
        }

        return await _dbContext.Clients.ToListAsync(cancellationToken);
    }
}