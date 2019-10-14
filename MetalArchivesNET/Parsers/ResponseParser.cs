using MetalArchivesNET.Attributes;
using MetalArchivesNET.Attributes.Abstract;
using MetalArchivesNET.Models.Responses;
using MetalArchivesNET.Parsers.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MetalArchivesNET.Parsers
{
    /// <summary>
    /// Parses input string by given typ
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    class ResponseParser<T> : IParser<List<T>> where T : class, new()
    {
        /// <summary>
        /// Parses class using attributes on it's properties. Props without <see cref="ColumnAttribute">ColumnAttribute</see>  won't be used in parsing engine
        /// </summary>
        /// <param name="content">Json string of <see cref="SearchResponse"/></param>
        /// <returns>Parsed list of element based</returns>
        public List<T> Parse(string content)
        {
            var response = JsonConvert.DeserializeObject<SearchResponse>(content);

            List<Action<string[], T>> assignList = new List<Action<string[], T>>();

            foreach (var prop in typeof(T).GetProperties())
            {
                var column = prop.GetCustomAttribute<ColumnAttribute>();
                if (column != null)
                {
                    List<string> attributeTypeNames = prop.GetCustomAttributes().Select(t => t.GetType().Name).ToList();

                    FieldDecoratorBase lastDecorator = column;
                    List<Type> decorators = typeof(FieldDecoratorBase).Assembly.GetTypes()
                                            .Where(t => t.IsSubclassOf(typeof(FieldDecoratorBase)) && !t.IsAbstract && t != typeof(ColumnAttribute))
                                            .OrderByDescending(t => attributeTypeNames.IndexOf(t.Name))
                                            .ToList();

                    foreach (var dec in decorators)
                    {
                        if (prop.GetCustomAttribute(dec) is FieldDecoratorBase decorator)
                        {
                            decorator.SetDecorator(lastDecorator);
                            lastDecorator = decorator;
                        }
                    }

                    assignList.Add((list, model) =>
                    {
                        column.SetBaseValue(list[column.Index]);
                        object val = lastDecorator.GetValue();
                        prop.SetValue(model, val);
                    });
                }
            }

            List<T> items = new List<T>();

            foreach (var respItem in response.aaData)
            {
                T model = new T();

                foreach (var assignOperation in assignList)
                    assignOperation(respItem, model);

                items.Add(model);
            }

            return items;
        }

    }
}
