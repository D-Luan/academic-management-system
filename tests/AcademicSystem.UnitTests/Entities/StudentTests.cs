using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Exceptions;
using Xunit;

namespace AcademicSystem.UnitTests.Entities;

public class StudentTests
{
    [Fact]
    public void Should_ThrowDomainException_When_RegistrationNumberIsTooLong()
    {
        var longRa = "12345678901";
        var address = new Address("Rua X", "Cidade Y", "SP", "00000-000");

        Assert.Throws<DomainException>(() =>
            new Student("user123", longRa, address)
        );
    }
}
