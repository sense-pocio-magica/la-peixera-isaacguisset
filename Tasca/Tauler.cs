namespace Tasca;

public class Tauler
{
    public List<Animal> Habitants { get; set; } = new List<Animal>();
    public int Mida { get; set; } = 20;

    public void Inicialitzar()
    {
        Random r = new Random();
        //peixos
        for (int i = 0; i < 50; i++)
        {
            Habitants.Add(new Peix(r.Next(Mida), r.Next(Mida), r.Next(-1, 2), r.Next(-1, 2), 'M'));
            Habitants.Add(new Peix(r.Next(Mida), r.Next(Mida), r.Next(-1, 2), r.Next(-1, 2), 'F'));
        }
    }
    public void FerForaElsMorts()
    {
        Habitants.RemoveAll(a => !a.Viu);
    }

}
