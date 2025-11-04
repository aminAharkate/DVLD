using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

[Keyless]
public partial class LocalDrivingLicenseFullApplicationsView
{
    [Column("ApplicationID")]
    public int ApplicationId { get; set; }

    [Column("ApplicantPersonID")]
    public int ApplicantPersonId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ApplicationDate { get; set; }

    [Column("ApplicationTypeID")]
    public int ApplicationTypeId { get; set; }

    public byte ApplicationStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LastStatusDate { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal PaidFees { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column("LocalDrivingLicenseApplicationID")]
    public int LocalDrivingLicenseApplicationId { get; set; }

    [Column("LicenseClassID")]
    public int LicenseClassId { get; set; }
}
