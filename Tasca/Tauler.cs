namespace Tasca;

public class Tauler
{
    public List<Animal> Habitants { get; set; } = new List<Animal>();
    public int Mida { get; set; } = 20;
    public (int, int) DirAleat() // utilitzo tuples
    {
        int dx, dy;
        do
        {
            dx = Aleat.Random.Next(-1, 2);
            dy = Aleat.Random.Next(-1, 2);
        } while (dx == 0 && dy == 0);//evitar que sigui 0,0

        return (dx, dy);
    }
    public void Inicialitzar()
    {
        Peix CrearPeix(char sexe)
        {
            var (dx, dy) = DirAleat();//perr no repetirme --> dry
            return new Peix(Aleat.Random.Next(Mida), Aleat.Random.Next(Mida), dx, dy, sexe);
        }



        Tortuga CrearTortuga(char sexe)
        {
            var (dx, dy) = DirAleat();
            return new Tortuga { X = Aleat.Random.Next(Mida), Y = Aleat.Random.Next(Mida), Sexe = sexe, DirX = dx, DirY = dy };
        }

        Tauro CrearTauro(char sexe)
        {
            var (dx, dy) = DirAleat();
            return new Tauro { X = Aleat.Random.Next(Mida), Y = Aleat.Random.Next(Mida), Sexe = sexe, DirX = dx, DirY = dy };
        }


        for (int i = 0; i < 50; i++)
        {
            Habitants.Add(CrearPeix('M'));
            Habitants.Add(CrearPeix('F'));
        }

        for (int i = 0; i < 15; i++)
            Habitants.Add(new Pop { X = 0, Y = Aleat.Random.Next(Mida) });

        for (int i = 0; i < 10; i++)
        {
            Habitants.Add(CrearTauro('M'));
            Habitants.Add(CrearTauro('F'));
        }

        for (int i = 0; i < 3; i++)
        {
            Habitants.Add(CrearTortuga('M'));
            Habitants.Add(CrearTortuga('F'));
        }
    }
    public void FerForaElsMorts()//ns si els hauria de treure de la llista en el moment de matar-los...
    {
        Habitants.RemoveAll(a => !a.Viu);
    }
    public void FerRonda()
    {
        foreach (var a in Habitants)
            if (a.Viu)
                a.Moure(Mida, Mida);

        ResoldreInteraccions();

        FerForaElsMorts();
    }
    public void ResoldreInteraccions()
    {
        Casella[,] graella = new Casella[Mida, Mida];
        for (int i = 0; i < Mida; i++)
            for (int j = 0; j < Mida; j++)
                graella[i, j] = new Casella();

        foreach (var a in Habitants.Where(a => a.Viu))
        {
            graella[a.X, a.Y].Habitants.Add(a);
        }

        List<Animal> nousHabitants = new List<Animal>();

        for (int i = 0; i < Mida; i++)
        {
            for (int j = 0; j < Mida; j++)
            {
                var nous = graella[i, j].ResoldreXocada();
                foreach (var n in nous)
                {
                    if (n.Viu && !Habitants.Contains(n) && !nousHabitants.Contains(n))
                        nousHabitants.Add(n);
                }

            }
        }

        Habitants.AddRange(nousHabitants);

        FerForaElsMorts();
    }
    public void Finalitzar()
    //reconte final
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