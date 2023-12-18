using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN.Models
{
    [Table("Tb_Room")]
    public class TbRoom
    {
        [Key]
        public int RoomId { get; set; }

        public string Title { get; set; }

        public string? Alias { get; set; }

        public int? CategoryRoomId { get; set; }

        public string? Description { get; set; }

        public string? Detail { get; set; }

        public string? Image { get; set; }

        public int? Price { get; set; }


        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public bool IsNew { get; set; }

        public bool IsActive { get; set; }

    }
    
}
