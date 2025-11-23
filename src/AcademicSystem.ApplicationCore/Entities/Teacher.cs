using AcademicSystem.ApplicationCore.Exceptions;

namespace AcademicSystem.ApplicationCore.Entities;

public class Teacher : BaseEntity
{
    public string UserId { get; private set; }
    public Address Address { get; private set; }

    protected Teacher() { }

    public Teacher(string userId, Address address)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new DomainException("UserId is required");
        }

        this.UserId = userId;
        this.Address = address;
    }
}
