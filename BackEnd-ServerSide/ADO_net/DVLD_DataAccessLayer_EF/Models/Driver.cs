using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class Driver
{
    [Key]
    [Column("DriverID")]
    public int DriverId { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Drivers")]
    public virtual User CreatedByUser { get; set; } = null!;

    [InverseProperty("Driver")]
    public virtual ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    [InverseProperty("Driver")]
    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    [ForeignKey("PersonId")]
    [InverseProperty("Drivers")]
    public virtual Person Person { get; set; } = null!;
}
