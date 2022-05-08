using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetCaseByIdQueryHandler : IRequestHandler<GetCaseByIdQuery, Case>
{
    private readonly DatabaseContext _dbContext;
    public GetCaseByIdQueryHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<Case> Handle(GetCaseByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Cases.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
    }
}