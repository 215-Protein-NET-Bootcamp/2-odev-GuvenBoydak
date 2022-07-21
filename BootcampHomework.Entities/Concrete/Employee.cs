namespace BootcampHomework.Entities
{
    public class Employee:BaseEntity
    {
        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }

        //Relational Property
        public virtual Department Department { get; set; }

        public virtual List<Folder> Folders { get; set; }
    }
}
