using System.ComponentModel.DataAnnotations.Schema;

namespace BootcampHomework.Entities
{
    public abstract class BaseEntity
    {
        //Costractor sayesinde bu classdan kalıtım alan sınıfın CreatedDate ve Status propertylerine ilk degeri atıyoruz.
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            Status = DataStatus.inserted;
        }


        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DataStatus Status { get; set; }
    }
}
