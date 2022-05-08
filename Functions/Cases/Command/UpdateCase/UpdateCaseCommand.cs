using MediatR;

public class UpdateCaseCommand : IRequest
{
    public Case Case { get; set; }
}