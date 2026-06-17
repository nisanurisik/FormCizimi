namespace FormCizimiDers;

public class Form
{
    public List<Kutu> Kutular { get; set; }

    protected int aktifKutuIndex = 0;

    public Kutu AktifKutu
    {
        get { return Kutular[aktifKutuIndex]; }
    }

    public Form()
    {
        Kutular = new List<Kutu>();
    }

    public virtual void Goster()
    {
        foreach (var kutu in Kutular)
        {
            kutu.Ciz();
        }

        if (Kutular.Count > 0)
        {
            AktifKutu.AktifEt();
        }
    }

    public virtual void TusIsle(ConsoleKeyInfo info)
    {
        if (info.Key == ConsoleKey.Tab && info.Modifiers.HasFlag(ConsoleModifiers.Shift))
        {
            Program.OncekiFormaDon();
            return;
        }

        if (info.Key == ConsoleKey.Tab || info.Key == ConsoleKey.Enter)
        {
            AktifKutu.PasifEt();

            do
            {
                aktifKutuIndex++;

                if (aktifKutuIndex >= Kutular.Count)
                    aktifKutuIndex = 0;

            } while (!AktifKutu.AktifOlabilir);

            AktifKutu.AktifEt();
        }
        else
        {
            AktifKutu.Isle(info);
        }
    }
}