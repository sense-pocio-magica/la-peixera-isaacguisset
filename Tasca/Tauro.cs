namespace Tasca;

public class Tauro : Animal, IInteractuable,IDesplaçable
{
    public int Vida { get; set; } = 75;

    public override void Moure(int filamax, int columnamax)
    {
        X = (X + 1 + filamax) % filamax;
        Vida--;
        if (Vida <= 0) Viu = false;
    }

    public void Interactuar(Animal altre, List<Animal> nousHabitants)
    {
        if (altre is Peix)
        {
            altre.Viu = false;
        }
    }
}
