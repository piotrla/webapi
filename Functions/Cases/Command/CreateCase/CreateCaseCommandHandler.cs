using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, Case>
{
    private readonly DatabaseContext _dbContext;
    public CreateCaseCommandHandler(DatabaseContext dbContext) => _dbContext = dbContext;

    public async Task<Case> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
    {
        //Create new guid for case
        request.Case.Id = Guid.NewGuid();

        _dbContext.Add(request.Case);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return request.Case;
    }
}