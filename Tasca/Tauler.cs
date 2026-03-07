namespace Tasca;

public class Tauler
{
    public List<Animal> Habitants { get; set; } = new List<Animal>();
    public int Mida { get; set; } = 20;

    public void Inicialitzar()
    {
        //peixos
        for (int i = 0; i < 50; i++)
        {
            Habitants.Add(new Peix(Aleat.Random.Next(Mida), Aleat.Random.Next(Mida), Aleat.Random.Next(-1, 2), Aleat.Random.Next(-1, 2), 'M'));
            Habitants.Add(new Peix(Aleat.Random.Next(Mida), Aleat.Random.Next(Mida), Aleat.Random.Next(-1, 2), Aleat.Random.Next(-1, 2), 'F'));
        }
        for (int i = 0; i < 15; i++)
        {
            Habitants.Add(new Pop { X = 0, Y = Aleat.Random.Next(Mida) });
        }
        for (int i = 0; i < 10; i++)
        {
            Habitants.Add(new Tauro { X = Aleat.Random.Next(Mida), Y = Aleat.Random.Next(Mida), Sexe = 'M' });
            Habitants.Add(new Tauro { X = Aleat.Random.Next(Mida), Y = Aleat.Random.Next(Mida), Sexe = 'F' });
        }
        for (int i = 0; i < 6; i++)
        {
            Habitants.Add(new Tortuga { X = Aleat.Random.Next(Mida), Y = Aleat.Random.Next(Mida), Sexe = 'M', DirX = 1, DirY = 0 });
            Habitants.Add(new Tortuga { X = Aleat.Random.Next(Mida), Y = Aleat.Random.Next(Mida), Sexe = 'F', DirX = 0, DirY = 1 });
        }
    }
    public void FerForaElsMorts()
    {
        Habitants.RemoveAll(a => !a.Viu);
    }
    public void FerRonda()
    {
        foreach (var a in Habitants)
        {
            if (a.Viu)
                a.Moure(Mida, Mida);
        }

        ResoldreInteraccions();

        FerForaElsMorts();
    }
    public void ResoldreInteraccions()
    {
        Casella[,] graella = new Casella[Mida, Mida];

        for (int i = 0; i < Mida; i++)
        {
            for (int j = 0; j < Mida; j++)
            {
                graella[i, j] = new Casella();
            }
        }

        foreach (var a in Habitants)
        {
            if (a.Viu)
            {
                graella[a.X, a.Y].Habitants.Add(a);
            }
        }

        for (int i = 0; i < Mida; i++)
        {
            for (int j = 0; j < Mida; j++)
            {
                graella[i, j].ResoldreXocada();
                Habitants.AddRange(graella[i, j].Habitants.Where(a => !Habitants.Contains(a)));
                //utilitzo addrange per no haver de fer un llista.add cada vegada
            }
        }
    }
    public void Finalitzar()
    {
        int peixos = Habitants.Count(a => a is Peix && a.Viu);
        int pops = Habitants.Count(a => a is Pop && a.Viu);
        int taurons = Habitants.Count(a => a is Tauro && a.Viu);
        int tortugues = Habitants.Count(a => a is Tortuga && a.Viu);

        Console.WriteLine($"Peixos: {peixos}");
        Console.WriteLine($"Pops: {pops}");
        Console.WriteLine($"Taurons: {taurons}");
        Console.WriteLine($"Tortugues: {tortugues}");
    }

}
