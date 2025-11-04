using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class ApplicationType
{
    [Key]
    [Column("ApplicationTypeID")]
    public int ApplicationTypeId { get; set; }

    [StringLength(150)]
    public string ApplicationTypeTitle { get; set; } = null!;

    [Column(TypeName = "smallmoney")]
    public decimal ApplicationFees { get; set; }

    [InverseProperty("ApplicationType")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
