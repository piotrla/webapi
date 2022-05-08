using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ClientController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    //GET api/clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients(OrderByClientOptions orderOption)
    {
        IEnumerable<Client> clients = await _mediator.Send(new GetClientsListQuery() { OrderBy = orderOption });
        return Ok(_mapper.Map<IEnumerable<ClientDTO>>(clients));
    }

    //GET api/clients/{id}
    [HttpGet("{id:int}", Name = "GetClientById")]
    public async Task<ActionResult> GetClientById(int id)
    {
        var client = await _mediator.Send(new GetClientByIdQuery() { Id = id });
        if (client != null)
            return Ok(_mapper.Map<ClientDTO>(client));

        return StatusCode(204, "There is no Client provided with that Id.");
    }

    [HttpPost]
    public async Task<ActionResult> CreateClient(ClientDTO client)
    {
        Client currnetClient = _mapper.Map<Client>(client);
        Client createdClient = await _mediator.Send(new CreateClientCommand() { Client = currnetClient });
        return CreatedAtRoute(nameof(GetClientById), new { Id = createdClient.Id }, createdClient);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateClient(ClientDTO client)
    {
        var existingClient = await _mediator.Send(new GetClientByIdQuery() { Id = client.Id });
        if (existingClient == null)
            return StatusCode(204, "Client not found.");

        _mapper.Map(client, existingClient);
        await _mediator.Send(new UpdateClientCommand() { Client = existingClient });
        return StatusCode(200, "Client updated successfully.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteClient(int id)
    {
        bool deleted = await _mediator.Send(new DeleteClientCommand() { Id = id });
        if (!deleted)
            return NoContent();

        return Ok();
    }


    [HttpGet("{id:int}/cases")]
    public async Task<ActionResult<IEnumerable<CaseDTO>>> GetClientCases(int id)
    {
        var clientCases = await _mediator.Send(new GetClientCasesQuery() { ClientId = id });
        if (clientCases != null)
            return Ok(_mapper.Map<IEnumerable<CaseDTO>>(clientCases));

        return NoContent();
    }
}