namespace Tasca;

public class Peix : Animal, IInteractuable
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
        if (altre is Peix && this.Sexe != altre.Sexe)
        {
            //encara he de posar la lógica pero de moment vaig a per lo fàcil
        }
    }
}
