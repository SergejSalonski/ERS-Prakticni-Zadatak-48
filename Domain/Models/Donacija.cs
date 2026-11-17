namespace Domain.Models;

public class Donacija : Zapis 
{

    public string ImeDonatora { get; init; } = string.Empty; 
    public override string TipZapisa => "Donacija";

    public Donacija() {}


    public Donacija(string naziv, string opis, int iznos, string imeDonatora)
    {
        ImeDonatora = imeDonatora;
    }








}