namespace FormCizimiDers;

class Program
{
    public static Form AktifForm { get; private set; }

    static void Main(string[] args)
    {
        FormDegistir(new AnaMenuForm());

        while (true)
        {
            AktifForm.TusIsle(Console.ReadKey(true));
        }
    }

    public static void FormDegistir(Form yeniForm)
    {
        AktifForm = yeniForm;
        Console.Clear();
        AktifForm.Goster();
    }
}