namespace Tasca;

public class Casella
{
    public List<Animal> Habitants { get; set; } = new List<Animal>();

    public List<Animal> ResoldreXocada()
    {
        var nous = new List<Animal>();

        var vius = Habitants.Where(a => a.Viu).ToList();
        if (vius.Count < 2)
            return nous;

        for (int i = 0; i < vius.Count; i++)
        {
            var a1 = vius[i];
            if (a1 is not IInteractuable interactor)
                continue;
            for (int j = i + 1; j < vius.Count; j++)
            {
                var a2 = vius[j];

                if (!a2.Viu)
                    continue;
                interactor.Interactuar(a2, nous);
            }
        }
        return nous;
    }
}