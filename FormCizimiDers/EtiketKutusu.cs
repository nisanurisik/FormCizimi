namespace FormCizimiDers;

public class EtiketKutusu : Kutu
{
    public EtiketKutusu()
    {
        Cizgili = false;
        AktifOlabilir = false;
    }
    private string _deger;

    public string Deger
    {
        get { return _deger; }
        set
        {
            _deger = value;
            Ciz();
        }
    }
    
    public override void Ciz()
    {
        base.Ciz();
        Console.SetCursorPosition(Konum.X + 1, Konum.Y + 1);
        Console.Write(_deger);
    }
}