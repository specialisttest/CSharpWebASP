using System.ComponentModel.DataAnnotations;

namespace CoinApp.Models;

public class Coin {
    public int Id   { get; set; }
    [Range(1900,2023)]
    public int Year { get; set; }
    public string Country { get; set; }
    public string Metal   { get; set; }
    public string Face    { get; set; }
    public string Comment { get; set; } =".";
    public string Denomination   { get; set; }
}   