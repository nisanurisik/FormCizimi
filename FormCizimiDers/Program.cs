namespace FormCizimiDers;

class Program
{
    public static Form AktifForm { get; private set; }

    private static Stack<Form> FormGecmisi = new Stack<Form>();

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
        if (AktifForm != null)
        {
            FormGecmisi.Push(AktifForm);
        }

        AktifForm = yeniForm;
        Console.Clear();
        AktifForm.Goster();
    }

    public static void OncekiFormaDon()
    {
        if (FormGecmisi.Count == 0)
            return;

        AktifForm = FormGecmisi.Pop();

        Console.Clear();
        AktifForm.Goster();
    }
} 