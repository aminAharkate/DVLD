using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(20)]
    public string UserName { get; set; } = null!;

    [StringLength(20)]
    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<DetainedLicense> DetainedLicenseCreatedByUsers { get; set; } = new List<DetainedLicense>();

    [InverseProperty("ReleasedByUser")]
    public virtual ICollection<DetainedLicense> DetainedLicenseReleasedByUsers { get; set; } = new List<DetainedLicense>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    [ForeignKey("PersonId")]
    [InverseProperty("Users")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
