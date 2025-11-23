namespace AcademicSystem.ApplicationCore.Entities;

public class Administrator : BaseEntity
{
    public string UserId { get; private set; } = null!;

    protected Administrator() { }

    public Administrator(string userId)
    {
        this.UserId = userId;
    }
}
