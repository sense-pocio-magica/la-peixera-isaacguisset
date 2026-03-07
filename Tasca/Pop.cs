namespace Tasca;

public class Pop : Animal, IInteractuable,IDesplaçable
{
    private bool sentit = true;  // si es true es cap a la dreta i si es false cap a lesquerra

    public override void Moure(int filamax, int columnamax) //potser es massa llarg, he de pensar en simplificar-lo si puc
    {
        if (sentit)
        {
            if (X == 0 && Y < columnamax - 1) // mentres esta a dalt i no arriba al costat de dreta es va movent cap a la dreta
            {
                Y++;
            }
            else if (Y == columnamax - 1 && X < filamax - 1) //quan hi arriba baixa
            {
                X++;
            }
            else if (X == filamax - 1 && Y > 0) // quan esta abaix ja fins que no arriba a l esquerra es va movent
            {
                Y--;
            }
            else if (Y == 0 && X > 0)//fins que no arriba a dalt es va movent
            {
                X--;
            }
        }
        else // bàsicament lo mateix al revés
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
        if (altre is Pop)
        {
            this.sentit = !this.sentit;
        }
    }
}
