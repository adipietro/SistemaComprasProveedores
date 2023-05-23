using System;

public abstract class ID
{
    public int Id { get; set; }

    // -- Quiero que dos objetos con igual ID caigan en el mismo Bucket del HashSet
    public override int GetHashCode()
    {
        return Id;
    }

    public override string ToString()
    {
        return this.Id.ToString();
    }
}

