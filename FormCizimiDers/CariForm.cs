using System.Drawing;

namespace FormCizimiDers;

public class CariForm : Form
{
    private MetinKutusu kutuFirmaAdi;
    private MetinKutusu kutuFirmaVkn;
    private MetinKutusu kutuAdSoyad;
    private MetinKutusu kutuTelefon;
    private MetinKutusu kutuIl;
    private MetinKutusu kutuIlce;
    private MetinKutusu kutuAdres;
    private MetinKutusu kutuKategori;
    private MetinKutusu kutuBorc;
    private MetinKutusu kutuAlacak;

    public CariForm()
    {
        kutuAdSoyad = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(18, 0) };
        kutuTelefon = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(55, 0) };

        kutuFirmaAdi = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(18, 4) };
        kutuFirmaVkn = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(55, 4) };

        kutuBorc = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(18, 8) };
        kutuAlacak = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(55, 8) };

        kutuKategori = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(18, 12) };

        kutuIl = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(18, 16) };
        kutuIlce = new MetinKutusu() { Boyut = new Size(20, 3), Konum = new Point(55, 16) };

        kutuAdres = new MetinKutusu() { Boyut = new Size(57, 3), Konum = new Point(18, 20) };

        var etiketAdSoyad = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(3, 0), Deger = "Ad Soyad" };
        var etiketTelefon = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(42, 0), Deger = "Telefon" };

        var etiketFirmaAdi = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(3, 4), Deger = "Firma Adı" };
        var etiketFirmaVkn = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(42, 4), Deger = "Firma VKN" };

        var etiketBorc = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(3, 8), Deger = "Borç" };
        var etiketAlacak = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(42, 8), Deger = "Alacak" };

        var etiketKategori = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(3, 12), Deger = "Kategori" };

        var etiketIl = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(3, 16), Deger = "İl" };
        var etiketIlce = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(42, 16), Deger = "İlçe" };

        var etiketAdres = new EtiketKutusu() { Boyut = new Size(12, 3), Konum = new Point(3, 20), Deger = "Adres" };

        var butonKaydet = new ButonKutusu() { Boyut = new Size(14, 3), Konum = new Point(6, 24), Deger = "Kaydet" };
        butonKaydet.IslemYap += KaydeteBasildi;

        var butonListele = new ButonKutusu() { Boyut = new Size(14, 3), Konum = new Point(24, 24), Deger = "Listele" };
        butonListele.IslemYap += ListeleyeBasildi;

        var butonCariGuncelle = new ButonKutusu() { Boyut = new Size(18, 3), Konum = new Point(42, 24), Deger = "Cari Güncelle" };
        butonCariGuncelle.IslemYap += CariGuncelleyeBasildi;

        var butonVazgec = new ButonKutusu() { Boyut = new Size(14, 3), Konum = new Point(64, 24), Deger = "Vazgeç" };
        butonVazgec.IslemYap += VazgeceBasildi;

        Kutular.Add(kutuAdSoyad);
        Kutular.Add(etiketAdSoyad);

        Kutular.Add(kutuTelefon);
        Kutular.Add(etiketTelefon);

        Kutular.Add(kutuFirmaAdi);
        Kutular.Add(etiketFirmaAdi);

        Kutular.Add(kutuFirmaVkn);
        Kutular.Add(etiketFirmaVkn);

        Kutular.Add(kutuBorc);
        Kutular.Add(etiketBorc);

        Kutular.Add(kutuAlacak);
        Kutular.Add(etiketAlacak);

        Kutular.Add(kutuKategori);
        Kutular.Add(etiketKategori);

        Kutular.Add(kutuIl);
        Kutular.Add(etiketIl);

        Kutular.Add(kutuIlce);
        Kutular.Add(etiketIlce);

        Kutular.Add(kutuAdres);
        Kutular.Add(etiketAdres);

        Kutular.Add(butonKaydet);
        Kutular.Add(butonListele);
        Kutular.Add(butonCariGuncelle);
        Kutular.Add(butonVazgec);
    }

    public void KaydeteBasildi()
    {
        string dosyaYolu = "cariler.txt";

        string kayit =
            "=====================================\n" +
            "Tarih : " + DateTime.Now + "\n" +
            "Ad Soyad : " + kutuAdSoyad.Deger + "\n" +
            "Telefon : " + kutuTelefon.Deger + "\n" +
            "Firma Adı : " + kutuFirmaAdi.Deger + "\n" +
            "Firma VKN : " + kutuFirmaVkn.Deger + "\n" +
            "Borç : " + kutuBorc.Deger + "\n" +
            "Alacak : " + kutuAlacak.Deger + "\n" +
            "Kategori : " + kutuKategori.Deger + "\n" +
            "İl : " + kutuIl.Deger + "\n" +
            "İlçe : " + kutuIlce.Deger + "\n" +
            "Adres : " + kutuAdres.Deger + "\n" +
            "=====================================\n\n";

        File.AppendAllText(dosyaYolu, kayit);

        Console.SetCursorPosition(3, 27);
        Console.Write("Kayıt dosyaya yazıldı!");
    }

    public void ListeleyeBasildi()
    {
        Program.FormDegistir(new CariListele(this));
    }

    public void CariGuncelleyeBasildi()
    {
        Program.FormDegistir(new CariGuncelleme(this));
    }

    public void VazgeceBasildi()
    {
        kutuAdSoyad.Deger = "";
        kutuTelefon.Deger = "";
        kutuFirmaAdi.Deger = "";
        kutuFirmaVkn.Deger = "";
        kutuBorc.Deger = "";
        kutuAlacak.Deger = "";
        kutuKategori.Deger = "";
        kutuIl.Deger = "";
        kutuIlce.Deger = "";
        kutuAdres.Deger = "";

        Console.SetCursorPosition(3, 27);
        Console.Write("Form temizlendi.");
    }
}