using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

[Keyless]
public partial class DetainedLicensesView
{
    [Column("DetainID")]
    public int DetainId { get; set; }

    [Column("LicenseID")]
    public int LicenseId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DetainDate { get; set; }

    public bool IsReleased { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal FineFees { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? ReleaseDate { get; set; }

    [StringLength(20)]
    public string? NationalNo { get; set; }

    [StringLength(83)]
    public string? FullName { get; set; }

    [Column("ReleaseApplicationID")]
    public int? ReleaseApplicationId { get; set; }
}
