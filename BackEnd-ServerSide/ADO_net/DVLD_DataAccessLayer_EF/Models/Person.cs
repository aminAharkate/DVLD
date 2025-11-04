using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class Person
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(20)]
    public string NationalNo { get; set; } = null!;

    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [StringLength(20)]
    public string? SecondName { get; set; }

    [StringLength(20)]
    public string? ThirdName { get; set; }

    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// 0 Male , 1 Femail
    /// </summary>
    public byte Gendor { get; set; }

    [StringLength(500)]
    public string Address { get; set; } = null!;

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    public string? Email { get; set; }

    [Column("NationalityCountryID")]
    public int NationalityCountryId { get; set; }

    [StringLength(250)]
    public string? ImagePath { get; set; }

    [InverseProperty("ApplicantPerson")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [InverseProperty("Person")]
    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    [ForeignKey("NationalityCountryId")]
    [InverseProperty("People")]
    public virtual Country NationalityCountry { get; set; } = null!;

    [InverseProperty("Person")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
