using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Models.Commons
{
    public interface IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
