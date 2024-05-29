using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Storage.Models;

public class Tutor
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnNode { get; set; }

    [ForeignKey(nameof(Center))]
    public Guid IsnCenter { get; set; }

    [Required, MaxLength(255)]
    public string SurName { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; }

    [Required, MaxLength(255)]
    public string LastName { get; set; }

    [Required, MinLength(255)]
    public string Subject { get; set; }

    [Required, MinLength(255)]
    public string Price { get; set; }

    public virtual ICollection<Client> Clients { get; set; }

    public virtual Center Center { get; set; }
}
