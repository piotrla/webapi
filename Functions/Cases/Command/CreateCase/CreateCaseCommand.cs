using MediatR;

public class CreateCaseCommand : IRequest<Case>
{
    public Case Case { get; set; }
}
