using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Storage.Models;

[Index(nameof(IsnCenter), nameof(IsnTutor))]
[PrimaryKey(nameof(IsnCenter), nameof(IsnTutor))]
public class CenterTutor
{
    [ForeignKey(nameof(Client)), Required]
    public Guid IsnCenter { get; set; }


    [ForeignKey(nameof(Tutor)), Required]
    public Guid IsnTutor { get; set; }

    public virtual Center Center { get; set; }

    public virtual Tutor Tutor { get; set; }

}


