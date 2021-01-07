using System;
using Happy.Weddings.Identity.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Happy.Weddings.Identity.Data.DatabaseContext
{
    public partial class IdentityContext : DbContext
    {
        public IdentityContext()
        {
        }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Companydistricts> Companydistricts { get; set; }
        public virtual DbSet<Gstdetails> Gstdetails { get; set; }
        public virtual DbSet<Kycdata> Kycdata { get; set; }
        public virtual DbSet<Kycdetails> Kycdetails { get; set; }
        public virtual DbSet<Multicode> Multicode { get; set; }
        public virtual DbSet<Multidetail> Multidetail { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Profileapprovalstatus> Profileapprovalstatus { get; set; }
        public virtual DbSet<Profilepermission> Profilepermission { get; set; }
        public virtual DbSet<Profilestatus> Profilestatus { get; set; }
        public virtual DbSet<Rolesettings> Rolesettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=sa123;database=happy-wed-identityy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companydistricts>(entity =>
            {
                entity.ToTable("companydistricts");

                entity.HasIndex(e => e.District)
                    .HasName("distId_idx");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("pId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.ProfileId).HasColumnName("profileId");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.Companydistricts)
                    .HasForeignKey(d => d.District)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("distId");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Companydistricts)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pId");
            });

            modelBuilder.Entity<Gstdetails>(entity =>
            {
                entity.ToTable("gstdetails");

                entity.HasIndex(e => e.Gstcity)
                    .HasName("kyccity_idx");

                entity.HasIndex(e => e.Gststate)
                    .HasName("kycstate_idx");

                entity.HasIndex(e => e.Kycid)
                    .HasName("kycids_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gstcity).HasColumnName("GSTCity");

                entity.Property(e => e.Gstdocument)
                    .IsRequired()
                    .HasColumnName("GSTDocument")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Gstnumber)
                    .IsRequired()
                    .HasColumnName("GSTNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gststate).HasColumnName("GSTState");

                entity.Property(e => e.Kycid).HasColumnName("KYCId");

                entity.HasOne(d => d.GstcityNavigation)
                    .WithMany(p => p.GstdetailsGstcityNavigation)
                    .HasForeignKey(d => d.Gstcity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kyccity");

                entity.HasOne(d => d.GststateNavigation)
                    .WithMany(p => p.GstdetailsGststateNavigation)
                    .HasForeignKey(d => d.Gststate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kycstate");

                entity.HasOne(d => d.Kyc)
                    .WithMany(p => p.Gstdetails)
                    .HasForeignKey(d => d.Kycid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kycids");
            });

            modelBuilder.Entity<Kycdata>(entity =>
            {
                entity.ToTable("kycdata");

                entity.HasIndex(e => e.Kycid)
                    .HasName("kycId_idx");

                entity.HasIndex(e => e.Kycstatus)
                    .HasName("kycstatus_idx");

                entity.HasIndex(e => e.VendorId)
                    .HasName("vendorid_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kycid).HasColumnName("KYCId");

                entity.Property(e => e.Kycstatus).HasColumnName("KYCStatus");

                entity.HasOne(d => d.Kyc)
                    .WithMany(p => p.KycdataKyc)
                    .HasForeignKey(d => d.Kycid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kycid");

                entity.HasOne(d => d.KycstatusNavigation)
                    .WithMany(p => p.KycdataKycstatusNavigation)
                    .HasForeignKey(d => d.Kycstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kycstatus");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Kycdata)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vendorid");
            });

            modelBuilder.Entity<Kycdetails>(entity =>
            {
                entity.ToTable("kycdetails");

                entity.HasIndex(e => e.Kycid)
                    .HasName("kycid_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.KycdocPath)
                    .HasColumnName("KYCDocPath")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kycid).HasColumnName("KYCId");

                entity.HasOne(d => d.Kyc)
                    .WithMany(p => p.Kycdetails)
                    .HasForeignKey(d => d.Kycid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kycdetailsid");
            });

            modelBuilder.Entity<Multicode>(entity =>
            {
                entity.ToTable("multicode");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsRequired)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Multidetail>(entity =>
            {
                entity.ToTable("multidetail");

                entity.HasIndex(e => e.MultiCodeId)
                    .HasName("code_id_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MultiCode)
                    .WithMany(p => p.Multidetail)
                    .HasForeignKey(d => d.MultiCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("code_id");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("approval-status_idx");

                entity.HasIndex(e => e.Country)
                    .HasName("country-id_idx");

                entity.HasIndex(e => e.District)
                    .HasName("disrict-id_idx");

                entity.HasIndex(e => e.Gender)
                    .HasName("gender_idx");

                entity.HasIndex(e => e.ProfileStatus)
                    .HasName("profilestatus_idx");

                entity.HasIndex(e => e.Role)
                    .HasName("role-id_idx");

                entity.HasIndex(e => e.State)
                    .HasName("state-id_idx");

                entity.HasIndex(e => new { e.Country, e.State, e.Role })
                    .HasName("country_idx");

                entity.Property(e => e.Aadhar)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyLogo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleProfile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsc)
                    .HasColumnName("IFSC")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstagramLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsPhoneVerified)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListingAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ListingName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListingPincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Otp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasColumnName("PAN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PintrestLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryMobileNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryMobileNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TwitterHandle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.ProfileApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .HasConstraintName("approval-status");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.ProfileCountryNavigation)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("country-id");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.ProfileDistrictNavigation)
                    .HasForeignKey(d => d.District)
                    .HasConstraintName("dist-id");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.ProfileGenderNavigation)
                    .HasForeignKey(d => d.Gender)
                    .HasConstraintName("gender-id");

                entity.HasOne(d => d.ProfileStatusNavigation)
                    .WithMany(p => p.ProfileProfileStatusNavigation)
                    .HasForeignKey(d => d.ProfileStatus)
                    .HasConstraintName("profilestatus");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.ProfileRoleNavigation)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role-id");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.ProfileStateNavigation)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("state-id");
            });

            modelBuilder.Entity<Profileapprovalstatus>(entity =>
            {
                entity.ToTable("profileapprovalstatus");

                entity.HasIndex(e => e.ApprovalStatusId)
                    .HasName("approvalstatus_idx");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profile_id_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.Profileapprovalstatus)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("approvalstatus");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Profileapprovalstatus)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profile_id");
            });

            modelBuilder.Entity<Profilepermission>(entity =>
            {
                entity.ToTable("profilepermission");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profileId_idx");

                entity.HasIndex(e => e.RoleId)
                    .HasName("roleId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePermissions)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Profilepermission)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profileid");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Profilepermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profileroleid");
            });

            modelBuilder.Entity<Profilestatus>(entity =>
            {
                entity.ToTable("profilestatus");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("pid_idx");

                entity.HasIndex(e => e.ProfileStatusId)
                    .HasName("pstatus_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Profilestatuses)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("p_id");

                entity.HasOne(d => d.ProfileStatus)
                    .WithMany(p => p.Profilestatus)
                    .HasForeignKey(d => d.ProfileStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pstatus");
            });

            modelBuilder.Entity<Rolesettings>(entity =>
            {
                entity.ToTable("rolesettings");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role-id_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RolePermissions)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Rolesettings)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
