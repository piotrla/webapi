using System;
using MediatR;

public class DeleteCaseCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}