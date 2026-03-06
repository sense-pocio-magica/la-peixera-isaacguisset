using System.Net.Mail;

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
        if (altre is Peix )
        {
            if (this.Sexe != altre.Sexe)
            {
                Random r = new Random();
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
                if (r.Next(0, 2) == 0)
                {
                    nouSexe = 'F';
                }
                else { nouSexe = 'M'; }


            }
            else
            {
                this.Viu = false;
                altre.Viu = false;
            }
        }
    }
}
