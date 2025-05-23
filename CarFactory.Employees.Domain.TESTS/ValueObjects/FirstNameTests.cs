using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.TESTS.ValueObjects;

public class FirstNameTests
{
    [TestCase(null)]
    [TestCase(default)]
    public void FirstName_ShouldThrowArgumentNullException_WhenValueIsNull(string? firstName)
    {
        Assert.Throws<ArgumentNullException>(() => new FirstName(firstName!));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void FirstName_ShouldThrowArgumentException_WhenIsTooShort(string firstName)
    {
        Assert.Throws<ArgumentException>(() => new FirstName(firstName));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void FirstName_ShouldThrowArgumentException_WhenContainsSpecialCharacters(string firstName)
    {
        Assert.Throws<ArgumentException>(() => new FirstName(firstName));
    }
}
