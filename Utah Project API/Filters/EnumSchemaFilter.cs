using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Utah_Project_API.Filters;

// ReSharper disable once ClassNeverInstantiated.Global
public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum) return;
        
        string[] names = Enum.GetNames(context.Type);
        IEnumerable<int> values = Enum.GetValues(context.Type).Cast<int>();

        schema.Description += "<p>Possible values:</p><ul>";
        foreach ((string name, int value) in names.Zip(values, (n, v) => (n, v)))
        {
            schema.Description += $"<li><b>{value}</b> = {name}</li>";
        }
        schema.Description += "</ul>";
    }
}