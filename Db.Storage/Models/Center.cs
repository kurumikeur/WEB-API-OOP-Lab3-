using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Storage.Models;

[Index(nameof(Name))]
public class Center
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnNode { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; }

    [InverseProperty(nameof(User.Center))]
    public virtual ICollection<User> Users { get; set; }
}
