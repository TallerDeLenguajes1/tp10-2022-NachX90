using System.Text.Json.Serialization;

public class Cost
{
    [JsonPropertyName("Food")]
    public int Food { get; set; }

    [JsonPropertyName("Gold")]
    public int Gold { get; set; }
}

public class Technology
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("expansion")]
    public string Expansion { get; set; }

    [JsonPropertyName("age")]
    public string Age { get; set; }

    [JsonPropertyName("develops_in")]
    public string DevelopsIn { get; set; }

    [JsonPropertyName("cost")]
    public Cost Cost { get; set; }

    [JsonPropertyName("build_time")]
    public int BuildTime { get; set; }

    [JsonPropertyName("applies_to")]
    public List<string> AppliesTo { get; set; }
    
    public void PrintTechnology()
    {
        Console.WriteLine($"\tID:\t\t\t{Id}");
        Console.WriteLine($"\tNombre:\t\t\t{Name}");
        Console.WriteLine($"\tDescripción:\t\t{Description}");
        Console.WriteLine($"\tExpansión:\t\t{Expansion}");
        Console.WriteLine($"\tEdad:\t\t\t{Age}");
        Console.WriteLine($"\tDevelopsIn:\t\t{DevelopsIn}");
        Console.WriteLine("\tCosto:");
        Console.WriteLine($"\t\t\t\t* {Cost.Food} Alimento");
        Console.WriteLine($"\t\t\t\t* {Cost.Gold} Oro");
        Console.WriteLine($"\tTiempo de construcción:\t{BuildTime}");
    }
}
