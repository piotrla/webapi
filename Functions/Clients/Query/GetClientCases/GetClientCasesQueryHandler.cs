using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetClientCasesQueryHandler : IRequestHandler<GetClientCasesQuery, IEnumerable<Case>>
{
    private readonly DatabaseContext _dbContext;
    public GetClientCasesQueryHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Case>> Handle(GetClientCasesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Case> clientCases = await _dbContext.Cases.Where(x => x.KontrahentId == request.ClientId).ToListAsync();
        return clientCases;
    }
}