using System;
using Happy.Weddings.LeadManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Happy.Weddings.LeadManagement.Data.DatabaseContext
{
    public partial class LeadContext : DbContext
    {
        public LeadContext()
        {
        }

        public LeadContext(DbContextOptions<LeadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Leadassign> Leadassign { get; set; }
        public virtual DbSet<Leaddatacollection> Leaddatacollection { get; set; }
        public virtual DbSet<Leadquote> Leadquote { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Leadstatus> Leadstatus { get; set; }
        public virtual DbSet<Leadvalidation> Leadvalidation { get; set; }
        public virtual DbSet<Multicode> Multicode { get; set; }
        public virtual DbSet<Multidetail> Multidetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=sa123;database=happy-wed-lead");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leadassign>(entity =>
            {
                entity.ToTable("leadassign");

                entity.HasIndex(e => e.Category)
                    .HasName("FK_leadassign_Category_idx");

                entity.HasIndex(e => e.LeadId)
                    .HasName("FK_leadassign_LeadId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.ProposedBudget).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Leadassign)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_leadassign_Category");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Leadassign)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leadassign_LeadId");
            });

            modelBuilder.Entity<Leaddatacollection>(entity =>
            {
                entity.ToTable("leaddatacollection");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLocation)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhone1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Leadquote>(entity =>
            {
                entity.ToTable("leadquote");

                entity.HasIndex(e => e.LeadId)
                    .HasName("ldid_idx");

                entity.HasIndex(e => e.LeadType)
                    .HasName("ldtype_idx");

                entity.HasIndex(e => e.SubLeadType)
                    .HasName("subldtype_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsSelected)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuotedRate).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Leadquote)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ldid");

                entity.HasOne(d => d.LeadTypeNavigation)
                    .WithMany(p => p.LeadquoteLeadTypeNavigation)
                    .HasForeignKey(d => d.LeadType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ldtype");

                entity.HasOne(d => d.SubLeadTypeNavigation)
                    .WithMany(p => p.LeadquoteSubLeadTypeNavigation)
                    .HasForeignKey(d => d.SubLeadType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subldtype");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.HasIndex(e => e.Category)
                    .HasName("FK_leads_Category_idx");

                entity.HasIndex(e => e.DataCollectionId)
                    .HasName("FK_leads_DataCollectionId_idx");

                entity.HasIndex(e => e.EventLocation)
                    .HasName("eventlocation_idx");

                entity.HasIndex(e => e.EventType)
                    .HasName("FK_leads_EventType_idx");

                entity.HasIndex(e => e.LeadMode)
                    .HasName("FK_leads_LeadMode_idx");

                entity.HasIndex(e => e.LeadQuality)
                    .HasName("FK_leads_LeadQuality_idx");

                entity.HasIndex(e => e.LeadStatusId)
                    .HasName("FK_leads_LeadStatus_idx");

                entity.HasIndex(e => e.LeadType)
                    .HasName("FK_leads_LeadType_idx");

                entity.HasIndex(e => e.WalletStatus)
                    .HasName("FK_leads_WalletStatus_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Budget).HasColumnType("decimal(8,2)");

                entity.Property(e => e.CommisionValue).HasColumnType("decimal(10,0)");

                entity.Property(e => e.Cplvalue)
                    .HasColumnName("CPLValue")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LeadId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Revenue).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.LeadsCategoryNavigation)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_Category");

                entity.HasOne(d => d.DataCollection)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.DataCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_DataCollectionId");

                entity.HasOne(d => d.EventLocationNavigation)
                    .WithMany(p => p.LeadsEventLocationNavigation)
                    .HasForeignKey(d => d.EventLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventlocation");

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.LeadsEventTypeNavigation)
                    .HasForeignKey(d => d.EventType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_leads_EventType");

                entity.HasOne(d => d.LeadModeNavigation)
                    .WithMany(p => p.LeadsLeadModeNavigation)
                    .HasForeignKey(d => d.LeadMode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_LeadMode");

                entity.HasOne(d => d.LeadQualityNavigation)
                    .WithMany(p => p.LeadsLeadQualityNavigation)
                    .HasForeignKey(d => d.LeadQuality)
                    .HasConstraintName("FK_leads_LeadQuality");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LeadsLeadStatus)
                    .HasForeignKey(d => d.LeadStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_Status");

                entity.HasOne(d => d.LeadTypeNavigation)
                    .WithMany(p => p.LeadsLeadTypeNavigation)
                    .HasForeignKey(d => d.LeadType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_LeadType");

                entity.HasOne(d => d.WalletStatusNavigation)
                    .WithMany(p => p.LeadsWalletStatusNavigation)
                    .HasForeignKey(d => d.WalletStatus)
                    .HasConstraintName("FK_leads_WalletStatus");
            });

            modelBuilder.Entity<Leadstatus>(entity =>
            {
                entity.ToTable("leadstatus");

                entity.HasIndex(e => e.LeadId)
                    .HasName("FK_leadstatus_leadstatus_idx");

                entity.HasIndex(e => e.LeadStatusId)
                    .HasName("FK_leadstatus_LeadStatusId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Leadstatus)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leadstatus_leadstatus");

                entity.HasOne(d => d.LeadStatus)
                    .WithMany(p => p.Leadstatus)
                    .HasForeignKey(d => d.LeadStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leadstatus_LeadStatusId");
            });

            modelBuilder.Entity<Leadvalidation>(entity =>
            {
                entity.ToTable("leadvalidation");

                entity.HasIndex(e => e.LeadId)
                    .HasName("FK_leadvalidation_LeadId_idx");

                entity.HasIndex(e => e.Status)
                    .HasName("FK_leadvalidation_Status_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CallRecordings)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Leadvalidation)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leadvalidation_LeadId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Leadvalidation)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leadvalidation_Status");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
