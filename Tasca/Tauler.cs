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
        for (int i = 0; i < 15; i++)
        {
            Habitants.Add(new Pop { X = 0, Y = r.Next(Mida) });
        }
        for (int i = 0; i < 10; i++)
        {
            Habitants.Add(new Tauro { X = r.Next(Mida), Y = r.Next(Mida), Sexe = 'M' });
            Habitants.Add(new Tauro { X = r.Next(Mida), Y = r.Next(Mida), Sexe = 'F' });
        }
        for (int i = 0; i < 6; i++)
        {
            Habitants.Add(new Tortuga { X = r.Next(Mida), Y = r.Next(Mida), Sexe = 'M', DirX = 1, DirY = 0 });
            Habitants.Add(new Tortuga { X = r.Next(Mida), Y = r.Next(Mida), Sexe = 'F', DirX = 0, DirY = 1 });
        }
    }
    public void FerForaElsMorts()
    {
        Habitants.RemoveAll(a => !a.Viu);
    }

}
