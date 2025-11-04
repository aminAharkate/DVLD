using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DVLD_DataAccessLayer_EF.Models;

public partial class DVLD_DbContext : DbContext
{
    public DVLD_DbContext()
    {
    }

    public DVLD_DbContext(DbContextOptions<DVLD_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DetainedLicense> DetainedLicenses { get; set; }

    public virtual DbSet<DetainedLicensesView> DetainedLicensesViews { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriversView> DriversViews { get; set; }

    public virtual DbSet<InternationalLicense> InternationalLicenses { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<LicenseClass> LicenseClasses { get; set; }

    public virtual DbSet<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; }

    public virtual DbSet<LocalDrivingLicenseApplicationsView> LocalDrivingLicenseApplicationsViews { get; set; }

    public virtual DbSet<LocalDrivingLicenseFullApplicationsView> LocalDrivingLicenseFullApplicationsViews { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestAppointment> TestAppointments { get; set; }

    public virtual DbSet<TestAppointmentsView> TestAppointmentsViews { get; set; }

    public virtual DbSet<TestType> TestTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DVLD_V2;User Id=sa;Password=123456789;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.Property(e => e.ApplicationStatus)
                .HasDefaultValue((byte)1)
                .HasComment("1-New 2-Cancelled 3-Completed");

            entity.HasOne(d => d.ApplicantPerson).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_People");

            entity.HasOne(d => d.ApplicationType).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_ApplicationTypes");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_Users");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BFDBD6933F");
        });

        modelBuilder.Entity<DetainedLicense>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.DetainedLicenseCreatedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetainedLicenses_Users");

            entity.HasOne(d => d.License).WithMany(p => p.DetainedLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetainedLicenses_Licenses");

            entity.HasOne(d => d.ReleaseApplication).WithMany(p => p.DetainedLicenses).HasConstraintName("FK_DetainedLicenses_Applications");

            entity.HasOne(d => d.ReleasedByUser).WithMany(p => p.DetainedLicenseReleasedByUsers).HasConstraintName("FK_DetainedLicenses_Users1");
        });

        modelBuilder.Entity<DetainedLicensesView>(entity =>
        {
            entity.ToView("DetainedLicenses_View");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK_Drivers_1");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Drivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_Users");

            entity.HasOne(d => d.Person).WithMany(p => p.Drivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_People");
        });

        modelBuilder.Entity<DriversView>(entity =>
        {
            entity.ToView("Drivers_View");
        });

        modelBuilder.Entity<InternationalLicense>(entity =>
        {
            entity.HasOne(d => d.Application).WithMany(p => p.InternationalLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Applications");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.InternationalLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Users");

            entity.HasOne(d => d.Driver).WithMany(p => p.InternationalLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Drivers");

            entity.HasOne(d => d.IssuedUsingLocalLicense).WithMany(p => p.InternationalLicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Licenses");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IssueReason)
                .HasDefaultValue((byte)1)
                .HasComment("1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.");

            entity.HasOne(d => d.Application).WithMany(p => p.Licenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Applications");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Licenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Users");

            entity.HasOne(d => d.Driver).WithMany(p => p.Licenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Drivers");

            entity.HasOne(d => d.LicenseClassNavigation).WithMany(p => p.Licenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_LicenseClasses");
        });

        modelBuilder.Entity<LicenseClass>(entity =>
        {
            entity.Property(e => e.DefaultValidityLength)
                .HasDefaultValue((byte)1)
                .HasComment("How many years the licesnse will be valid.");
            entity.Property(e => e.MinimumAllowedAge)
                .HasDefaultValue((byte)18)
                .HasComment("Minmum age allowed to apply for this license");
        });

        modelBuilder.Entity<LocalDrivingLicenseApplication>(entity =>
        {
            entity.HasKey(e => e.LocalDrivingLicenseApplicationId).HasName("PK_DrivingLicsenseApplications");

            entity.HasOne(d => d.Application).WithMany(p => p.LocalDrivingLicenseApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DrivingLicsenseApplications_Applications");

            entity.HasOne(d => d.LicenseClass).WithMany(p => p.LocalDrivingLicenseApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DrivingLicsenseApplications_LicenseClasses");
        });

        modelBuilder.Entity<LocalDrivingLicenseApplicationsView>(entity =>
        {
            entity.ToView("LocalDrivingLicenseApplications_View");
        });

        modelBuilder.Entity<LocalDrivingLicenseFullApplicationsView>(entity =>
        {
            entity.ToView("LocalDrivingLicenseFullApplications_View");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Gendor).HasComment("0 Male , 1 Femail");

            entity.HasOne(d => d.NationalityCountry).WithMany(p => p.People)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_People_Countries1");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.TestResult).HasComment("0 - Fail 1-Pass");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Tests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_Users");

            entity.HasOne(d => d.TestAppointment).WithMany(p => p.Tests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_TestAppointments");
        });

        modelBuilder.Entity<TestAppointment>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.TestAppointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointments_Users");

            entity.HasOne(d => d.LocalDrivingLicenseApplication).WithMany(p => p.TestAppointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointments_LocalDrivingLicenseApplications");

            entity.HasOne(d => d.RetakeTestApplication).WithMany(p => p.TestAppointments).HasConstraintName("FK_TestAppointments_Applications");

            entity.HasOne(d => d.TestType).WithMany(p => p.TestAppointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointments_TestTypes");
        });

        modelBuilder.Entity<TestAppointmentsView>(entity =>
        {
            entity.ToView("TestAppointments_View");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
