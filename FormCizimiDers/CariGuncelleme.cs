using System.Drawing;

namespace FormCizimiDers;

public class CariGuncelleme : Form
{
    private readonly Form oncekiForm;
    private readonly string dosyaYolu = "cariler.txt";

    private List<string[]> kayitlar = new List<string[]>();
    private bool duzenlemeModu = false;
    private int secilenKayitIndex = -1;

    private MetinKutusu kutuKayitNo;

    private MetinKutusu kutuFirmaAdi;
    private MetinKutusu kutuFirmaVkn;
    private MetinKutusu kutuAdSoyad;
    private MetinKutusu kutuTelefon;
    private MetinKutusu kutuIl;
    private MetinKutusu kutuIlce;
    private MetinKutusu kutuAdres;
    private MetinKutusu kutuKategori;

    public CariGuncelleme(Form oncekiForm)
    {
        this.oncekiForm = oncekiForm;
        kayitlar = KayitlariOku();
        SecimEkraniniHazirla();
    }

    public override void Goster()
    {
        base.Goster();

        if (duzenlemeModu)
            DuzenlemeBilgisiniYaz();
        else
            KayitlariListele();
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

    private void SecimEkraniniHazirla()
    {
        duzenlemeModu = false;
        Kutular.Clear();

        var etiketKayitNo = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 22),
            Deger = "Kayıt No"
        };

        kutuKayitNo = new MetinKutusu()
        {
            Boyut = new Size(10, 3),
            Konum = new Point(17, 22)
        };

