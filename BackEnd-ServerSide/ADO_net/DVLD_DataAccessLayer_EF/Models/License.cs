using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class License
{
    [Key]
    [Column("LicenseID")]
    public int LicenseId { get; set; }

    [Column("ApplicationID")]
    public int ApplicationId { get; set; }

    [Column("DriverID")]
    public int DriverId { get; set; }

    public int LicenseClass { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime IssueDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpirationDate { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal PaidFees { get; set; }

    public bool IsActive { get; set; }

    /// <summary>
    /// 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
    /// </summary>
    public byte IssueReason { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [ForeignKey("ApplicationId")]
    [InverseProperty("Licenses")]
    public virtual Application Application { get; set; } = null!;

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Licenses")]
    public virtual User CreatedByUser { get; set; } = null!;

    [InverseProperty("License")]
    public virtual ICollection<DetainedLicense> DetainedLicenses { get; set; } = new List<DetainedLicense>();

    [ForeignKey("DriverId")]
    [InverseProperty("Licenses")]
    public virtual Driver Driver { get; set; } = null!;

    [InverseProperty("IssuedUsingLocalLicense")]
    public virtual ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    [ForeignKey("LicenseClass")]
    [InverseProperty("Licenses")]
    public virtual LicenseClass LicenseClassNavigation { get; set; } = null!;
}
