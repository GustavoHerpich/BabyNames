namespace BabyName.Entities;

public class BabyNames
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public char Gender { get; set; } // 'M' or 'F'
    public int Births { get; set; }
    public int Position { get; set; }
}
