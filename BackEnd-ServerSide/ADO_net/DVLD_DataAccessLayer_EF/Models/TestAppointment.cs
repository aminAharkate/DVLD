using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class TestAppointment
{
    [Key]
    [Column("TestAppointmentID")]
    public int TestAppointmentId { get; set; }

    [Column("TestTypeID")]
    public int TestTypeId { get; set; }

    [Column("LocalDrivingLicenseApplicationID")]
    public int LocalDrivingLicenseApplicationId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime AppointmentDate { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal PaidFees { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    public bool IsLocked { get; set; }

    [Column("RetakeTestApplicationID")]
    public int? RetakeTestApplicationId { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("TestAppointments")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("LocalDrivingLicenseApplicationId")]
    [InverseProperty("TestAppointments")]
    public virtual LocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; } = null!;

    [ForeignKey("RetakeTestApplicationId")]
    [InverseProperty("TestAppointments")]
    public virtual Application? RetakeTestApplication { get; set; }

    [ForeignKey("TestTypeId")]
    [InverseProperty("TestAppointments")]
    public virtual TestType TestType { get; set; } = null!;

    [InverseProperty("TestAppointment")]
    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