        var butonSec = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(31, 22),
            Deger = "Seç"
        };
        butonSec.IslemYap += KayitSec;

        Kutular.Add(etiketKayitNo);
        Kutular.Add(kutuKayitNo);
        Kutular.Add(butonSec);
    }

    private void DuzenlemeEkraniniHazirla()
    {
        duzenlemeModu = true;
        Kutular.Clear();

        kutuAdSoyad = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 0)
        };
        kutuTelefon = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 0)
        };
        kutuFirmaAdi = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 4)
        };
        kutuFirmaVkn = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 4)
        };
        kutuKategori = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 8)
        };
        kutuIl = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 12)
        };
        kutuIlce = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 12)
        };
        kutuAdres = new MetinKutusu()
        {
            Boyut = new Size(57, 3),
            Konum = new Point(18, 16)
        };

        var etiketAdSoyad = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 0),
            Deger = "Ad Soyad"
        };
        var etiketTelefon = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 0),
            Deger = "Telefon"
        };
        var etiketFirmaAdi = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 4),
            Deger = "Firma Adı"
        };
        var etiketFirmaVkn = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 4),
            Deger = "Firma VKN"
        };
        var etiketKategori = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 8),
            Deger = "Kategori"
        };
        var etiketIl = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 12),
            Deger = "İl"
        };
        var etiketIlce = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(42, 12),
            Deger = "İlçe"
        };
        var etiketAdres = new EtiketKutusu()
        {
            Boyut = new Size(12, 3),
            Konum = new Point(3, 16),
            Deger = "Adres"
        };

        var butonGuncelle = new ButonKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(28, 22),
            Deger = "Güncelle"
        };
        butonGuncelle.IslemYap += Guncelle;

        Kutular.Add(kutuAdSoyad);
        Kutular.Add(etiketAdSoyad);

        Kutular.Add(kutuTelefon);
        Kutular.Add(etiketTelefon);

        Kutular.Add(kutuFirmaAdi);
        Kutular.Add(etiketFirmaAdi);

        Kutular.Add(kutuFirmaVkn);
        Kutular.Add(etiketFirmaVkn);

        Kutular.Add(kutuKategori);
        Kutular.Add(etiketKategori);

        Kutular.Add(kutuIl);
        Kutular.Add(etiketIl);

        Kutular.Add(kutuIlce);
        Kutular.Add(etiketIlce);

        Kutular.Add(kutuAdres);
        Kutular.Add(etiketAdres);

        Kutular.Add(butonGuncelle);
    }

    private void KayitSec()
    {
        if (kayitlar.Count == 0)
        {
            MesajYaz("Güncellenecek kayıt bulunamadı.");
            return;
        }

        if (!int.TryParse(kutuKayitNo.Deger, out int kayitNo))
        {
            MesajYaz("Geçerli bir kayıt numarası giriniz.");
            return;
        }

        if (kayitNo < 1 || kayitNo > kayitlar.Count)
        {
            MesajYaz("Kayıt numarası listede yok.");
            return;
        }

        secilenKayitIndex = kayitNo - 1;

        DuzenlemeEkraniniHazirla();
        SecilenKaydiKutularaYukle();

        Console.Clear();
        Goster();
    }

    private void SecilenKaydiKutularaYukle()
    {
        string[] kayit = kayitlar[secilenKayitIndex];

        kutuAdSoyad.Deger = DegeriBul(kayit, "Ad Soyad");
        kutuTelefon.Deger = DegeriBul(kayit, "Telefon");
        kutuFirmaAdi.Deger = DegeriBul(kayit, "Firma Adı");
        kutuFirmaVkn.Deger = DegeriBul(kayit, "Firma VKN");
        kutuKategori.Deger = DegeriBul(kayit, "Kategori");
        kutuIl.Deger = DegeriBul(kayit, "İl");
        kutuIlce.Deger = DegeriBul(kayit, "İlçe");
        kutuAdres.Deger = DegeriBul(kayit, "Adres");
    }

    private string DegeriBul(string[] kayit, string alanAdi)
    {
        foreach (string satir in kayit)
        {
            if (satir.StartsWith(alanAdi))
            {
                string[] parcalar = satir.Split(':');
                if (parcalar.Length >= 2)
                    return string.Join(":", parcalar.Skip(1)).Trim();
            }
        }

        return "";
    }

    private void Guncelle()
    {
        if (secilenKayitIndex < 0 || secilenKayitIndex >= kayitlar.Count)
        {
            MesajYaz("Önce kayıt seçmelisiniz.");
            return;
        }

        kayitlar[secilenKayitIndex] = new string[]
        {
            "Tarih      : " + DateTime.Now,
            "Ad Soyad   : " + kutuAdSoyad.Deger,
            "Telefon    : " + kutuTelefon.Deger,
            "Firma Adı  : " + kutuFirmaAdi.Deger,
            "Firma VKN  : " + kutuFirmaVkn.Deger,
            "Kategori   : " + kutuKategori.Deger,
            "İl         : " + kutuIl.Deger,
            "İlçe       : " + kutuIlce.Deger,
            "Adres      : " + kutuAdres.Deger
        };

        DosyayaTumKayitlariYaz();
        MesajYaz("Cari kaydı güncellendi!");
    }

    private void DosyayaTumKayitlariYaz()
    {
        List<string> tumSatirlar = new List<string>();

        foreach (var kayit in kayitlar)
        {
            tumSatirlar.Add("=====================================");
            tumSatirlar.AddRange(kayit);
            tumSatirlar.Add("=====================================");
            tumSatirlar.Add("");
        }

        File.WriteAllLines(dosyaYolu, tumSatirlar);
    }

    private List<string[]> KayitlariOku()
    {
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
            kayitListesi.Add(aktifKayit.ToArray());

        return kayitListesi;
    }

    private void KayitlariListele()
    {
        TemizleIcerikAlani();

        Console.SetCursorPosition(3, 1);
        Console.Write("Cari Güncelleme - Kayıt Seçim Ekranı");

        if (kayitlar.Count == 0)
        {
            Console.SetCursorPosition(3, 4);
            Console.Write("Kayıtlı cari bulunamadı.");
            MesajYaz("ESC ile geri dönebilirsiniz.");
            return;
        }

        int satir = 3;

        for (int i = 0; i < kayitlar.Count; i++)
        {
            Console.SetCursorPosition(3, satir++);
            Console.Write($"--- {i + 1}. Kayıt ---");

            foreach (var alan in kayitlar[i])
            {
                if (satir >= 20)
                    break;

                Console.SetCursorPosition(5, satir++);
                Console.Write(alan);
            }

            satir++;

            if (satir >= 20)
                break;
        }

        MesajYaz("Kayıt no girip Seç butonuna basınız.");
    }

    private void DuzenlemeBilgisiniYaz()
    {
        MesajYaz("Bilgileri değiştirip Güncelle butonuna basınız.");
    }

    private void TemizleIcerikAlani()
    {
        for (int y = 1; y <= 20; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', 100));
        }
    }

    private void MesajYaz(string mesaj)
    {
        Console.SetCursorPosition(3, 27);
        Console.Write(new string(' ', 90));
        Console.SetCursorPosition(3, 27);
        Console.Write(mesaj);
    }

    private void GeriDon()
    {
        Program.FormDegistir(oncekiForm);
    }
}