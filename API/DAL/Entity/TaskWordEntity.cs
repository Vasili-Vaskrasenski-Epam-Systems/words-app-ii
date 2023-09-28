namespace DAL.Entity
{
    public class TaskWordEntity: BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid WordId { get; set; }
        public virtual TaskEntity Task { get; set; }
        public virtual WordEntity Word { get; set; }
    }
}
