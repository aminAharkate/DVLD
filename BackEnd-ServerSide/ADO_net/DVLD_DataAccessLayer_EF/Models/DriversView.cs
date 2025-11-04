using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

[Keyless]
public partial class DriversView
{
    [Column("DriverID")]
    public int DriverId { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(20)]
    public string NationalNo { get; set; } = null!;

    [StringLength(83)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime CreatedDate { get; set; }

    public int? NumberOfActiveLicenses { get; set; }
}
