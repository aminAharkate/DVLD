using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class TestType
{
    [Key]
    [Column("TestTypeID")]
    public int TestTypeId { get; set; }

    [StringLength(100)]
    public string TestTypeTitle { get; set; } = null!;

    [StringLength(500)]
    public string TestTypeDescription { get; set; } = null!;

    [Column(TypeName = "smallmoney")]
    public decimal TestTypeFees { get; set; }

    [InverseProperty("TestType")]
    public virtual ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
