using System.Collections.Generic;
using MediatR;

public enum OrderByClientOptions
{
    None,
    ByName,
    ByCity,
    ByType
}
public class GetClientsListQuery : IRequest<IEnumerable<Client>>
{
    public OrderByClientOptions OrderBy { get; set; }
}