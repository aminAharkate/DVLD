using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class Test
{
    [Key]
    [Column("TestID")]
    public int TestId { get; set; }

    [Column("TestAppointmentID")]
    public int TestAppointmentId { get; set; }

    /// <summary>
    /// 0 - Fail 1-Pass
    /// </summary>
    public bool TestResult { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Tests")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("TestAppointmentId")]
    [InverseProperty("Tests")]
    public virtual TestAppointment TestAppointment { get; set; } = null!;
}
