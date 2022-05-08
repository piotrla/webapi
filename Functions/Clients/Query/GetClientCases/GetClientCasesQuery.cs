using System.Collections.Generic;
using MediatR;
public class GetClientCasesQuery : IRequest<IEnumerable<Case>>
{
    public int ClientId { get; set; }
}