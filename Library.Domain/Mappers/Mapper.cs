using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Mappers
{
    public class Mapper
    {
        public TOutput Map<TInput, TOutput>(TInput input)
        {
            TOutput output = (TOutput)Activator.CreateInstance(typeof(TOutput));

            if (input == null)
                return output;

            var properties = typeof(TOutput).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var propertyName = properties[i].Name;
                var className = typeof(TOutput).Name;
                var property = input.GetType().GetProperty(propertyName);
                if (property == null)
                    property = input.GetType().GetProperty(className + propertyName);
                if (property == null)
                    continue;
                if (property.PropertyType.IsClass & property.PropertyType.Name != "String")
                    continue;
                var value = property.GetValue(input);

                properties[i].SetValue(output, value);
            }
            return output;
        }

        public IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> inputs)
        {
            foreach(var input in inputs)
            {
                yield return Map<TInput, TOutput>(input);
            }
        }
    }
}
