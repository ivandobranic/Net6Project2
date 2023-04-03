namespace Entities.Models
{
    public class BaseModel
    {
        #region Properties

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public DateTime TimeStamp { get; set; }

        #endregion Properties
    }
}