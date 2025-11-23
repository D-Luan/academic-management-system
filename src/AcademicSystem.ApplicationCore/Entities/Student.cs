using AcademicSystem.ApplicationCore.Exceptions;
using AcademicSystem.ApplicationCore.Constants;

namespace AcademicSystem.ApplicationCore.Entities;

public class Student : BaseEntity
{
    public string UserId { get; private set; } = null!;
    public string RegistrationNumber { get; set; } = null!;
    public Address Address { get; private set; } = null!;

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

        if (registrationNumber.Length > StudentConstraints.MaxRegistrationNumberLength)
        {
            throw new DomainException("Registration Number cannot exceed 10 characters");
        }

        this.UserId = userId;
        this.RegistrationNumber = registrationNumber;
        this.Address = address;
    }
}
