using System.Text.Json;
using System.Text.Json.Serialization;
using Quick.Fields;

var json = JsonSerializer.Serialize(new FieldForGet()
{
    Type = FieldType.Button,
    Theme = FieldTheme.Danger,
    Margin = 2
}, new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
var obj = JsonSerializer.Deserialize<FieldForGet>(json);
Console.WriteLine("Hello world!");