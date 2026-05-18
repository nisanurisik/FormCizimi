using System.Drawing;

namespace FormCizimiDers;

public class StokForm : Form
{
    private MetinKutusu kutuStokKodu;
    private MetinKutusu kutuStokAdi;
    private MetinKutusu kutuBarkod;
    private MetinKutusu kutuBirimAdi;
    private MetinKutusu kutuAdet;
    private MetinKutusu kutuAlisFiyati;
    private MetinKutusu kutuSatisFiyati;
    private MetinKutusu kutuKdvOran;

    public StokForm()
    {
        kutuStokKodu = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 0)
        };

        kutuStokAdi = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 0)
        };

        kutuBarkod = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 4)
        };

        kutuBirimAdi = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 4)
        };

        kutuAdet = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 8)
        };

        kutuAlisFiyati = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 8)
        };

        kutuSatisFiyati = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 12)
        };

        kutuKdvOran = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 12)
        };

        var etiketStokKodu = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 0),
            Deger = "Stok Kodu"
        };

        var etiketStokAdi = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 0),
            Deger = "Stok Adı"
        };

        var etiketBarkod = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 4),
            Deger = "Barkod"
        };

        var etiketBirimAdi = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 4),
            Deger = "Birim Adı"
        };

        var etiketAdet = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 8),
            Deger = "Adet"
        };

        var etiketAlisFiyati = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 8),
            Deger = "Alış Fiyatı"
        };

        var etiketSatisFiyati = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 12),
            Deger = "Satış Fiyatı"
        };

        var etiketKdvOran = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 12),
            Deger = "KDV Oran"
        };

        var butonKaydet = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(6, 20),
            Deger = "Kaydet"
        };

        butonKaydet.IslemYap += KaydeteBasildi;

        var butonListele = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(24, 20),
            Deger = "Listele"
        };

        butonListele.IslemYap += ListeleyeBasildi;

        var butonStokGuncelle = new ButonKutusu()
        {
            Boyut = new Size(18, 3),
            Konum = new Point(42, 20),
            Deger = "Stok Güncelle"
        };

        butonStokGuncelle.IslemYap += StokGuncelleyeBasildi;

        var butonVazgec = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(64, 20),
            Deger = "Vazgeç"
        };

        butonVazgec.IslemYap += VazgeceBasildi;

        var butonAnaMenu = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(64, 24),
            Deger = "Ana Menü"
        };

        butonAnaMenu.IslemYap += AnaMenuyeDon;

        Kutular.Add(kutuStokKodu);
        Kutular.Add(etiketStokKodu);

        Kutular.Add(kutuStokAdi);
        Kutular.Add(etiketStokAdi);

        Kutular.Add(kutuBarkod);
        Kutular.Add(etiketBarkod);

        Kutular.Add(kutuBirimAdi);
        Kutular.Add(etiketBirimAdi);

        Kutular.Add(kutuAdet);
        Kutular.Add(etiketAdet);

        Kutular.Add(kutuAlisFiyati);
        Kutular.Add(etiketAlisFiyati);

        Kutular.Add(kutuSatisFiyati);
        Kutular.Add(etiketSatisFiyati);

        Kutular.Add(kutuKdvOran);
        Kutular.Add(etiketKdvOran);

        Kutular.Add(butonKaydet);
        Kutular.Add(butonListele);
        Kutular.Add(butonStokGuncelle);
        Kutular.Add(butonVazgec);
        Kutular.Add(butonAnaMenu);
    }

    public void KaydeteBasildi()
    {
        string dosyaYolu = "stoklar.txt";

        string kayit =
            "=====================================\n" +
            "Tarih : " + DateTime.Now + "\n" +
            "Stok Kodu : " + kutuStokKodu.Deger + "\n" +
            "Stok Adı : " + kutuStokAdi.Deger + "\n" +
            "Barkod : " + kutuBarkod.Deger + "\n" +
            "Birim Adı : " + kutuBirimAdi.Deger + "\n" +
            "Adet : " + kutuAdet.Deger + "\n" +
            "Alış Fiyatı : " + kutuAlisFiyati.Deger + "\n" +
            "Satış Fiyatı : " + kutuSatisFiyati.Deger + "\n" +
            "KDV Oran : " + kutuKdvOran.Deger + "\n" +
            "=====================================\n\n";

        File.AppendAllText(dosyaYolu, kayit);

        Console.SetCursorPosition(3, 27);
        Console.Write("Stok kaydı dosyaya yazıldı!");
    }

    public void ListeleyeBasildi()
    {
        Program.FormDegistir(new StokListele(this));
    }

    public void StokGuncelleyeBasildi()
    {
        Program.FormDegistir(new StokGuncelleme(this));
    }

    public void VazgeceBasildi()
    {
        kutuStokKodu.Deger = "";
        kutuStokAdi.Deger = "";
        kutuBarkod.Deger = "";
        kutuBirimAdi.Deger = "";
        kutuAdet.Deger = "";
        kutuAlisFiyati.Deger = "";
        kutuSatisFiyati.Deger = "";
        kutuKdvOran.Deger = "";

        Console.Clear();
        Goster();

        Console.SetCursorPosition(3, 27);
        Console.Write("Stok formu temizlendi.");
    }

    private void AnaMenuyeDon()
    {
        Program.FormDegistir(new AnaMenuForm());
    }
}