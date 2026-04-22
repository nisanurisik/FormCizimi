namespace FormCizimiDers;

public class MetinKutusu : Kutu
{
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

    public MetinKutusu()
    {
        Deger = "";
        AktifOlabilir = true;
        Cizgili = true;
    }

    public override void Ciz()
    {
        base.Ciz();
        Console.SetCursorPosition(Konum.X + 1, Konum.Y + 1);
        Console.Write(_deger);
    }

    public override void Isle(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Backspace)
        {
            if (Deger.Length > 0)
                Deger = Deger.Remove(Deger.Length - 1);
        }
        else if (Deger.Length < Boyut.Width - 2)
        {
            Deger += keyInfo.KeyChar;
        }
    }

    public override void AktifEt()
    {
        Console.CursorVisible = true;
        Console.SetCursorPosition(Konum.X + 1 + Deger.Length, Konum.Y + 1);
    }
}