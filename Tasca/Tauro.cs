namespace Tasca;

public class Tauro : Animal, IInteractuable, IReproducible
{
    public int Vida { get; set; } = 75;
    public int DirX { get; set; } = 1;
    public int DirY { get; set; } = 0;
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
        else if (altre is Tauro t)
        {
            if (this.Sexe != t.Sexe)//es reprodueixen
            {

                var elQueNeix = Reproduir(altre);
                if (elQueNeix != null)
                {
                    nousHabitants.Add(elQueNeix);
                }
            }
            else//es maten entre ells o entre elles :/
            {
                this.Morir();
                t.Morir();
            }
        }
    }
    public Animal Reproduir(Animal altre)
    {
        if (altre is Tauro t && this.Sexe != t.Sexe)
        {
            int novaDirX = this.DirX != 0 ? -this.DirX : 1;
            int novaDirY = this.DirY != 0 ? -this.DirY : 1;

            char nouSexe = Aleat.Random.Next(2) == 0 ? 'F' : 'M';

            return new Tauro
            {
                X = this.X,
                Y = this.Y,
                Sexe = nouSexe,
                DirX = novaDirX,
                DirY = novaDirY,
                Vida = 75
            };
        }
        return null;
    }
}
