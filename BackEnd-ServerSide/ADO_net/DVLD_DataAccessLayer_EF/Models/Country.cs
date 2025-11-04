using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class Country
{
    [Key]
    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(50)]
    public string CountryName { get; set; } = null!;

    [InverseProperty("NationalityCountry")]
    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
