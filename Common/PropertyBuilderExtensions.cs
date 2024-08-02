using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace KC.API.Data.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasJsonConversion<TProperty>(this PropertyBuilder<TProperty> builder)
        {
            return builder.HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<TProperty>(v, (JsonSerializerOptions)null));
        }
    }
}
