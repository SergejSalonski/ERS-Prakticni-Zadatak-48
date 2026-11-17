namespace Domain.Models;

using Domain.Common;
using Domain.Enums;
// Zajednički osnovni tip iz koga se mogu izvesti modeli konkretnog zadatka.
// Polja, nazive i nasledjivanje prilagoditi dodeljenoj specifikaciji.
public abstract class Zapis
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Naziv { get; init; } = string.Empty;
    public string Opis { get; init; } = string.Empty;
    public DateTimeOffset KreiranoUtc { get; init; } = DateTimeOffset.UtcNow;

    public int Iznos {get; init;}
    public string ImeUplatioca {get; init;} = string.Empty;
    public StatusObrade Status {get; set;} = StatusObrade.naCekanju;
    public string? RazlogPonistavanja {get; set;}

    public abstract string TipZapisa {get;}

    protected Zapis() {}

    protected Zapis(string naziv, string opis, int iznos, string ime)
    {
        if (string.IsNullOrWhiteSpace(naziv))
            throw new ArgumentException("Naziv zapisa ne sme biti prazan.");

        if (string.IsNullOrWhiteSpace(opis))
            throw new ArgumentException("Opis zapisa ne sme biti prazan.");

        if (iznos <= 0)
            throw new ArgumentException("Iznos mora biti pozitivan broj.");

        if (string.IsNullOrWhiteSpace(ime))
            throw new ArgumentException("Ime uplatioca ne sme biti prazno.");

        Naziv = naziv.Trim();
        Opis = opis.Trim();
        Iznos = iznos;
        ImeUplatioca = ime.Trim();
    }


    public RezultatOperacije PotvrdiUplatu()
    {
        if (Status == StatusObrade.Potvrdjeno)
            return RezultatOperacije.Neuspesno("Uplata je vec potrvdjena.");
        
        if(Status == StatusObrade.Ponisteno)
            return RezultatOperacije.Neuspesno("Ponistena uplata se ne moze potvrditi.");

        Status = StatusObrade.Potvrdjeno;
        return RezultatOperacije.Uspesno("Uplata je uspesno potvrdjena");
    }

    public RezultatOperacije PonistiUplatu(string razlog)
    {
        if (Status == StatusObrade.Ponisteno)
            return RezultatOperacije.Neuspesno("Uplata je već poništena.");

        if (string.IsNullOrWhiteSpace(razlog))
            return RezultatOperacije.Neuspesno("Razlog poništavanja je obavezan.");

        Status = StatusObrade.Ponisteno;
        RazlogPonistavanja = razlog.Trim();
        return RezultatOperacije.Uspesno("Uplata je uspešno poništena.");
    }





}
