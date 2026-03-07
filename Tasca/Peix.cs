namespace Tasca;

public class Peix : Animal, IInteractuable
{
    public int DirX { get; set; }
    public int DirY { get; set; }
    public Peix(int x, int y, int dx, int dy, char sexe)
    {
        X = x;
        Y = y;
        DirX = dx;
        DirY = dy;
        Sexe = sexe;
        Viu = true;
    }
    public override void Moure(int filamax, int columnamax)
    {
        X = (X + DirX + filamax) % filamax;
        Y = (Y + DirY + columnamax) % columnamax;
    }
public void Interactuar(Animal altre, List<Animal> nousHabitants)
{
    if (altre is Peix p)


    {
        if (this.Sexe != p.Sexe)//es reprodueixen
        {
            int novaDirX = 1;
            int novaDirY = 1;
            if (this.DirX != 0)
            {
                novaDirX = -this.DirX;
            }
            if (this.DirY != 0)
            {
                novaDirY = -this.DirY;
            }

            char nouSexe = Aleat.Random.Next(2) == 0 ? 'F' : 'M';

            nousHabitants.Add(new Peix(this.X, this.Y, novaDirX, novaDirY, nouSexe));
        }
        else//es maten entre ells o entre elles :/
        {
                this.Morir();
                p.Morir();
        }
    }
}
}
