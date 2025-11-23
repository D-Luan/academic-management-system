using System;
namespace AcademicSystem.ApplicationCore.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}
