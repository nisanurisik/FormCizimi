namespace FormCizimiDers;

public class Form
{
    public List<Kutu> Kutular { get; set; }
    private int aktifKutuIndex = 0;

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

        if (Kutular.Count > 0 && AktifKutu.AktifOlabilir)
        {
            AktifKutu.AktifEt();
        }
    }

    public virtual void TusIsle(ConsoleKeyInfo info)
    {
        if (Kutular.Count == 0)
            return;

        if (info.Key == ConsoleKey.Tab || info.Key == ConsoleKey.Enter)
        {
            var eskiKutu = Kutular[aktifKutuIndex];
            while (true)
            {
                aktifKutuIndex = (aktifKutuIndex + 1) % Kutular.Count;
                if (AktifKutu.AktifOlabilir)
                {
                    eskiKutu.PasifEt();
                    AktifKutu.AktifEt();
                    break;
                }
            }
        }
        else
        {
            AktifKutu.Isle(info);
        }
    }
}