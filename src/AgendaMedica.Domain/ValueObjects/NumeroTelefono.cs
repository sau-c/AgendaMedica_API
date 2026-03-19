using System.Text.RegularExpressions;

namespace AgendaMedica.Domain.ValueObjects
{
    public sealed class NumeroTelefono
    {
        public string Valor { get; }
        private static readonly Regex SoloNumeroTelefonico =
            new Regex(@"^\+?\d{8,15}$", RegexOptions.Compiled);

        private NumeroTelefono() { }
        private NumeroTelefono(string valor) => Valor = valor;
        public static NumeroTelefono Crear(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El número de teléfono no puede estar vacío.");

            var normalizado = Normalizar(numero);

            if (!SoloNumeroTelefonico.IsMatch(normalizado))
                throw new ArgumentException("El número de teléfono no es válido.");

            return new NumeroTelefono(normalizado);
        }

        private static string Normalizar(string numero)
        {
            // Quita espacios, guiones, paréntesis
            return numero
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "");
        }
    }
}