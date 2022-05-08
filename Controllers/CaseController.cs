using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cases")]
public class CaseController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CaseController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateCase(CaseDTO caseToCreate)
    {
        Case currentCase = _mapper.Map<Case>(caseToCreate);
        Case createdCase = await _mediator.Send(new CreateCaseCommand() { Case = currentCase });
        return CreatedAtRoute(nameof(GetCaseById), new { Id = createdCase.Id }, createdCase);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateCase(CaseDTO caseToUpdate)
    {
        var existingCase = await _mediator.Send(new GetCaseByIdQuery() { Id = caseToUpdate.Id });
        if (existingCase == null)
            return StatusCode(204, "Case with provided Id does not exists.");

        _mapper.Map(caseToUpdate, existingCase);

        await _mediator.Send(new UpdateCaseCommand() { Case = existingCase });
        return StatusCode(200, "Case updated successfully.");
    }
    [HttpDelete("{id:guid}", Name = "DeleteCase")]
    public async Task<ActionResult> DeleteCase(Guid id)
    {
        bool deleted = await _mediator.Send(new DeleteCaseCommand() { Id = id });
        if (!deleted)
            return NoContent();

        return Ok();
    }

    [HttpGet("{id:guid}", Name = "GetCaseById")]
    public async Task<ActionResult> GetCaseById(Guid id)
    {
        var currentCase = await _mediator.Send(new GetCaseByIdQuery() { Id = id });
        if (currentCase != null)
            return Ok(_mapper.Map<CaseDTO>(currentCase));

        return StatusCode(204, "There is no Case provided with that Id.");
    }
}