namespace DAL.Entity
{
    public class WordEntity: BaseEntity
    {
        public int Number { get; set; }
        public string Word { get; set; } 
        public string Translation { get; set; }
        public virtual ICollection<TaskWordEntity> TaskWords { get; set; }
    }
}