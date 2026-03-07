namespace Tasca;

public abstract class Animal
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Sexe { get; set; }
    public bool Viu { get; set; } = true;
    public abstract void Moure(int maxFiles, int maxColumnes);
    public void Morir()
    {
        this.Viu = false;
    }
}