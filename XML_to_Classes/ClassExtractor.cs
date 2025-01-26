using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XML_to_Classes
{
    public static class ClassExtractor
    {
        /// <summary>
        /// Extracts all class information recursively from the given XElement.
        /// </summary>
        public static HashSet<Class> ExtractClasses(this XElement rootElement) {
            var classes = new HashSet<Class>();
            ProcessElement(rootElement, classes);
            return classes;
        }

        /// <summary>
        /// Checks if an XElement has no attributes or child elements.
        /// </summary>
        public static bool IsEmpty(this XElement element) {
            return !element.HasAttributes && !element.HasElements;
        }

        /// <summary>
        /// Processes an XElement and adds its corresponding class to the collection.
        /// Recursively processes child elements.
        /// </summary>
        private static Class ProcessElement(XElement element, ICollection<Class> classes) {
            // Create the Class representation for the current XElement
            var newClass = new Class
            {
                Name = element.Name.LocalName,
                XmlName = element.Name.LocalName,
                Fields = ReplaceDuplicatesWithLists(ExtractFields(element, classes)).ToList(),
                Namespace = element.Name.NamespaceName
            };

            // Ensure the class name is safe and unique
            StripInvalidCharacters(newClass);

            var existingClass = classes.FirstOrDefault(c => c.XmlName == newClass.XmlName);
            if (existingClass != null) {
                // Compare fields and add any missing ones
                foreach (var field in newClass.Fields) {
                    if (!existingClass.Fields.Any(f => f.Name == field.Name)) {
                        existingClass.Fields.Append(field);
                    }
                }
            }
            else {
                // Add the new class to the list if it doesn't already exist
                classes.Add(newClass);
            }

            return newClass;
        }

        /// <summary>
        /// Extracts fields (attributes and child elements) from the given XElement.
        /// </summary>
        private static IEnumerable<Field> ExtractFields(XElement element, ICollection<Class> classes) {
            // Process child elements
            foreach (var childElement in element.Elements()) {
                var childClass = ProcessElement(childElement, classes);
                var type = childElement.IsEmpty() ? "string" : childClass.Name;

                yield return new Field
                {
                    Name = childElement.Name.LocalName,
                    Type = type,
                    XmlName = childElement.Name.LocalName,
                    XmlType = XmlType.Element,
                    Namespace = childElement.Name.NamespaceName
                };
            }

            // Process attributes
            foreach (var attribute in element.Attributes()) {
                yield return new Field
                {
                    Name = attribute.Name.LocalName,
                    XmlName = attribute.Name.LocalName,
                    Type = attribute.Value.GetType().Name,
                    XmlType = XmlType.Attribute,
                    Namespace = attribute.Name.NamespaceName
                };
            }
        }

        /// <summary>
        /// Replaces duplicate fields with a single field using a List<> type.
        /// </summary>
        private static IEnumerable<Field> ReplaceDuplicatesWithLists(IEnumerable<Field> fields) {
            return fields
                .GroupBy(field => field.Name)
                .Select(group => group.Count() > 1
                    ? new Field
                    {
                        Name = group.Key,
                        Namespace = group.First().Namespace,
                        Type = $"List<{group.First().Type}>",
                        XmlName = group.First().XmlName,
                        XmlType = XmlType.Element
                    }
                    : group.First());
        }

        /// <summary>
        /// Ensures the class name is unique within the collection.
        /// </summary>
        private static void EnsureUniqueName(Class newClass, IEnumerable<Class> classes) {
            var existingCount = classes.Count(c => c.XmlName == newClass.XmlName);
            if (existingCount > 0 && !classes.Contains(newClass)) {
                newClass.Name = StripInvalidCharacters(newClass) + (existingCount + 1);
            }
            else {
                newClass.Name = StripInvalidCharacters(newClass);
            }
        }

        /// <summary>
        /// Strips invalid characters from the class name.
        /// </summary>
        private static string StripInvalidCharacters(Class newClass) {
            return newClass.Name.Replace("-", "");
        }
    }
}