namespace AcademicSystem.ApplicationCore.Entities;

public class Administrator : BaseEntity
{
    public string UserId { get; private set; }

    protected Administrator() { }

    public Administrator(string userId)
    {
        this.UserId = userId;
    }
}
