namespace BootcampHomework.Entities
{
    public class Department:BaseEntity
    {
        public string DepartmentName { get; set; }

        public int CountryId { get; set; }

        //Relational Property
        public virtual Country Country { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
