using System.Net.Mail;

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
        if (altre is Peix)
        {
            if (this.Sexe != altre.Sexe)
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

                char nouSexe;
                if (Aleat.Random.Next(0, 2) == 0)
                {
                    nouSexe = 'F';
                }
                else { nouSexe = 'M'; }

                nousHabitants.Add(new Peix(this.X, this.Y, novaDirX, novaDirY, nouSexe));

            }
            else
            {
                this.Viu = false;
                altre.Viu = false;
            }
        }
    }
}
