using System.Text.Json;
using System.Text.Json.Serialization;

namespace HungryPoll.API.Converters
{
	public class GuidJsonConverter : JsonConverter<Guid>
	{
		public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (!Guid.TryParse(reader.GetString(), out var parsedGuid))
			{
				return Guid.Empty;
			}

			return parsedGuid;
		}

		public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
	}
}
