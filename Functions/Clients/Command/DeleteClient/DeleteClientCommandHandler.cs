using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
{
    private readonly DatabaseContext _dbContext;

    public DeleteClientCommandHandler(DatabaseContext dbContext) => _dbContext = dbContext;
    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        Client existingClient = await _dbContext.Clients.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (existingClient != null)
        {
            _dbContext.Remove(existingClient);
            int info = await _dbContext.SaveChangesAsync(cancellationToken);
            return info > 0;
        }

        return false;
    }
}