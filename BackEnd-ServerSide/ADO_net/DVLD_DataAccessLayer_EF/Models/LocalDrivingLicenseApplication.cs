using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class LocalDrivingLicenseApplication
{
    [Key]
    [Column("LocalDrivingLicenseApplicationID")]
    public int LocalDrivingLicenseApplicationId { get; set; }

    [Column("ApplicationID")]
    public int ApplicationId { get; set; }

    [Column("LicenseClassID")]
    public int LicenseClassId { get; set; }

    [ForeignKey("ApplicationId")]
    [InverseProperty("LocalDrivingLicenseApplications")]
    public virtual Application Application { get; set; } = null!;

    [ForeignKey("LicenseClassId")]
    [InverseProperty("LocalDrivingLicenseApplications")]
    public virtual LicenseClass LicenseClass { get; set; } = null!;

    [InverseProperty("LocalDrivingLicenseApplication")]
    public virtual ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
