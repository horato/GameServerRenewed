using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeagueSandbox.GameServer.Lib.Tests.Support
{
    public class BuilderGeneratorService
    {
        public string GenerateBuilderTemplate(Type type)
        {
            var template = $@"
internal class {type.Name}Builder : EntityBuilderBase<{type.Name}>
{{
{GenerateFields(type)}

{GenerateWithMethods(type)}

    public override {type.Name} Build()
    {{
        var instance = new {type.Name}({GenerateConstructorParameters(type)});

        return instance;
    }}
}}";

            return template;
        }

        private string GenerateWithMethods(Type type)
        {
            var sb = new StringBuilder();

            var properties = type.GetProperties().OrderBy(x => x.MetadataToken);

            foreach (var property in properties)
            {
                var template = $@"
    public {type.Name}Builder With{property.Name}({property.PropertyType.GetPropertyTypeName()} {property.Name.LowercaseFirstLetter()})
    {{
        _{property.Name.LowercaseFirstLetter()} = {property.Name.LowercaseFirstLetter()};
        return this;
    }}";

                sb.AppendLine(template);
            }

            return sb.ToString();
        }

        private string GenerateFields(Type type)
        {
            var sb = new StringBuilder();

            var properties = type.GetProperties().OrderBy(x => x.MetadataToken);
            foreach (var property in properties)
            {
                var template = $"   private {property.PropertyType.GetPropertyTypeName()} _{property.Name.LowercaseFirstLetter()};";
                sb.AppendLine(template);
            }

            return sb.ToString();
        }

        private string GenerateConstructorParameters(Type type)
        {
            var ctor = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();
            if (ctor == null)
                return string.Empty;

            var sb = new StringBuilder();
            var parameters = ctor.GetParameters().OrderBy(x => x.Position);
            foreach (var parameter in parameters)
            {
                if (!string.IsNullOrEmpty(sb.ToString()))
                    sb.Append(", ");

                sb.Append($"_{parameter.Name.LowercaseFirstLetter()}");
            }

            return sb.ToString();
        }
    }

    internal static class GeneratorExtensions
    {
        public static string LowercaseFirstLetter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var charArray = str.ToCharArray();
            charArray[0] = char.ToLower(str[0]);

            return new string(charArray);
        }

        public static string GetPropertyTypeName(this Type propertyType)
        {
            var genericArguments = propertyType.GetGenericArguments().ToList();
            if (genericArguments.Count == 0)
                return propertyType.Name;

            return $"{propertyType.Name.Remove(propertyType.Name.IndexOf('`'))}<{string.Join(", ", genericArguments.Select(x => x.Name))}>";
        }

    }
}
