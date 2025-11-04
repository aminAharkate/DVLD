using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class Application
{
    [Key]
    [Column("ApplicationID")]
    public int ApplicationId { get; set; }

    [Column("ApplicantPersonID")]
    public int ApplicantPersonId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ApplicationDate { get; set; }

    [Column("ApplicationTypeID")]
    public int ApplicationTypeId { get; set; }

    /// <summary>
    /// 1-New 2-Cancelled 3-Completed
    /// </summary>
    public byte ApplicationStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LastStatusDate { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal PaidFees { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [ForeignKey("ApplicantPersonId")]
    [InverseProperty("Applications")]
    public virtual Person ApplicantPerson { get; set; } = null!;

    [ForeignKey("ApplicationTypeId")]
    [InverseProperty("Applications")]
    public virtual ApplicationType ApplicationType { get; set; } = null!;

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Applications")]
    public virtual User CreatedByUser { get; set; } = null!;

    [InverseProperty("ReleaseApplication")]
    public virtual ICollection<DetainedLicense> DetainedLicenses { get; set; } = new List<DetainedLicense>();

    [InverseProperty("Application")]
    public virtual ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    [InverseProperty("Application")]
    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    [InverseProperty("Application")]
    public virtual ICollection<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; } = new List<LocalDrivingLicenseApplication>();

    [InverseProperty("RetakeTestApplication")]
    public virtual ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
