using System.Text.Json.Serialization;

namespace Quick.Fields;

[JsonSerializable(typeof(FieldForGet))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class FieldForGetSerializerContext : JsonSerializerContext { }
