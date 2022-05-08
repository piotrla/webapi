using System;
using System.Collections.Generic;
using FluentValidation;

public class CaseValidator : AbstractValidator<CaseDTO>
{
    public CaseValidator()
    {
        List<string> status = new List<string>() { "otwarty", "zamknięty" };

        RuleFor(x => x.KontrahentId)
            .NotEmpty();
        RuleFor(x => x.NazwaSprawy)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(255);
        RuleFor(x => x.DataWprowadzeniaSprawy)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(x => x != default(DateTime))
            .WithMessage("'Data wprowadzenia sprawy' jest wymagana. Pożądany format: YYYYMMDD HH:mm:ss");
        RuleFor(x => x.RodzajSprawy)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(x => x.Sygnatura)
            .MaximumLength(255);
        RuleFor(x => x.Status)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(x => status.Contains(x))
            .WithMessage("'Status' musi posiadać jedną z opcji: 'otwarty', 'zamknięty'.");
    }
}