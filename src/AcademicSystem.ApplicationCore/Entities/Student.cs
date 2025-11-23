using AcademicSystem.ApplicationCore.Exceptions;

namespace AcademicSystem.ApplicationCore.Entities;

public class Student : BaseEntity
{
    public string UserId { get; private set; }
    public string RegistrationNumber { get; set; }
    public Address Address { get; private set; }

    protected Student() { }

    public Student(string userId, string registrationNumber, Address address)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new DomainException("UserId is required");
        }

        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            throw new DomainException("Registration Number is required");
        }

        this.UserId = userId;
        this.RegistrationNumber = registrationNumber;
        this.Address = address;
    }
}
