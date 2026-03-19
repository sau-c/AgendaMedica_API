using AgendaMedica.Domain.Enums;

namespace AgendaMedica.Domain.Entities
{
    public sealed class Cita : BaseEntity
    {
        // ── Propiedades ─────
        public Guid MedicoId { get; private set; }
        public Guid PacienteId { get; private set; }

        /// <summary>Fecha y hora de inicio de la cita.</summary>
        public DateTime FechaHora { get; private set; }

        /// <summary>Hora de fin calculada.</summary>
        public DateTime FechaHoraFin;
        public EstadoCitaEnum Estado { get; private set; } = EstadoCitaEnum.PENDIENTE;
        public string MotivoConsulta { get; private set; } = string.Empty;
        public string? MotivoCancelacion { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }

        /// <summary>
        /// Flag de alerta: paciente con 3+ cancelaciones en 30 días (Regla #5).
        /// Solo informativo, no bloquea el agendamiento.
        /// </summary>
        public bool AlertaCancelacionesFrecuentes { get; private set; }

        // Navegación (para EF Core)
        public Medico? Medico { get; private set; }
        public Paciente? Paciente { get; private set; }

        private Cita(
            Guid medicoId,
            Guid pacienteId,
            DateTime fechaHora,
            Guid especialidadId,
            string motivoConsulta)
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
            FechaHora = fechaHora;
            MotivoConsulta = motivoConsulta;
        }

        // Constructor para EF Core
        private Cita() { }

        public static Cita Crear(
            Guid MedicoId,
            Guid pacienteId,
            Guid especialidadId,
            DateTime fechaHora,
            string motivo
            )
        {
            // ── Regla #4: Sin citas pasadas
            if (fechaHora <= DateTime.UtcNow)
                throw new ArgumentException("No se pueden agendar citas en fechas/horas que ya pasaron");

            // ── Regla #5: Alerta por cancelaciones frecuentes
            //if (cancelacionesPaciente30Dias >= 3)
            //    throw new Exception("No se pueden agendar mas citas, ya que cancelaste mas de 5 citas");

            return new Cita(
                pacienteId,
                pacienteId,
                fechaHora,
                especialidadId,
                motivo
                );
        }

        /// <summary>
        /// Cancela la cita con un motivo obligatorio.
        /// </summary>
        public void Cancelar(string motivoCancelacion)
        {
            if (string.IsNullOrWhiteSpace(motivoCancelacion))
                throw new ArgumentException("Debe dar un motivo de la cancelacion");

            Estado = EstadoCitaEnum.CANCELADA;
            MotivoCancelacion = motivoCancelacion.Trim();
            FechaCancelacion = DateTime.UtcNow;
        }

        /// <summary>
        /// Marca la cita como completada.
        /// </summary>
        public void Completar()
        {
            if (Estado == EstadoCitaEnum.CANCELADA)
                throw new Exception("No se puede completar una cita cancelada.");

            if (Estado == EstadoCitaEnum.COMPLETADA)
                throw new Exception("La cita ya fue completada.");

            Estado = EstadoCitaEnum.COMPLETADA;
        }

        /// <summary>
        /// Determina si dos intervalos de tiempo se solapan.
        /// Regla #1: a.inicio &lt; b.fin AND b.inicio &lt; a.fin
        /// </summary>
        private static bool HaySolapamiento(
            DateTime inicioA, DateTime finA,
            DateTime inicioB, DateTime finB)
            => inicioA < finB && inicioB < finA;

        /// <summary>
        /// Indica si la cita está activa (puede ser consultada o cancelada).
        /// </summary>
        public bool EstaActiva => Estado == EstadoCitaEnum.PENDIENTE;

        /// <summary>
        /// Indica si la cita ya ocurrió (pasada en el tiempo).
        /// </summary>
        public bool EsPasada => FechaHora < DateTime.UtcNow;
    }
}
