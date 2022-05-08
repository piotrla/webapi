using MediatR;

public class DeleteClientCommand : IRequest<bool>
{
    public int Id { get; set; }
}