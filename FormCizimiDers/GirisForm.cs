using System.Drawing;

namespace FormCizimiDers;

public class GirisForm : Form
{
    public GirisForm()
    {
        Kutular = new List<Kutu>
        {
            new MetinKutusu
            {
                Boyut = new Size(20, 3),
                Konum = new Point(40, 10)
            },
            new EtiketKutusu
            {
                Boyut = new Size(20, 3),
                Konum = new Point(20, 10),
                Deger = "Kullanıcı Adı",
            },
            new MetinKutusu
            {
                Boyut = new Size(20, 3),
                Konum = new Point(40, 14)
            },
            new EtiketKutusu
            {
                Boyut = new Size(20, 3),
                Konum = new Point(20, 14),
                Deger = "Şifre",
            }
        };
    }
}