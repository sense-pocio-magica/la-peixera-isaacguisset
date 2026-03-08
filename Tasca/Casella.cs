namespace Tasca;

public class Casella
{
    public List<Animal> Habitants { get; set; } = new List<Animal>();

    public void ResoldreXocada()
    {
        if (Habitants.Count < 2) return;

        List<Animal> nous = new List<Animal>();
        for (int i = 0; i < Habitants.Count - 1; i++)
        {
            for (int j = i + 1; j < Habitants.Count; j++)
            {
                if (Habitants[i].Viu && Habitants[j].Viu)
                {
                    if (Habitants[i] is IInteractuable inter1)
                        inter1.Interactuar(Habitants[j], nous);

                    if (Habitants[j] is IInteractuable inter2)
                        inter2.Interactuar(Habitants[i], nous);
                }
            }
        }
        Habitants.AddRange(nous);
    }

}
