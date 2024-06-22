using Domain.Maintenances.Exceptions;
using Domain.Maintenances;

namespace Domain.Tests.Unit.Maintenances;

public class NotesTest
{
    [Theory]
    [ClassData(typeof(NotesCreateValidData))]
    public void Create_Should_ReturnNotes(string value)
    {
        var notes = Notes.Create(value);

        Assert.Equal(value, notes.Value);
    }

    [Theory]
    [ClassData(typeof(NotesCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => Notes.Create(value));
    }
}

public class NotesCreateValidData : TheoryData<string>
{
    public NotesCreateValidData()
    {
        Add("These are some curious observations");
        Add(new string('A', Notes.MaximumLength - 1));
        Add(new string('A', Notes.MaximumLength));
    }
}

public class NotesCreateInvalidData : TheoryData<Type, string>
{
    public NotesCreateInvalidData()
    {
        Add(
            typeof(NotesIsEmptyException),
            "");
        Add(
            typeof(NotesIsEmptyException),
            "     ");
        Add(
            typeof(NotesLengthIsInvalidException),
            new string('A', Notes.MaximumLength + 1));
    }
}
