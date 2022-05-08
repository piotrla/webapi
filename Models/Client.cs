using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("kontrahenci")]
public class Client
{
    [Key]
    public int Id { get; set; }
    public string NazwaKlienta { get; set; }
    //Na potrzeby faktur, nie jest unikatowa
    public string NazwaKlientaPelna { get; set; }
    public string Nip { get; set; }
    public string Ulica { get; set; }
    public string Miejscowosc { get; set; }
    public string KodPocztowy { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public string Notatka { get; set; }
    public int? Stawka { get; set; }
    public string RodzajKlienta { get; set; }
    public string Pesel { get; set; }

}