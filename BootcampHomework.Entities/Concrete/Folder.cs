namespace BootcampHomework.Entities
{
    public class Folder:BaseEntity
    {
        public string AccessType { get; set; }

        public int EmployeeId { get; set; }

        //Relational Property
        public virtual Employee Employee { get; set; }
    }
}
