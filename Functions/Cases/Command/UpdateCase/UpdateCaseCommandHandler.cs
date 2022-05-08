using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class UpdateCaseCommandHandler : IRequestHandler<UpdateCaseCommand>
{
    private readonly DatabaseContext _dbContext;
    public UpdateCaseCommandHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Update(request.Case);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}