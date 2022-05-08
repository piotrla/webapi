using System;
using MediatR;

public class GetCaseByIdQuery : IRequest<Case>
{
    public Guid Id { get; set; }
}