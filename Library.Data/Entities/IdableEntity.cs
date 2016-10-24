using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public abstract class IdableEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTime _addedDate;
        public DateTime AddedDate
        {
            get { return DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc); }
            private set { _addedDate = value; }
        }

        protected IdableEntity()
        {
            Id = Guid.NewGuid();
            AddedDate = DateTime.UtcNow;
        }
    }
}
