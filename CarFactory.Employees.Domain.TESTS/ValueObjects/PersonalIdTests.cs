using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.TESTS.ValueObjects;

public class PersonalIdTests
{
    [TestCase(null)]
    [TestCase(default)]
    public void PersonalId_ShouldThrowArgumentNullException_WhenValueIsNull(string? value)
    {
        Assert.Throws<ArgumentNullException>(() => new PersonalId(value!));
    }

    [TestCase("1")]
    [TestCase("12345")]
    [TestCase("1234578")]
    [TestCase("1234567890")]
    public void PersonalId_ShouldThrowArgumentException_WhenValueLengthIsBelow11(string value)
    {
        Assert.Throws<ArgumentException>(() => new PersonalId(value));
    }

    [TestCase("123456789012")]
    [TestCase("12345678901234")]
    [TestCase("123456789012345")]
    public void PersonalId_ShouldThrowArgumentException_WhenValueLengthIsAbove11(string value)
    {
        Assert.Throws<ArgumentException>(() => new PersonalId(value));
    }

    [TestCase("1234567890!")]
    [TestCase("1@34567890!")]
    [TestCase("1$%^567890!")]
    public void PersonalId_ShouldThrowArgumentException_WhenValueContainsSpecialCharacters(string value)
    {
        Assert.Throws<ArgumentException>(() => new PersonalId(value));
    }

    [TestCase("1 34567890!")]
    [TestCase("1 4567 890!")]
    [TestCase(" 5678 9  0!")]
    public void PersonalId_ShouldThrowArgumentException_WhenValueContainsEmptySpaces(string value)
    {
        Assert.Throws<ArgumentException>(() => new PersonalId(value));
    }

    [TestCase("12345678901")]
    [TestCase("67859402101")]
    [TestCase("89675839201")]
    public void PersonalId_ShouldCreateObject_WhenValueIs11LengthDigits(string value)
    {
        var personalId = new PersonalId(value);

        Assert.That(personalId, Is.Not.Null);
        Assert.That(personalId.Value, Is.EqualTo(value));
    }
}
