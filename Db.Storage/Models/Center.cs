using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

    [InverseProperty(nameof(Client.Center))]
    public virtual ICollection<Client> Clients { get; set; }

    [InverseProperty(nameof(CenterTutor.Center))]
    public virtual ICollection<CenterTutor> CenterTutors { get; set; }
}
