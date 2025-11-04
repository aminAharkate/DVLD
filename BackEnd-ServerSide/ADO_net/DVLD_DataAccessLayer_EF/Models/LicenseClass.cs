using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class LicenseClass
{
    [Key]
    [Column("LicenseClassID")]
    public int LicenseClassId { get; set; }

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [StringLength(500)]
    public string ClassDescription { get; set; } = null!;

    /// <summary>
    /// Minmum age allowed to apply for this license
    /// </summary>
    public byte MinimumAllowedAge { get; set; }

    /// <summary>
    /// How many years the licesnse will be valid.
    /// </summary>
    public byte DefaultValidityLength { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal ClassFees { get; set; }

    [InverseProperty("LicenseClassNavigation")]
    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    [InverseProperty("LicenseClass")]
    public virtual ICollection<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; } = new List<LocalDrivingLicenseApplication>();
}
