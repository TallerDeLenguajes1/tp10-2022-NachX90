using System.Text.Json.Serialization;

public class Civilization
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("expansion")]
    public string Expansion { get; set; }

    [JsonPropertyName("army_type")]
    public string ArmyType { get; set; }

    [JsonPropertyName("unique_unit")]
    public List<string> UniqueUnit { get; set; }

    [JsonPropertyName("unique_tech")]
    public List<string> UniqueTech { get; set; }

    [JsonPropertyName("team_bonus")]
    public string TeamBonus { get; set; }

    [JsonPropertyName("civilization_bonus")]
    public List<string> CivilizationBonus { get; set; }

    public void PrintCivilization()
    {
        Console.WriteLine($"\tID:\t\t\t{Id}");
        Console.WriteLine($"\tNombre:\t\t\t{Name}");
        Console.WriteLine($"\tExpansión:\t\t{Expansion}");
        Console.WriteLine($"\tTipo de ejército:\t{ArmyType}");
        if (UniqueUnit != null)
        {
            Console.WriteLine("\tUnidades únicas:");
            foreach (var Unit in UniqueUnit)
            {
                Console.WriteLine($"\t\t\t\t* {Unit}");
            }
        }
        else
        {
            Console.WriteLine("\tUnidades únicas:\tNo tiene.");
        }
        if (UniqueTech != null)
        {
            Console.WriteLine("\tTecnologías únicas:");
            foreach (var Tech in UniqueTech)
            {
                Console.WriteLine($"\t\t\t\t* {Tech}");
            }
        }
        else
        {
            Console.WriteLine("\tTecnologías únicas:\tNo tiene.");
        }
        Console.WriteLine($"\tBonus de equipo:\t{TeamBonus}");
        if (CivilizationBonus != null)
        {
            Console.WriteLine("\tBonificaciones del equipo:");
            foreach (var Bonus in CivilizationBonus)
            {
                Console.WriteLine($"\t\t\t\t* {Bonus}");
            }
        }
        else
        {
            Console.WriteLine("\tBonificaciones del equipo:\tNo tiene.");
        }
    }
}

public class CivilizationsList
{
    [JsonPropertyName("civilizations")]
    public List<Civilization> Civilizations { get; set; }
}