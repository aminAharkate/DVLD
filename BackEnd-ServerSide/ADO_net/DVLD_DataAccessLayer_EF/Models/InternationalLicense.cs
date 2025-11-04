using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class InternationalLicense
{
    [Key]
    [Column("InternationalLicenseID")]
    public int InternationalLicenseId { get; set; }

    [Column("ApplicationID")]
    public int ApplicationId { get; set; }

    [Column("DriverID")]
    public int DriverId { get; set; }

    [Column("IssuedUsingLocalLicenseID")]
    public int IssuedUsingLocalLicenseId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime IssueDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [ForeignKey("ApplicationId")]
    [InverseProperty("InternationalLicenses")]
    public virtual Application Application { get; set; } = null!;

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("InternationalLicenses")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("DriverId")]
    [InverseProperty("InternationalLicenses")]
    public virtual Driver Driver { get; set; } = null!;

    [ForeignKey("IssuedUsingLocalLicenseId")]
    [InverseProperty("InternationalLicenses")]
    public virtual License IssuedUsingLocalLicense { get; set; } = null!;
}
