using System.Drawing;

namespace FormCizimiDers;

public class FisIslemleriForm : Form
{
    public FisIslemleriForm()
    {
        var etiketBaslik = new EtiketKutusu()
        {
            Boyut = new Size(40, 3),
            Konum = new Point(25, 5),
            Deger = "Fiş İşlemleri"
        };

        var butonCariFis = new ButonKutusu()
        {
            Boyut = new Size(28, 3),
            Konum = new Point(26, 11),
            Deger = "Cari Fiş İşlemleri"
        };

        butonCariFis.IslemYap += CariFisIslemleriAc;

        var butonStokFis = new ButonKutusu()
        {
            Boyut = new Size(28, 3),
            Konum = new Point(26, 16),
            Deger = "Stok Fiş İşlemleri"
        };

        butonStokFis.IslemYap += StokFisIslemleriAc;

        var butonAnaMenu = new ButonKutusu()
        {
            Boyut = new Size(28, 3),
            Konum = new Point(26, 21),
            Deger = "Ana Menü"
        };

        butonAnaMenu.IslemYap += AnaMenuyeDon;

        Kutular.Add(etiketBaslik);
        Kutular.Add(butonCariFis);
        Kutular.Add(butonStokFis);
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
    }

    private void CariFisIslemleriAc()
    {
        Program.FormDegistir(new CariFisForm());
    }

    private void StokFisIslemleriAc()
    {
        Program.FormDegistir(new StokFis());
    }

    private void AnaMenuyeDon()
    {
        Program.FormDegistir(new AnaMenuForm());
    }
}