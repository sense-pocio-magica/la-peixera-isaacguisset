namespace Tasca;

public class Tortuga : Animal, IInteractuable, IReproducible
{

    public int DirX { get; set; }
    public int DirY { get; set; }
    public override void Moure(int filamax, int columnamax)
    {
        X = (X + DirX + filamax) % filamax;

        Y = (Y + DirY + columnamax) % columnamax;
    }



    public void Interactuar(Animal altre, List<Animal> nousHabitants)
    {

        if (altre is Tortuga && this.Sexe == altre.Sexe)
        {
            this.Viu = false;
            altre.Viu = false;
            Console.WriteLine($"Dues tortugues del mateix sexe es troben i es maten");
        }
        else if (altre is Tortuga && this.Sexe != altre.Sexe)
        {
            var nou = Reproduir(altre);
            if (nou != null)
            {
                nousHabitants.Add(nou);
                Console.WriteLine($"Dues tortugues de diferent sexe es troben i copulen generant una tortugueta mini");
            }

        }
    }
    public Animal Reproduir(Animal altre)
    {
        if (altre is Tortuga t && this.Sexe != t.Sexe)
        {
            return new Tortuga
            {
                X = this.X,
                Y = this.Y,
                Sexe = Aleat.Random.Next(0, 2) == 0 ? 'M' : 'F',
                DirX = Aleat.Random.Next(-1, 2),
                DirY = Aleat.Random.Next(-1, 2)
            };
        }

        return null;
    }
}
