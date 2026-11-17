namespace Domain.Models; 


public class Clanarina : Zapis 
{
    public string MesecClanarine {get ; init;} = string.Empty;
    public string Period { get; init; } = string.Empty;

    public override string TipZapisa => "Clanarina";
    public Clanarina() {}

    public Clanarina(string naziv, string opis, int iznos, string imeUplatioca, string mesecClanarine, string period) : base(naziv,opis,iznos,imeUplatioca)
    {
       if (string.IsNullOrWhiteSpace(mesecClanarine))
            throw new ArgumentException("Mesec članarine je obavezan.");

        if (string.IsNullOrWhiteSpace(period))
            throw new ArgumentException("Period članarine mora biti naveden.");


        MesecClanarine = mesecClanarine;
        Period = period.Trim();
    }


}