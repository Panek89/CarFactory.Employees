using System;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.TESTS.ValueObjects;

public class LastNameTests
{
    [TestCase(null)]
    [TestCase(default)]
    public void LastName_ShouldThrowArgumentNullException_WhenValueIsNull(string? lastName)
    {
        Assert.Throws<ArgumentNullException>(() => new LastName(lastName!));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void LastName_ShouldThrowArgumentException_WhenIsTooShort(string lastName)
    {
        Assert.Throws<ArgumentException>(() => new LastName(lastName));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void LastName_ShouldThrowArgumentException_WhenContainsSpecialCharacters(string lastName)
    {
        Assert.Throws<ArgumentException>(() => new LastName(lastName));
    }
}
