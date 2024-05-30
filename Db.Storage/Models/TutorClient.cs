using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Db.Storage.Models;

[Index(nameof(IsnTutor), nameof(IsnClient))]
[PrimaryKey(nameof(IsnTutor), nameof(IsnClient))]
public class TutorClient
{
    [ForeignKey(nameof(Tutor)), Required]
    public Guid IsnTutor { get; set; }

    [ForeignKey(nameof(Client)), Required]
    public Guid IsnClient { get; set; }

    public virtual Tutor Tutor { get; set; }

    public virtual Client Client { get; set; } 
}
