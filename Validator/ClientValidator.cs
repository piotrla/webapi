using System.Collections.Generic;
using FluentValidation;

public class CreateClientValidator : AbstractValidator<ClientDTO>
{
    public CreateClientValidator()
    {
        List<string> options = new List<string>() { "osoba fizyczna", "firma" };

        RuleFor(x => x.NazwaKlienta)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(255);
        RuleFor(x => x.RodzajKlienta)
            .Must(x => options.Contains(x))
            .WithMessage("'Rodzaj klienta' musi posiadać jedną z opcji: 'osoba fizyczna', 'firma'.");
        RuleFor(x => x.NazwaKlientaPelna)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(255);
        RuleFor(x => x.Nip)
            .NotEmpty()
            .When(x => x.RodzajKlienta != null ? x.RodzajKlienta.ToLower() == "firma" : false)
            .MaximumLength(10);
        RuleFor(x => x.Ulica)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(x => x.Miejscowosc)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(x => x.KodPocztowy)
            .NotEmpty()
            .Matches("[0-9]{2}-[0-9]{3}");
        RuleFor(x => x.Email)
            .EmailAddress();
        RuleFor(x => x.Telefon)
            .NotEmpty()
            .MaximumLength(20);
        RuleFor(x => x.Notatka)
            .MaximumLength(255);
        RuleFor(x => x.Pesel)
            .NotEmpty()
            .When(x => x.RodzajKlienta != null ? x.RodzajKlienta.ToLower() == "osoba fizyczna" : false)
            .MaximumLength(11);
    }
}