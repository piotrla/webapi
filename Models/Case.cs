using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("sprawy")]
public class Case
{
    [Key]
    [Column(TypeName = "char(36)")]
    public Guid Id { get; set; }
    public int KontrahentId { get; set; }
    public string NazwaSprawy { get; set; }
    public DateTime DataWprowadzeniaSprawy { get; set; }
    public string RodzajSprawy { get; set; }
    public string Sygnatura { get; set; }
    public int NrWewnetrzny { get; set; }
    //Otwarty, Zamkniety
    public string Status { get; set; }
}