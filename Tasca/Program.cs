namespace Tasca;

internal class Program
{
    static void Main(string[] args)
{
    Tauler t = new Tauler();
    t.Inicialitzar();

    for (int ronda = 0; ronda < 100; ronda++)
    {
        t.FerRonda();
    }

    t.Finalitzar();
}
}