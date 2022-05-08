using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
{
    private readonly DatabaseContext _dbContext;

    public UpdateClientCommandHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Update(request.Client);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}