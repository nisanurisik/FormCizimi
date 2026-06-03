using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FormCizimiDers;

public class FisForm : Form
{
    private readonly string stokDosyaYolu = "stoklar.txt";
    private readonly string fisDosyaYolu = "fisler.txt";

    private MetinKutusu kutuFisNumarasi;
    private MetinKutusu kutuFisTarihi;
    private MetinKutusu kutuAciklama;

    private ButonKutusu butonYeniEkle;
    private ButonKutusu butonKaydet;
    private ButonKutusu butonVazgec;
    private ButonKutusu butonAnaMenu;

    private readonly List<FisStokSatiri> stokSatirlari = new List<FisStokSatiri>();

    public FisForm()
    {
        kutuFisNumarasi = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 0)
        };

        kutuFisTarihi = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 0)
        };

        kutuAciklama = new MetinKutusu()
        {
            Boyut = new Size(55, 3),
            Konum = new Point(18, 4)
        };

        kutuFisNumarasi.Deger = SiradakiFisNumarasiniOlustur();
        kutuFisTarihi.Deger = DateTime.Now.ToString("dd.MM.yyyy");

        var etiketFisNumarasi = new EtiketKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(2, 0),
            Deger = "Fiş Numarası"
        };

        var etiketFisTarihi = new EtiketKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(42, 0),
            Deger = "Fiş Tarihi"
        };

        var etiketAciklama = new EtiketKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(2, 4),
            Deger = "Açıklama"
        };

        var etiketStoklar = new EtiketKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(2, 8),
            Deger = "Stoklar"
        };

        var etiketCizgi1 = new EtiketKutusu()
        {
            Boyut = new Size(85, 1),
            Konum = new Point(2, 10),
            Deger = "------------------------------------------------------------"
        };

        butonYeniEkle = new ButonKutusu()
        {
            Boyut = new Size(18, 3),
            Konum = new Point(2, 12),
            Deger = "Yeni Ekle"
        };
        butonYeniEkle.IslemYap += YeniSatirEkle;

        var etiketStokKoduBaslik = new EtiketKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(2, 15),
            Deger = "Stok Kodu"
        };

        var etiketStokAdiBaslik = new EtiketKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(27, 15),
            Deger = "Stok Adı"
        };

        var etiketStokAdediBaslik = new EtiketKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(52, 15),
            Deger = "Stok Adedi"
        };

        var etiketCizgi2 = new EtiketKutusu()
        {
            Boyut = new Size(85, 1),
            Konum = new Point(2, 17),
            Deger = "------------------------------------------------------------"
        };

        butonKaydet = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(2, 25),
            Deger = "Kaydet"
        };
        butonKaydet.IslemYap += Kaydet;

        butonVazgec = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(20, 25),
            Deger = "Vazgeç"
        };
        butonVazgec.IslemYap += Vazgec;

        butonAnaMenu = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(38, 25),
            Deger = "Ana Menü"
        };
        butonAnaMenu.IslemYap += AnaMenuyeDon;

        Kutular.Add(etiketFisNumarasi);
        Kutular.Add(kutuFisNumarasi);

        Kutular.Add(etiketFisTarihi);
        Kutular.Add(kutuFisTarihi);

        Kutular.Add(etiketAciklama);
        Kutular.Add(kutuAciklama);

        Kutular.Add(etiketStoklar);
        Kutular.Add(etiketCizgi1);

        Kutular.Add(butonYeniEkle);

        Kutular.Add(etiketStokKoduBaslik);
        Kutular.Add(etiketStokAdiBaslik);
        Kutular.Add(etiketStokAdediBaslik);
        Kutular.Add(etiketCizgi2);

        IlkSatiriEkle();

        Kutular.Add(butonKaydet);
        Kutular.Add(butonVazgec);
        Kutular.Add(butonAnaMenu);
    }

    public override void TusIsle(ConsoleKeyInfo info)
    {
        if (info.Key == ConsoleKey.Escape)
        {
            AnaMenuyeDon();
            return;
        }

        base.TusIsle(info);

        StokKodlariniKontrolEt();

        AktifKutuImleciniDuzelt();
    }

    private void IlkSatiriEkle()
    {
        var satir = SatirOlustur(19);
        stokSatirlari.Add(satir);

        int kaydetIndex = Kutular.IndexOf(butonKaydet);

        if (kaydetIndex == -1)
        {
            Kutular.Add(satir.KutuStokKodu);
            Kutular.Add(satir.KutuStokAdi);
            Kutular.Add(satir.KutuStokAdedi);
        }
        else
        {
            Kutular.Insert(kaydetIndex, satir.KutuStokKodu);
            Kutular.Insert(kaydetIndex + 1, satir.KutuStokAdi);
            Kutular.Insert(kaydetIndex + 2, satir.KutuStokAdedi);
        }
    }

    private void YeniSatirEkle()
    {
        int yeniSatirY = 19 + (stokSatirlari.Count * 4);

        var satir = SatirOlustur(yeniSatirY);
        stokSatirlari.Add(satir);

        int kaydetIndex = Kutular.IndexOf(butonKaydet);

        if (kaydetIndex == -1)
        {
            Kutular.Add(satir.KutuStokKodu);
            Kutular.Add(satir.KutuStokAdi);
            Kutular.Add(satir.KutuStokAdedi);
        }
        else
        {
            Kutular.Insert(kaydetIndex, satir.KutuStokKodu);
            Kutular.Insert(kaydetIndex + 1, satir.KutuStokAdi);
            Kutular.Insert(kaydetIndex + 2, satir.KutuStokAdedi);
        }

        KaydetButonlariniAsagiAl();

        Console.Clear();
        Goster();

        AktifKutuImleciniDuzelt();

        MesajYaz("Yeni stok satırı eklendi.");
    }

    private FisStokSatiri SatirOlustur(int y)
    {
        return new FisStokSatiri()
        {
            KutuStokKodu = new MetinKutusu()
            {
                Boyut = new Size(24, 3),
                Konum = new Point(2, y)
            },
            KutuStokAdi = new MetinKutusu()
            {
                Boyut = new Size(24, 3),
                Konum = new Point(27, y)
            },
            KutuStokAdedi = new MetinKutusu()
            {
                Boyut = new Size(24, 3),
                Konum = new Point(52, y)
            }
        };
    }

    private void KaydetButonlariniAsagiAl()
    {
        int butonY = 25 + ((stokSatirlari.Count - 1) * 4);

        butonKaydet.Konum = new Point(2, butonY);
        butonVazgec.Konum = new Point(20, butonY);
        butonAnaMenu.Konum = new Point(38, butonY);
    }

    private void StokKodlariniKontrolEt()
    {
        foreach (var satir in stokSatirlari)
        {
            if (string.IsNullOrWhiteSpace(satir.KutuStokKodu.Deger))
            {
                if (!string.IsNullOrWhiteSpace(satir.KutuStokAdi.Deger))
                    satir.KutuStokAdi.Deger = "";

                if (!string.IsNullOrWhiteSpace(satir.KutuStokAdedi.Deger))
                    satir.KutuStokAdedi.Deger = "";

                satir.SonArananStokKodu = "";
                continue;
            }

            if (satir.SonArananStokKodu == satir.KutuStokKodu.Deger)
                continue;

            satir.SonArananStokKodu = satir.KutuStokKodu.Deger;

            var stok = StokBul(satir.KutuStokKodu.Deger);

            if (stok == null)
            {
                satir.KutuStokAdi.Deger = "";
                satir.KutuStokAdedi.Deger = "";
                MesajYaz("Stok bulunamadı.");
                continue;
            }

            satir.KutuStokAdi.Deger = stok.StokAdi;
            satir.KutuStokAdedi.Deger = stok.Adet;

            MesajYaz("Stok bilgileri getirildi.");
        }
    }

    private StokBilgisi? StokBul(string stokKodu)
    {
        if (!File.Exists(stokDosyaYolu))
            return null;

        List<string> aktifKayit = new List<string>();

        foreach (string satir in File.ReadAllLines(stokDosyaYolu))
        {
            if (string.IsNullOrWhiteSpace(satir))
            {
                var bulunanStok = KayitIcindekiStoguBul(aktifKayit, stokKodu);

                if (bulunanStok != null)
                    return bulunanStok;

                aktifKayit.Clear();
                continue;
            }

            if (satir.StartsWith("===="))
                continue;

            aktifKayit.Add(satir);
        }

        if (aktifKayit.Count > 0)
        {
            return KayitIcindekiStoguBul(aktifKayit, stokKodu);
        }

        return null;
    }

    private StokBilgisi? KayitIcindekiStoguBul(List<string> kayitSatirlari, string stokKodu)
    {
        string kayittakiStokKodu = DegeriBul(kayitSatirlari, "Stok Kodu");

        if (kayittakiStokKodu != stokKodu)
            return null;

        return new StokBilgisi()
        {
            StokKodu = kayittakiStokKodu,
            StokAdi = DegeriBul(kayitSatirlari, "Stok Adı"),
            Adet = DegeriBul(kayitSatirlari, "Adet")
        };
    }

    private string DegeriBul(List<string> kayitSatirlari, string alanAdi)
    {
        foreach (string satir in kayitSatirlari)
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

    private void Kaydet()
    {
        string kayit = "=====================================\n" +
                       "Tarih : " + DateTime.Now + "\n" +
                       "Fiş Numarası : " + kutuFisNumarasi.Deger + "\n" +
                       "Fiş Tarihi : " + kutuFisTarihi.Deger + "\n" +
                       "Açıklama : " + kutuAciklama.Deger + "\n" +
                       "Stoklar : \n";

        int sira = 1;

        foreach (var satir in stokSatirlari)
        {
            if (string.IsNullOrWhiteSpace(satir.KutuStokKodu.Deger))
                continue;

            kayit += "  " + sira + ". Stok Kodu : " + satir.KutuStokKodu.Deger + "\n" +
                     "  " + sira + ". Stok Adı : " + satir.KutuStokAdi.Deger + "\n" +
                     "  " + sira + ". Stok Adedi : " + satir.KutuStokAdedi.Deger + "\n";

            sira++;
        }

        kayit += "=====================================\n\n";

        File.AppendAllText(fisDosyaYolu, kayit);

        MesajYaz("Fiş kaydı dosyaya yazıldı.");
        AktifKutuImleciniDuzelt();
    }

    private void Vazgec()
    {
        kutuFisNumarasi.Deger = SiradakiFisNumarasiniOlustur();
        kutuFisTarihi.Deger = DateTime.Now.ToString("dd.MM.yyyy");
        kutuAciklama.Deger = "";

        foreach (var satir in stokSatirlari)
        {
            satir.KutuStokKodu.Deger = "";
            satir.KutuStokAdi.Deger = "";
            satir.KutuStokAdedi.Deger = "";
            satir.SonArananStokKodu = "";
        }

        Console.Clear();
        Goster();

        AktifKutuImleciniDuzelt();

        MesajYaz("Fiş formu temizlendi.");
    }

    private string SiradakiFisNumarasiniOlustur()
    {
        if (!File.Exists(fisDosyaYolu))
            return "";

        int fisSayisi = 0;

        foreach (string satir in File.ReadAllLines(fisDosyaYolu))
        {
            if (satir.StartsWith("Fiş Numarası"))
                fisSayisi++;
        }

        return "FIS" + (fisSayisi + 1).ToString("D5");
    }

    private void AnaMenuyeDon()
    {
        Program.FormDegistir(new AnaMenuForm());
    }

    private void AktifKutuImleciniDuzelt()
    {
        if (Kutular.Count > 0 && AktifKutu.AktifOlabilir)
        {
            AktifKutu.AktifEt();
        }
    }

    private void MesajYaz(string mesaj)
    {
        int mesajY = butonKaydet.Konum.Y + 4;

        Console.SetCursorPosition(3, mesajY);
        Console.Write(new string(' ', 90));
        Console.SetCursorPosition(3, mesajY);
        Console.Write(mesaj);
    }

    private class FisStokSatiri
    {
        public MetinKutusu KutuStokKodu { get; set; } = null!;
        public MetinKutusu KutuStokAdi { get; set; } = null!;
        public MetinKutusu KutuStokAdedi { get; set; } = null!;
        public string SonArananStokKodu { get; set; } = "";
    }

    private class StokBilgisi
    {
        public string StokKodu { get; set; } = "";
        public string StokAdi { get; set; } = "";
        public string Adet { get; set; } = "";
    }
}