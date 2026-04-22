using System.Drawing;

namespace FormCizimiDers;

public class Kutu
{
    protected string solUstKose = "╔",
        sagUstKose = "╗",
        solAltKose = "╚",
        sagAltKose = "╝",
        yatayKenar = "═",
        dikeyKenar = "║";

    public Size Boyut { get; set; }
    public Point Konum { get; set; }
    protected bool Cizgili { get; set; }
    public bool AktifOlabilir { get; protected set; }
    public bool AktifMi { get; protected set; }

    public virtual void Ciz()
    {
        Console.SetCursorPosition(Konum.X, Konum.Y);
        if (Cizgili)
        {
            for (int i = 0; i < Boyut.Height; i++)
            {
                for (int j = 0; j < Boyut.Width; j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write(solUstKose);
                    else if (i == 0 && j == Boyut.Width - 1)
                        Console.Write(sagUstKose);
                    else if (i == Boyut.Height - 1 && j == 0)
                        Console.Write(solAltKose);
                    else if (i == Boyut.Height - 1 && j == Boyut.Width - 1)
                        Console.Write(sagAltKose);
                    else if (j == 0 || j == Boyut.Width - 1)
                        Console.Write(dikeyKenar);
                    else if (i == 0 || i == Boyut.Height - 1)
                        Console.Write(yatayKenar);
                    else
                        Console.Write(' ');
                }

                Console.SetCursorPosition(Konum.X, Konum.Y + i + 1);
            }
        }
    }

    public virtual void Isle(ConsoleKeyInfo keyInfo)
    {
    }

    public virtual void AktifEt()
    {
        if (AktifOlabilir)
        {
            Console.SetCursorPosition(Konum.X + 1, Konum.Y + 1);
            AktifMi = true;
        }
    }

    public virtual void PasifEt()
    {
        AktifMi = false;
    }
}