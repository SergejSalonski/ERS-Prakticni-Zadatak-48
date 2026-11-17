namespace Domain.Common; 

public class RezultatOperacije
{
    public bool Uspeh { get;}
    public string Poruka {get;}

    protected RezultatOperacije(bool uspeh, string poruka)
    {
        Uspeh = uspeh; 
        Poruka = poruka;
    }


    public static RezultatOperacije Uspesno(string poruka = "Operacije je uspesno izvrsena.")
        {
            return new RezultatOperacije(true, poruka);
        }

    public static RezultatOperacije Neuspesno(string poruka) 
        {
            return new RezultatOperacije(false, poruka);
        }
}

public class RezultatOperacije<T>
{
    public bool Uspeh {get;}
    public string Poruka {get;}
    public T? Podatak {get; }


    public RezultatOperacije(bool uspeh, T? podatak, string poruka)
    {
        Uspeh = uspeh;
        Podatak = podatak; 
        Poruka = poruka;
    }

    public static RezultatOperacije<T> Uspesno(T podatak, string poruka = "Operacija je uspesno izvrsena")
    {
        return new RezultatOperacije<T>(true, podatak,poruka);
    }

    public static RezultatOperacije<T> Neuspesno(string poruka)
    {
        return new RezultatOperacije<T>(false, default,poruka);
    }


}