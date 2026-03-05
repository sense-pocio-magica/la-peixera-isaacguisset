namespace Tasca;

public class Casella
{
    public List<Animal> Habitants { get; set; } = new List<Animal>();

    public void ResoldreXocada()
    {
        if (Habitants.Count < 2) return;
        //aqui he de posar la logica
    }
}
