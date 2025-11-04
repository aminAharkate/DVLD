using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

[Keyless]
public partial class TestAppointmentsView
{
    [Column("TestAppointmentID")]
    public int TestAppointmentId { get; set; }

    [Column("LocalDrivingLicenseApplicationID")]
    public int LocalDrivingLicenseApplicationId { get; set; }

    [StringLength(100)]
    public string TestTypeTitle { get; set; } = null!;

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime AppointmentDate { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal PaidFees { get; set; }

    [StringLength(83)]
    public string FullName { get; set; } = null!;

    public bool IsLocked { get; set; }
}
