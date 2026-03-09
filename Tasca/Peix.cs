namespace Tasca;

public class Peix : Animal, IInteractuable, IReproducible
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

                var elQueNeix = Reproduir(altre);
                if (elQueNeix != null)
                {
                    nousHabitants.Add(elQueNeix);
                    Console.WriteLine($"Dos peixos de diferent sexe es troben i copulen generant un peixet mini");

                }
            }
            else//es maten entre ells o entre elles :/
            {
                this.Morir();
                p.Morir();
                Console.WriteLine($"Dos peixos de mateix sexe es troben i es maten");

            }
        }
    }
    public Animal Reproduir(Animal altre)
    {
        if (altre is Peix p && this.Sexe != p.Sexe)
        {
            int novaDirX = this.DirX != 0 ? -this.DirX : 1;
            int novaDirY = this.DirY != 0 ? -this.DirY : 1;

            char nouSexe = Aleat.Random.Next(2) == 0 ? 'F' : 'M';

            return new Peix(this.X, this.Y, novaDirX, novaDirY, nouSexe);
        }
        return null!;
    }
}
