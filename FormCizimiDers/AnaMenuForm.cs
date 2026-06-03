using System.Drawing;

namespace FormCizimiDers;

public class AnaMenuForm : Form
{
    public AnaMenuForm()
    {
        var etiketBaslik = new EtiketKutusu()
        {
            Boyut = new Size(40, 3),
            Konum = new Point(25, 5),
            Deger = "İşlem Menüsü"
        };

        var butonCari = new ButonKutusu()
        {
            Boyut = new Size(24, 3),
            Konum = new Point(28, 10),
            Deger = "Cari İşlemleri"
        };
        butonCari.IslemYap += CariIslemleriAc;

        var butonStok = new ButonKutusu()
        {
            Boyut = new Size(24, 3),
            Konum = new Point(28, 15),
            Deger = "Stok İşlemleri"
        };
        butonStok.IslemYap += StokIslemleriAc;

        var butonFis = new ButonKutusu()
        {
            Boyut = new Size(24, 3),
            Konum = new Point(28, 20),
            Deger = "Fiş İşlemleri"
        };
        butonFis.IslemYap += FisIslemleriAc;

        Kutular.Add(etiketBaslik);
        Kutular.Add(butonCari);
        Kutular.Add(butonStok);
        Kutular.Add(butonFis);
    }

    private void CariIslemleriAc()
    {
        Program.FormDegistir(new CariForm());
    }

    private void StokIslemleriAc()
    {
        Program.FormDegistir(new StokForm());
    }

    private void FisIslemleriAc()
    {
        Program.FormDegistir(new FisForm());
    }
}