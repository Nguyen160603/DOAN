using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN.Models;

    [Table ("Tb_BlogComment")]
public partial class TbBlogComment
{
    [Key]
    public int CommentId { get; set; }

    public string? Name { get; set; }



    public string? Email { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? BlogId { get; set; }

    public bool IsActive { get; set; }

    public virtual TbBlog? Blog { get; set; }
}