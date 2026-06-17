using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FormCizimiDers;

public class CariFisForm : Form
{
    private readonly string cariDosyaYolu = "cariler.txt";
    private readonly string cariFisDosyaYolu = "carifisler.txt";

    private MetinKutusu kutuFisNumarasi;
    private MetinKutusu kutuFisTarihi;
    private MetinKutusu kutuAciklama;

    private MetinKutusu kutuCariKodu;
    private MetinKutusu kutuCariAdi;
    private MetinKutusu kutuMevcutBorc;
    private MetinKutusu kutuMevcutAlacak;

    private MetinKutusu kutuIslemTuru;
    private MetinKutusu kutuTutar;

    private ButonKutusu butonKaydet;
    private ButonKutusu butonVazgec;
    private ButonKutusu butonGeri;
    private ButonKutusu butonAnaMenu;

    private string sonArananCariKodu = "";

    public CariFisForm()
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

        kutuCariKodu = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 9)
        };

        kutuCariAdi = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 9)
        };

        kutuMevcutBorc = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 13)
        };

        kutuMevcutAlacak = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 13)
        };

        kutuIslemTuru = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(18, 18)
        };

        kutuTutar = new MetinKutusu()
        {
            Boyut = new Size(20, 3),
            Konum = new Point(55, 18)
        };

        kutuFisNumarasi.Deger = SiradakiCariFisNumarasiniOlustur();
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

        var etiketCizgi1 = new EtiketKutusu()
        {
            Boyut = new Size(85, 1),
            Konum = new Point(2, 7),
            Deger = "------------------------------------------------------------"
        };

        var etiketCariKodu = new EtiketKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(2, 9),
            Deger = "Cari Kodu"
        };

        var etiketCariAdi = new EtiketKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(42, 9),
            Deger = "Cari Adı"
        };

        var etiketMevcutBorc = new EtiketKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(2, 13),
            Deger = "Mevcut Borç"
        };

        var etiketMevcutAlacak = new EtiketKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(42, 13),
            Deger = "Mevcut Alacak"
        };

        var etiketCizgi2 = new EtiketKutusu()
        {
            Boyut = new Size(85, 1),
            Konum = new Point(2, 16),
            Deger = "------------------------------------------------------------"
        };

        var etiketIslemTuru = new EtiketKutusu()
        {
            Boyut = new Size(16, 3),
            Konum = new Point(2, 18),
            Deger = "İşlem A/B"
        };

        var etiketTutar = new EtiketKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(42, 18),
            Deger = "Tutar"
        };

        var etiketBilgi = new EtiketKutusu()
        {
            Boyut = new Size(70, 3),
            Konum = new Point(2, 21),
            Deger = "A: Alacak düşürür   B: Borç düşürür"
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

        butonGeri = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(38, 25),
            Deger = "Geri"
        };

        butonGeri.IslemYap += GeriDon;

        butonAnaMenu = new ButonKutusu()
        {
            Boyut = new Size(14, 3),
            Konum = new Point(56, 25),
            Deger = "Ana Menü"
        };

        butonAnaMenu.IslemYap += AnaMenuyeDon;

        Kutular.Add(etiketFisNumarasi);
        Kutular.Add(kutuFisNumarasi);

        Kutular.Add(etiketFisTarihi);
        Kutular.Add(kutuFisTarihi);

        Kutular.Add(etiketAciklama);
        Kutular.Add(kutuAciklama);

        Kutular.Add(etiketCizgi1);

        Kutular.Add(etiketCariKodu);
        Kutular.Add(kutuCariKodu);

        Kutular.Add(etiketCariAdi);
        Kutular.Add(kutuCariAdi);

        Kutular.Add(etiketMevcutBorc);
        Kutular.Add(kutuMevcutBorc);

        Kutular.Add(etiketMevcutAlacak);
        Kutular.Add(kutuMevcutAlacak);

        Kutular.Add(etiketCizgi2);

        Kutular.Add(etiketIslemTuru);
        Kutular.Add(kutuIslemTuru);

        Kutular.Add(etiketTutar);
        Kutular.Add(kutuTutar);

        Kutular.Add(etiketBilgi);

        Kutular.Add(butonKaydet);
        Kutular.Add(butonVazgec);
        Kutular.Add(butonGeri);
        Kutular.Add(butonAnaMenu);
    }

    public override void TusIsle(ConsoleKeyInfo info)
    {
        if (info.Key == ConsoleKey.Escape)
        {
            GeriDon();
            return;
        }

        base.TusIsle(info);

        OtomatikAlanlariAtla(info);
        CariKodunuKontrolEt();
        AktifKutuImleciniDuzelt();
    }

    private void OtomatikAlanlariAtla(ConsoleKeyInfo info)
    {
        if (info.Key != ConsoleKey.Tab && info.Key != ConsoleKey.Enter)
            return;

        while (AktifKutu == kutuCariAdi ||
               AktifKutu == kutuMevcutBorc ||
               AktifKutu == kutuMevcutAlacak)
        {
            base.TusIsle(new ConsoleKeyInfo('\t', ConsoleKey.Tab, false, false, false));
        }
    }

    private void CariKodunuKontrolEt()
    {
        if (string.IsNullOrWhiteSpace(kutuCariKodu.Deger))
        {
            kutuCariAdi.Deger = "";
            kutuMevcutBorc.Deger = "";
            kutuMevcutAlacak.Deger = "";
            sonArananCariKodu = "";
            MesajYaz("");
            return;
        }

        if (sonArananCariKodu == kutuCariKodu.Deger)
            return;

        sonArananCariKodu = kutuCariKodu.Deger;

        var cari = CariBul(kutuCariKodu.Deger);

        if (cari == null)
        {
            kutuCariAdi.Deger = "";
            kutuMevcutBorc.Deger = "";
            kutuMevcutAlacak.Deger = "";
            MesajYaz("Cari bulunamadı.");
            return;
        }

        kutuCariAdi.Deger = cari.AdSoyad;
        kutuMevcutBorc.Deger = cari.Borc;
        kutuMevcutAlacak.Deger = cari.Alacak;

        MesajYaz("Cari bilgileri getirildi.");
    }

    private CariBilgisi? CariBul(string cariKodu)
    {
        if (!File.Exists(cariDosyaYolu))
            return null;

        List<string> aktifKayit = new List<string>();

        foreach (string satir in File.ReadAllLines(cariDosyaYolu))
        {
            if (string.IsNullOrWhiteSpace(satir))
            {
                var bulunanCari = KayitIcindekiCariyiBul(aktifKayit, cariKodu);

                if (bulunanCari != null)
                    return bulunanCari;

                aktifKayit.Clear();
                continue;
            }

            if (satir.StartsWith("===="))
                continue;

            aktifKayit.Add(satir);
        }

        if (aktifKayit.Count > 0)
            return KayitIcindekiCariyiBul(aktifKayit, cariKodu);

        return null;
    }

    private CariBilgisi? KayitIcindekiCariyiBul(List<string> kayitSatirlari, string cariKodu)
    {
        string kayittakiCariKodu = DegeriBul(kayitSatirlari, "Cari Kodu");

        if (string.IsNullOrWhiteSpace(kayittakiCariKodu))
            kayittakiCariKodu = DegeriBul(kayitSatirlari, "Firma VKN");

        if (kayittakiCariKodu != cariKodu)
            return null;

        return new CariBilgisi()
        {
            CariKodu = kayittakiCariKodu,
            AdSoyad = DegeriBul(kayitSatirlari, "Ad Soyad"),
            FirmaAdi = DegeriBul(kayitSatirlari, "Firma Adı"),
            Borc = DegeriBul(kayitSatirlari, "Borç"),
            Alacak = DegeriBul(kayitSatirlari, "Alacak")
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
        CariKodunuKontrolEt();

        if (string.IsNullOrWhiteSpace(kutuFisNumarasi.Deger))
        {
            MesajYaz("Fiş numarası boş olamaz.");
            return;
        }

        if (string.IsNullOrWhiteSpace(kutuFisTarihi.Deger))
        {
            MesajYaz("Fiş tarihi boş olamaz.");
            return;
        }

        if (string.IsNullOrWhiteSpace(kutuCariKodu.Deger))
        {
            MesajYaz("Cari kodu boş olamaz.");
            return;
        }

        var cari = CariBul(kutuCariKodu.Deger);

        if (cari == null)
        {
            MesajYaz("Cari bulunamadı.");
            return;
        }

        string islemTuru = kutuIslemTuru.Deger.Trim().ToUpper();

        if (islemTuru != "A" && islemTuru != "B")
        {
            MesajYaz("İşlem türü için A veya B giriniz.");
            return;
        }

        if (!DecimalDegereCevir(kutuTutar.Deger, out decimal tutar) || tutar <= 0)
        {
            MesajYaz("Geçerli bir tutar giriniz.");
            return;
        }

        decimal mevcutBorc = DecimalDegereCevir(cari.Borc);
        decimal mevcutAlacak = DecimalDegereCevir(cari.Alacak);

        decimal yeniBorc = mevcutBorc;
        decimal yeniAlacak = mevcutAlacak;

        string islemAciklama;

        if (islemTuru == "A")
        {
            if (tutar > mevcutAlacak)
            {
                MesajYaz("Tutar mevcut alacaktan büyük olamaz.");
                return;
            }

            yeniAlacak = mevcutAlacak - tutar;
            islemAciklama = "Alacak düşürüldü";
        }
        else
        {
            if (tutar > mevcutBorc)
            {
                MesajYaz("Tutar mevcut borçtan büyük olamaz.");
                return;
            }

            yeniBorc = mevcutBorc - tutar;
            islemAciklama = "Borç düşürüldü";
        }

        bool cariGuncellendi = CariDosyasiniGuncelle(
            kutuCariKodu.Deger,
            yeniBorc,
            yeniAlacak
        );

        if (!cariGuncellendi)
        {
            MesajYaz("Cari dosyası güncellenemedi.");
            return;
        }

        string fisKaydi =
            "=====================================\n" +
            "Tarih : " + DateTime.Now + "\n" +
            "Fiş Numarası : " + kutuFisNumarasi.Deger + "\n" +
            "Fiş Tarihi : " + kutuFisTarihi.Deger + "\n" +
            "Açıklama : " + kutuAciklama.Deger + "\n" +
            "Cari Kodu : " + kutuCariKodu.Deger + "\n" +
            "Cari Adı : " + kutuCariAdi.Deger + "\n" +
            "İşlem Türü : " + islemAciklama + "\n" +
            "Tutar : " + DecimalYaz(tutar) + "\n" +
            "Eski Borç : " + DecimalYaz(mevcutBorc) + "\n" +
            "Yeni Borç : " + DecimalYaz(yeniBorc) + "\n" +
            "Eski Alacak : " + DecimalYaz(mevcutAlacak) + "\n" +
            "Yeni Alacak : " + DecimalYaz(yeniAlacak) + "\n" +
            "=====================================\n\n";

        File.AppendAllText(cariFisDosyaYolu, fisKaydi);

        kutuMevcutBorc.Deger = DecimalYaz(yeniBorc);
        kutuMevcutAlacak.Deger = DecimalYaz(yeniAlacak);

        kutuIslemTuru.Deger = "";
        kutuTutar.Deger = "";

        sonArananCariKodu = "";

        Console.Clear();
        Goster();

        kutuCariAdi.Deger = cari.AdSoyad;
        kutuMevcutBorc.Deger = DecimalYaz(yeniBorc);
        kutuMevcutAlacak.Deger = DecimalYaz(yeniAlacak);

        MesajYaz("Cari fiş kaydedildi. Cari borç/alacak bilgisi güncellendi.");
        AktifKutuImleciniDuzelt();
    }

    private bool CariDosyasiniGuncelle(string cariKodu, decimal yeniBorc, decimal yeniAlacak)
    {
        if (!File.Exists(cariDosyaYolu))
            return false;

        List<string> tumSatirlar = File.ReadAllLines(cariDosyaYolu).ToList();

        List<string> yeniSatirlar = new List<string>();
        List<string> aktifKayit = new List<string>();

        bool kayitBulundu = false;

        foreach (string satir in tumSatirlar)
        {
            if (string.IsNullOrWhiteSpace(satir))
            {
                if (KaydiGuncelleyipEkle(yeniSatirlar, aktifKayit, cariKodu, yeniBorc, yeniAlacak))
                    kayitBulundu = true;

                yeniSatirlar.Add(satir);
                aktifKayit.Clear();
                continue;
            }

            aktifKayit.Add(satir);
        }

        if (aktifKayit.Count > 0)
        {
            if (KaydiGuncelleyipEkle(yeniSatirlar, aktifKayit, cariKodu, yeniBorc, yeniAlacak))
                kayitBulundu = true;
        }

        if (!kayitBulundu)
            return false;

        File.WriteAllLines(cariDosyaYolu, yeniSatirlar);

        return true;
    }

    private bool KaydiGuncelleyipEkle(
        List<string> yeniSatirlar,
        List<string> aktifKayit,
        string cariKodu,
        decimal yeniBorc,
        decimal yeniAlacak)
    {
        string kayittakiCariKodu = DegeriBul(aktifKayit, "Cari Kodu");

        if (string.IsNullOrWhiteSpace(kayittakiCariKodu))
            kayittakiCariKodu = DegeriBul(aktifKayit, "Firma VKN");

        bool buKayitGuncellendi = kayittakiCariKodu == cariKodu;

        if (buKayitGuncellendi)
        {
            for (int i = 0; i < aktifKayit.Count; i++)
            {
                if (aktifKayit[i].StartsWith("Borç"))
                    aktifKayit[i] = "Borç : " + DecimalYaz(yeniBorc);

                if (aktifKayit[i].StartsWith("Alacak"))
                    aktifKayit[i] = "Alacak : " + DecimalYaz(yeniAlacak);
            }
        }

        foreach (string kayitSatiri in aktifKayit)
            yeniSatirlar.Add(kayitSatiri);

        return buKayitGuncellendi;
    }

    private bool DecimalDegereCevir(string deger, out decimal sonuc)
    {
        deger = deger.Trim();

        if (decimal.TryParse(deger, NumberStyles.Any, new CultureInfo("tr-TR"), out sonuc))
            return true;

        if (decimal.TryParse(deger, NumberStyles.Any, CultureInfo.InvariantCulture, out sonuc))
            return true;

        sonuc = 0;
        return false;
    }

    private decimal DecimalDegereCevir(string deger)
    {
        if (DecimalDegereCevir(deger, out decimal sonuc))
            return sonuc;

        return 0;
    }

    private string DecimalYaz(decimal deger)
    {
        return deger.ToString("0.##", new CultureInfo("tr-TR"));
    }

    private void Vazgec()
    {
        kutuFisNumarasi.Deger = SiradakiCariFisNumarasiniOlustur();
        kutuFisTarihi.Deger = DateTime.Now.ToString("dd.MM.yyyy");
        kutuAciklama.Deger = "";

        kutuCariKodu.Deger = "";
        kutuCariAdi.Deger = "";
        kutuMevcutBorc.Deger = "";
        kutuMevcutAlacak.Deger = "";

        kutuIslemTuru.Deger = "";
        kutuTutar.Deger = "";

        sonArananCariKodu = "";

        Console.Clear();
        Goster();
        AktifKutuImleciniDuzelt();
        MesajYaz("Cari fiş formu temizlendi.");
    }

    private string SiradakiCariFisNumarasiniOlustur()
    {
        if (!File.Exists(cariFisDosyaYolu))
            return "";

        int fisSayisi = 0;

        foreach (string satir in File.ReadAllLines(cariFisDosyaYolu))
        {
            if (satir.StartsWith("Fiş Numarası"))
                fisSayisi++;
        }

        return "CARIFIS" + (fisSayisi + 1).ToString("D5");
    }

    private void GeriDon()
    {
        Program.FormDegistir(new FisIslemleriForm());
    }

    private void AnaMenuyeDon()
    {
        Program.FormDegistir(new AnaMenuForm());
    }

    private void AktifKutuImleciniDuzelt()
    {
        if (Kutular.Count > 0 && AktifKutu.AktifOlabilir)
            AktifKutu.AktifEt();
    }

    private void MesajYaz(string mesaj)
    {
        Console.SetCursorPosition(3, 29);
        Console.Write(new string(' ', 90));
        Console.SetCursorPosition(3, 29);
        Console.Write(mesaj);
    }

    private class CariBilgisi
    {
        public string CariKodu { get; set; } = "";
        public string AdSoyad { get; set; } = "";
        public string FirmaAdi { get; set; } = "";
        public string Borc { get; set; } = "";
        public string Alacak { get; set; } = "";
    }
}