using System.Text.RegularExpressions;

namespace AgendaMedica.Domain.ValueObjects
{
    public sealed class CorreoElectronico
    {
        public string Valor { get; }
        private static readonly Regex FormatoEmail = new(
            @"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        private const int LongitudMaxima = 254;

        private CorreoElectronico() { }
        public static CorreoElectronico Crear(string valor) => new(valor);
        private CorreoElectronico(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException(
                    "El correo electrónico no puede estar vacío.", nameof(valor));

            valor = valor.Trim().ToLowerInvariant();

            if (valor.Length > LongitudMaxima)
                throw new ArgumentException(
                    $"El correo electrónico no puede superar {LongitudMaxima} caracteres.", nameof(valor));

            if (!FormatoEmail.IsMatch(valor))
                throw new ArgumentException(
                    $"'{valor}' no es un correo electrónico válido.", nameof(valor));

            Valor = valor;
        }
    }
}