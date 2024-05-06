namespace Lab8;
class Programmer
{
    public event Action? Mutate;
    public event Action? Remove;

    public int Level { get { return level; } }
    int level;
    public bool DerivingPleasure { get; set; }

    public Programmer(int level, bool derivingPleasure)
    {
        this.level = level;
        DerivingPleasure = derivingPleasure;
    }
    public Programmer() : this(0, false) { }

    public void doMutate()
    {
        if (DerivingPleasure)
            level++;

        if (Mutate != null)
            Mutate();
    }

    public void doFire()
    {
        if (Remove != null)
            Remove();
    }

}
