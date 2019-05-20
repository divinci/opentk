using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bind.XML.Signatures.Enumerations;
using Humanizer;
using JetBrains.Annotations;

namespace Bind.Writers
{
    /// <summary>
    /// Writes <see cref="EnumerationSignature"/>s to C# enum source files.
    /// </summary>
    public static class EnumWriter
    {
        /// <summary>
        /// Asynchronously writes an enum to a file.
        /// </summary>
        /// <param name="enum">The enum to write.</param>
        /// <param name="file">The file to write to.</param>
        /// <param name="ns">The namespace of this enum.</param>
        /// <param name="prefix">The constant prefix for the profile.</param>
        /// <returns>The asynchronous task.</returns>
        public static async Task WriteEnumAsync(EnumerationSignature @enum, string file, string ns, string prefix)
        {
            using (var sw = new StreamWriter(File.Open(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                sw.WriteLine("// <auto-generated />");
                sw.WriteLine(EmbeddedResources.LicenseText(Path.GetFileName(file)));
                sw.WriteLine("using System;");
                sw.WriteLine();
                sw.WriteLine("namespace " + ns);
                sw.WriteLine("{");
                sw.WriteLine("    /// <summary>");
                sw.Write("    /// An OpenGL enum");
                if (@enum.Tokens.Any())
                {
                    sw.Write(" containing values ");
                    sw.Write(@enum.Tokens.OrderBy(x => x.Value).FirstOrDefault()?.Value);
                    sw.Write(" through ");
                    sw.Write(@enum.Tokens.OrderBy(x => x.Value).LastOrDefault()?.Value);
                }

                sw.WriteLine(".");
                sw.WriteLine("    /// </summary>");
                sw.WriteLine("    public enum " + @enum.Name);
                sw.WriteLine("    {");
                WriteTokens(sw, @enum.Tokens, prefix);
                sw.WriteLine("    }");
                sw.WriteLine("}");
                await sw.FlushAsync();
            }
        }

        private static void WriteTokens
        (
            [NotNull] StreamWriter sw,
            [NotNull] IEnumerable<TokenSignature> tokens,
            [NotNull] string prefix
        )
        {
            // Make sure everything is sorted. This will avoid random changes between
            // consecutive runs of the program.
            tokens = tokens.OrderBy(c => c.Value).ThenBy(c => c.Name).ToList();

            foreach (var token in tokens)
            {
                var valueString = $"0x{token.Value:X}";

                sw.WriteLine("        /// <summary>");
                var originalTokenName = $"{prefix}{token.Name.Underscore().ToUpperInvariant()}";
                sw.WriteLine($"        /// Original was {originalTokenName} = {valueString}");
                sw.WriteLine("        /// </summary>");

                var needsCasting = token.Value > int.MaxValue || token.Value < 0;
                if (needsCasting)
                {
                    Debug.WriteLine($"Warning: casting overflowing enum value \"{token.Name}\" from 64-bit to 32-bit.");
                    valueString = $"unchecked((int){valueString})";
                }

                if (token.IsDeprecated)
                {
                    sw.Write("        [Obsolete(\"Deprecated");
                    if (token.DeprecatedIn != null)
                    {
                        sw.Write(" since " + token.DeprecatedIn);
                    }

                    sw.WriteLine("\")]");
                }

                if (token != tokens.Last())
                {
                    sw.WriteLine($"        {token.Name} = {valueString},");
                }
                else
                {
                    sw.WriteLine($"        {token.Name} = {valueString}");
                }
            }
        }
    }
}
