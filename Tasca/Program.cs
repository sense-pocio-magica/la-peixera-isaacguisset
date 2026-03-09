namespace Tasca;

internal class Program
{
    static void Main(string[] args)
    {
        //es similar al que vam fer amb el de la vida regalada en quan a tauler i caselles
        Tauler t = new Tauler();
        t.Inicialitzar();

        for (int ronda = 0; ronda < 100; ronda++)
        {
            Console.WriteLine($"INICI DE LA RONDA {ronda + 1}");

            t.FerRonda();
            Console.WriteLine("-----------------------------------------------------------");
        }
        t.Finalitzar();
    }
}