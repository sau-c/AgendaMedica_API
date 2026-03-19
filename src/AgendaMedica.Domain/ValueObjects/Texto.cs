using System.Text.RegularExpressions;

namespace AgendaMedica.Domain.ValueObjects
{
    public sealed class Texto
    {
        public string Valor { get; } 
        private static readonly Regex SoloLetras =
            new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);

        private Texto() { }
        private Texto(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException(
                    "El texto no puede estar vacío.", nameof(valor));

            valor = valor?.Trim() ?? string.Empty;
            if (!SoloLetras.IsMatch(valor))
                throw new ArgumentException(
                    $"El valor '{valor}' solo puede contener letras y espacios.");
            
            Valor = valor;
        }

        public static Texto Crear(string valor) => new Texto(valor);

    }
}
