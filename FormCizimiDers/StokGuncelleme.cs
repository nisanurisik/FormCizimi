using System.Drawing;

namespace FormCizimiDers;

public class StokGuncelleme : Form
{
    private readonly Form oncekiForm;
    private readonly string dosyaYolu = "stoklar.txt";

    private List<string[]> kayitlar = new List<string[]>();

    private bool duzenlemeModu = false;
    private int secilenKayitIndex = -1;

    private MetinKutusu kutuKayitNo;

    private MetinKutusu kutuStokKodu;
    private MetinKutusu kutuStokAdi;
    private MetinKutusu kutuBarkod;
    private MetinKutusu kutuBirimAdi;
    private MetinKutusu kutuAdet;
    private MetinKutusu kutuAlisFiyati;
    private MetinKutusu kutuSatisFiyati;
    private MetinKutusu kutuKdvOran;

    public StokGuncelleme(Form oncekiForm)
    {
        this.oncekiForm = oncekiForm;
        kayitlar = KayitlariOku();
        SecimEkraniniHazirla();
    }

    public override void Goster()
    {
        if (duzenlemeModu)
        {
            base.Goster();
            DuzenlemeBilgisiniYaz();
        }
        else
        {
            KayitlariListele();
            base.Goster();
        }
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

        var butonGuncelle = new ButonKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(28, 20),
            Deger = "Güncelle"
        };

        butonGuncelle.IslemYap += Guncelle;

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

        Kutular.Add(butonGuncelle);
    }

    private void KayitSec()
    {
        if (kayitlar.Count == 0)
        {
            MesajYaz("Güncellenecek stok kaydı bulunamadı.");
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

        kutuStokKodu.Deger = DegeriBul(kayit, "Stok Kodu");
        kutuStokAdi.Deger = DegeriBul(kayit, "Stok Adı");
        kutuBarkod.Deger = DegeriBul(kayit, "Barkod");
        kutuBirimAdi.Deger = DegeriBul(kayit, "Birim Adı");
        kutuAdet.Deger = DegeriBul(kayit, "Adet");
        kutuAlisFiyati.Deger = DegeriBul(kayit, "Alış Fiyatı");
        kutuSatisFiyati.Deger = DegeriBul(kayit, "Satış Fiyatı");
        kutuKdvOran.Deger = DegeriBul(kayit, "KDV Oran");
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
            "Tarih : " + DateTime.Now,
            "Stok Kodu : " + kutuStokKodu.Deger,
            "Stok Adı : " + kutuStokAdi.Deger,
            "Barkod : " + kutuBarkod.Deger,
            "Birim Adı : " + kutuBirimAdi.Deger,
            "Adet : " + kutuAdet.Deger,
            "Alış Fiyatı : " + kutuAlisFiyati.Deger,
            "Satış Fiyatı : " + kutuSatisFiyati.Deger,
            "KDV Oran : " + kutuKdvOran.Deger
        };

        DosyayaTumKayitlariYaz();

        MesajYaz("Stok kaydı güncellendi!");
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
        Console.Write("Stok Güncelleme - Kayıt Seçim Ekranı");

        if (kayitlar.Count == 0)
        {
            Console.SetCursorPosition(3, 4);
            Console.Write("Kayıtlı stok bulunamadı.");

            MesajYaz("ESC ile geri dönebilirsiniz.");
            return;
        }

        int satir = 3;

        for (int i = 0; i < kayitlar.Count; i++)
        {
            if (satir >= 19)
                break;

            Console.SetCursorPosition(3, satir++);
            Console.Write($"--- {i + 1}. Kayıt ---");

            foreach (var alan in kayitlar[i])
            {
                if (satir >= 19)
                    break;

                Console.SetCursorPosition(5, satir++);
                Console.Write(alan);
            }

            satir++;
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