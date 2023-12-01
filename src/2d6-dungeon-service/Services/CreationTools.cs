
using System.Xml.Serialization;
using Bogus;

namespace c5m._2d6Dungeon;

public class CreationTools
{
    public static string GetAdventurerName(){
        var faker = new Faker();
        return faker.Person.FirstName;
    }

}
