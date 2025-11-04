using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class DetainedLicense
{
    [Key]
    [Column("DetainID")]
    public int DetainId { get; set; }

    [Column("LicenseID")]
    public int LicenseId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DetainDate { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal FineFees { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    public bool IsReleased { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? ReleaseDate { get; set; }

    [Column("ReleasedByUserID")]
    public int? ReleasedByUserId { get; set; }

    [Column("ReleaseApplicationID")]
    public int? ReleaseApplicationId { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("DetainedLicenseCreatedByUsers")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("LicenseId")]
    [InverseProperty("DetainedLicenses")]
    public virtual License License { get; set; } = null!;

    [ForeignKey("ReleaseApplicationId")]
    [InverseProperty("DetainedLicenses")]
    public virtual Application? ReleaseApplication { get; set; }

    [ForeignKey("ReleasedByUserId")]
    [InverseProperty("DetainedLicenseReleasedByUsers")]
    public virtual User? ReleasedByUser { get; set; }
}
