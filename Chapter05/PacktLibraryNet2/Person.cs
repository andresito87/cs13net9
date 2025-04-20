namespace Packt.Shared;
public class Person
{
    #region Fields: Data or state for this person.
    // Constant fields: Values that are fixed at compilation.
    public const string Species = "Homo Sapiens";

    // Read-only fields: Values that can be set at runtime.
    public readonly string HomePlanet = "Earth";

    public string? Name; // ? means it can be null.
    public DateTimeOffset Born;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();
    #endregion
}