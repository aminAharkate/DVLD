using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

[Keyless]
public partial class LocalDrivingLicenseApplicationsView
{
    [Column("LocalDrivingLicenseApplicationID")]
    public int LocalDrivingLicenseApplicationId { get; set; }

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [StringLength(20)]
    public string NationalNo { get; set; } = null!;

    [StringLength(83)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ApplicationDate { get; set; }

    public int? PassedTestCount { get; set; }

    [StringLength(9)]
    [Unicode(false)]
    public string? Status { get; set; }
}
