using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteCaseCommandHandler : IRequestHandler<DeleteCaseCommand, bool>
{
    private readonly DatabaseContext _dbContext;
    public DeleteCaseCommandHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<bool> Handle(DeleteCaseCommand request, CancellationToken cancellationToken)
    {
        Case existingCase = await _dbContext.Cases.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (existingCase == null)
            return false;

        _dbContext.Remove(existingCase);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}