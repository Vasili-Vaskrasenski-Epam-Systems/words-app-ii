namespace DAL.Entity
{
    public class TaskEntity: BaseEntity
    {
        public string TaskName { get; set; }
        public DateTime TaskDate { get; set; }
        public virtual ICollection<TaskWordEntity> TaskWords { get; set; }
    }
}
