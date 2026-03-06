namespace Tasca;

public class Pop : Animal, IInteractuable
{
    private bool sentit = true;  // si es true es cap a la dreta i si es false cap a lesquerra

    public override void Moure(int filamax, int columnamax)
    {
        if (sentit)
        {
            if (X == 0 && Y < columnamax - 1) // mentres esta adalt i no arriba al costat de dreta es va moveent cap a la dreta
            {
                Y++;
            }
            else if (Y == columnamax - 1 && X < filamax - 1) //quan hi arriba baixa
            {
                X++;
            }
            else if (X == filamax - 1 && Y > 0) // quan esta abaix ja fins que no arriba a lesquerra es va movent
            {
                Y--;
            }
            else if (Y == 0 && X > 0)//fins que no arriba adalt es va movent
            {
                X--;
            }
        }
        else // basicament lo mateix al reves
        {
            if (X == 0 && Y > 0)
            {
                Y--;
            }
            else if (Y == 0 && X < filamax - 1)
            {
                X++;
            }
            else if (X == filamax - 1 && Y < columnamax - 1)
            {
                Y++;
            }
            else if (Y == columnamax - 1 && X > 0)
            {
                X--;
            }
        }
    }

    public void Interactuar(Animal altre, List<Animal> nousHabitants)
    {
        // si troben un altre pop van cap al sentit que no sigui el d ara
        if (altre is Pop)
        {
            this.sentit = !this.sentit;
        }
    }
}
