namespace FormCizimiDers;

public class ButonKutusu : Kutu
{
    public delegate void IslemYapDelegate();
    public event IslemYapDelegate IslemYap;
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

    public ButonKutusu()
    {
        Deger = "";
        AktifOlabilir = true;
        Cizgili = true;
    }

    public override void Ciz()
    {
        solUstKose = AktifMi ? "╔" : "┌";
        sagUstKose = AktifMi ? "╗" : "┐";
        solAltKose = AktifMi ? "╚" : "└";
        sagAltKose = AktifMi ? "╝" : "┘";
        yatayKenar = AktifMi ? "═" : "─";
        dikeyKenar = AktifMi ? "║" : "│";
        base.Ciz();
        Console.SetCursorPosition(Konum.X + Boyut.Width / 2 - Deger.Length / 2, Konum.Y + 1);
        Console.Write(_deger);
    }

    public override void AktifEt()
    {
        base.AktifEt();
        Ciz();
        Console.CursorVisible = false;
    }

    public override void PasifEt()
    {
        base.PasifEt();
        Ciz();
    }

    public override void Isle(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Spacebar)
        {
            if (IslemYap != null)
                IslemYap();
        }
    }
}