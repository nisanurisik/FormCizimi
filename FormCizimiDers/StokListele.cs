namespace FormCizimiDers;

public class StokListele : Form
{
    private readonly Form oncekiForm;
    private readonly List<string[]> kayitlar;

    public StokListele(Form oncekiForm)
    {
        this.oncekiForm = oncekiForm;
        kayitlar = KayitlariOku();
    }

    public override void Goster()
    {
        base.Goster();
        KayitlariGoster();
    }

    public override void TusIsle(ConsoleKeyInfo info)
    {
        if (info.Key == ConsoleKey.Escape)
        {
            GeriDon();
            return;
        }

        base.TusIsle(info);
    }

    private List<string[]> KayitlariOku()
    {
        string dosyaYolu = "stoklar.txt";
        List<string[]> kayitListesi = new List<string[]>();

        if (!File.Exists(dosyaYolu))
            return kayitListesi;

        List<string> aktifKayit = new List<string>();

        foreach (string satir in File.ReadAllLines(dosyaYolu))
        {
            if (string.IsNullOrWhiteSpace(satir))
            {
                if (aktifKayit.Count > 0)
                {
                    kayitListesi.Add(aktifKayit.ToArray());
                    aktifKayit.Clear();
                }

                continue;
            }

            if (satir.StartsWith("===="))
                continue;

            aktifKayit.Add(satir);
        }

        if (aktifKayit.Count > 0)
        {
            kayitListesi.Add(aktifKayit.ToArray());
        }

        return kayitListesi;
    }

    private void KayitlariGoster()
    {
        TemizleIcerikAlani();

        Console.SetCursorPosition(3, 1);
        Console.Write("Stok Listeleme Ekranı");

        if (kayitlar.Count == 0)
        {
            Console.SetCursorPosition(3, 4);
            Console.Write("Kayıtlı stok bulunamadı.");

            Console.SetCursorPosition(3, 27);
            Console.Write("ESC ile geri dönebilirsiniz.");

            return;
        }

        int satir = 3;

        for (int i = 0; i < kayitlar.Count; i++)
        {
            if (satir >= 24)
                break;

            Console.SetCursorPosition(3, satir++);
            Console.Write($"--- {i + 1}. Kayıt ---");

            foreach (var alan in kayitlar[i])
            {
                if (satir >= 24)
                    break;

                Console.SetCursorPosition(5, satir++);
                Console.Write(alan);
            }

            satir++;
        }

        Console.SetCursorPosition(3, 27);
        Console.Write("ESC ile geri dönebilirsiniz.");
    }

    private void TemizleIcerikAlani()
    {
        for (int y = 1; y <= 25; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', 100));
        }
    }

    private void GeriDon()
    {
        Program.FormDegistir(oncekiForm);
    }
}