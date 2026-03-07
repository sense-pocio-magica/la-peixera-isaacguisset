namespace Tasca;

public class Tortuga : Animal, IInteractuable,IDesplaçable
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
        }
        else if (altre is Tortuga && this.Sexe != altre.Sexe)
        {
            nousHabitants.Add(new Tortuga
            {
                X = this.X,
                Y = this.Y,
                Sexe = Aleat.Random.Next(0, 2) == 0 ? 'M' : 'F',
                DirX = Aleat.Random.Next(-1, 2),
                DirY = Aleat.Random.Next(-1, 2)
            });
        }
    }
}
