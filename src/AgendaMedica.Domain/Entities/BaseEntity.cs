namespace AgendaMedica.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public bool IsDeleted { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Eliminado logico (softDelete) para auditoria
        /// </summary>
        public void Ocultar() => IsDeleted = true;
    }
}
