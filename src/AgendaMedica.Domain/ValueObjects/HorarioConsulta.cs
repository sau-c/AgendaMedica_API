namespace AgendaMedica.Domain.ValueObjects
{
    public sealed class HorarioConsulta
    {
        public int Id { get; }
        public Guid MedicoId { get; }
        public DayOfWeek DiaSemana { get; }
        public TimeOnly HoraInicio { get; }
        public TimeOnly HoraFin { get; }

        private HorarioConsulta() { } // Para EF Core   
        private HorarioConsulta(DayOfWeek dia, TimeOnly inicio, TimeOnly fin)
        {
            DiaSemana = dia;
            HoraInicio = inicio;
            HoraFin = fin;
        }

        public static HorarioConsulta Crear(DayOfWeek dia, TimeOnly inicio, TimeOnly fin)
        {
            if (inicio >= fin)
                throw new ArgumentException("HorarioInvalido");

            return new HorarioConsulta(dia, inicio, fin);
        }

        ///// <summary>
        ///// Verifica si una cita cabe dentro de este horario considerando su duración.
        ///// Regla #3: La última cita debe TERMINAR dentro del horario.
        ///// </summary>
        //public bool PuedeAgregarCita(TimeOnly horaCita, int duracionMinutos)
        //{
        //    if (horaCita < HoraInicio) return false;

        //    var horaFin = horaCita.AddMinutes(duracionMinutos);
        //    return horaFin <= HoraFin;
        //}
    }
}
