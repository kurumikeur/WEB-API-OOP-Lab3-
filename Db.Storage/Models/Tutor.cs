using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Db.Storage.Models;

[Index(nameof(IsnCenter))]
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

    [InverseProperty(nameof(TutorClient.Tutor))]
    public virtual ICollection<TutorClient> TutorClients { get; set; }

    [InverseProperty(nameof(TutorClient.Tutor))]
    public virtual ICollection<CenterTutor> TutorCenters { get; set; } 

}
