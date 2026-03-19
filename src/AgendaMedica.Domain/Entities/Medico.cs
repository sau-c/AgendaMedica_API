using AgendaMedica.Domain.ValueObjects;

namespace AgendaMedica.Domain.Entities
{
    public class Medico : BaseEntity
    {
        public Texto Nombre { get; private set; }
        public Texto ApellidoPaterno { get; private set; }
        public Texto ApellidoMaterno { get; private set; }
        private readonly List<Especialidad> _especialidades = new();
        private readonly List<HorarioConsulta> _horariosConsulta = new();
        public IReadOnlyCollection<Especialidad> Especialidades => _especialidades.AsReadOnly();
        public IReadOnlyCollection<HorarioConsulta> HorariosConsulta => _horariosConsulta.AsReadOnly();

        // Constructor privado para EF Core
        private Medico() { }

        private Medico(
            Texto nombre,
            Texto apellidoPaterno,
            Texto apellidoMaterno
            )
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
        }

        public static Medico Crear(
            Texto nombre,
            Texto apellidoPaterno,
            Texto apellidoMaterno,
            List<Especialidad>? especialidades = null,
            List<HorarioConsulta>? horarios = null
            )
        {
            Medico medico = new Medico(
                nombre,
                apellidoPaterno,
                apellidoMaterno
            );

            if (especialidades != null)
            {
                foreach (var esp in especialidades)
                    medico.AgregarEspecialidad(esp);
            }

            //if (horarios != null)
            //{
            //    foreach (var horario in horarios)
            //        medico.AgregarHorario(horario);
            //}

            return medico;
        }

        public void Actualizar(
            Texto nombre,
            Texto apellidoPaterno,
            Texto apellidoMaterno,
            List<Especialidad> especialidades
            )
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            SincronizarEspecialidades(especialidades);
        }


        public void AgregarEspecialidad(Especialidad especialidad)
        {
            if (especialidad == null)
                throw new ArgumentNullException(nameof(especialidad));

            if (_especialidades.Any(e => e.Id == especialidad.Id))
                return;

            _especialidades.Add(especialidad);
        }

        public void RemoverEspecialidad(Guid especialidadId)
        {
            var especialidad = _especialidades
                .FirstOrDefault(e => e.Id == especialidadId);

            if (especialidad != null)
                _especialidades.Remove(especialidad);
        }

        private void SincronizarEspecialidades(List<Especialidad> nuevas)
        {
            var actualesIds = _especialidades.Select(e => e.Id).ToList();
            var nuevosIds = nuevas.Select(e => e.Id).ToList();

            foreach (var id in actualesIds.Except(nuevosIds))
                RemoverEspecialidad(id);

            foreach (var esp in nuevas.Where(e => !actualesIds.Contains(e.Id)))
                AgregarEspecialidad(esp);
        }

        //public void AgregarHorario(HorarioConsulta horario)
        //{
        //    if (horario == null)
        //        throw new ArgumentNullException(nameof(horario));

        //    if (_horariosConsulta.Any(e => e.Id == horario.id))
        //        return;

        //    _especialidades.Add(horario);
        //}

        //public void RemoverHorario(Guid horarioId)
        //{
        //    var horario = _horariosConsulta
        //        .FirstOrDefault(e => e.Id == especialidadId);

        //    if (especialidad != null)
        //        _especialidades.Remove(especialidad);
        //}
    }
}
