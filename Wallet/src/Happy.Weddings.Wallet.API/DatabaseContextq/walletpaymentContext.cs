using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Happy.Weddings.Wallet.API.DatabaseContextq
{
    public partial class walletpaymentContext : DbContext
    {
        public walletpaymentContext()
        {
        }

        public walletpaymentContext(DbContextOptions<walletpaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Multicode> Multicode { get; set; }
        public virtual DbSet<Multidetail> Multidetail { get; set; }
        public virtual DbSet<Paymentbook> Paymentbook { get; set; }
        public virtual DbSet<Refund> Refund { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }
        public virtual DbSet<Walletadjustment> Walletadjustment { get; set; }
        public virtual DbSet<Walletdeduction> Walletdeduction { get; set; }
        public virtual DbSet<Walletrule> Walletrule { get; set; }
        public virtual DbSet<Walletstatus> Walletstatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=sa123;database=walletpayment");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Paymentbook>(entity =>
            {
                entity.ToTable("paymentbook");

                entity.HasIndex(e => e.Bhstatus)
                    .HasName("FK_PB_BHStatus_idx");

                entity.HasIndex(e => e.FinanceApprovalStatus)
                    .HasName("FK_PB_FinanceApprovalStatus_idx");

                entity.HasIndex(e => e.PackageType)
                    .HasName("FK_PB_PackageType_idx");

                entity.HasIndex(e => e.PaymentMode)
                    .HasName("FK_PB_PaymentMode_idx");

                entity.HasIndex(e => e.PaymentStatus)
                    .HasName("FK_PB_PaymentStatus_idx");

                entity.HasIndex(e => e.PaymentType)
                    .HasName("FK_PB_PaymentType_idx");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bhcomments)
                    .HasColumnName("BHComments")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bhstatus).HasColumnName("BHStatus");

                entity.Property(e => e.BhstatusDate).HasColumnName("BHStatusDate");

                entity.Property(e => e.BhstatusReason)
                    .HasColumnName("BHStatusReason")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinanceComment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Gst)
                    .HasColumnName("GST")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Ifsc)
                    .HasColumnName("IFSC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kfc)
                    .HasColumnName("KFC")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.PayeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.PaymentDocs)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentRefNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Tds)
                    .HasColumnName("TDS")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TidNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WalletBalance).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.BhstatusNavigation)
                    .WithMany(p => p.PaymentbookBhstatusNavigation)
                    .HasForeignKey(d => d.Bhstatus)
                    .HasConstraintName("FK_PB_BHStatus");

                entity.HasOne(d => d.FinanceApprovalStatusNavigation)
                    .WithMany(p => p.PaymentbookFinanceApprovalStatusNavigation)
                    .HasForeignKey(d => d.FinanceApprovalStatus)
                    .HasConstraintName("FK_PB_FinanceApprovalStatus");

                entity.HasOne(d => d.PackageTypeNavigation)
                    .WithMany(p => p.PaymentbookPackageTypeNavigation)
                    .HasForeignKey(d => d.PackageType)
                    .HasConstraintName("FK_PB_PackageType");

                entity.HasOne(d => d.PaymentModeNavigation)
                    .WithMany(p => p.PaymentbookPaymentModeNavigation)
                    .HasForeignKey(d => d.PaymentMode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PB_PaymentMode");

                entity.HasOne(d => d.PaymentStatusNavigation)
                    .WithMany(p => p.PaymentbookPaymentStatusNavigation)
                    .HasForeignKey(d => d.PaymentStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PB_PaymentStatus");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.PaymentbookPaymentTypeNavigation)
                    .HasForeignKey(d => d.PaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PB_PaymentType");
            });

            modelBuilder.Entity<Refund>(entity =>
            {
                entity.ToTable("refund");

                entity.HasIndex(e => e.Bhstatus)
                    .HasName("FK_BHStatus_idx");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalRemarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Bhstatus).HasColumnName("BHStatus");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.RefundReason)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RefundType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WalletBalance).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.BhstatusNavigation)
                    .WithMany(p => p.Refund)
                    .HasForeignKey(d => d.Bhstatus)
                    .HasConstraintName("FK_BHStatus");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.ToTable("transactions");

                entity.HasIndex(e => e.TransactionType)
                    .HasName("FK_transactions_TransactionType_idx");

                entity.HasIndex(e => e.WalletId)
                    .HasName("FK_transactions_WalletId_idx");

                entity.Property(e => e.Amount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Particulars)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.WalletBalance).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.TransactionTypeNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transactions_TransactionType");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transactions_WalletId");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("wallet");

                entity.HasIndex(e => e.Status)
                    .HasName("FK_Status_idx");

                entity.HasIndex(e => e.VendorId)
                    .HasName("VendorId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Balance).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Wallet)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status");
            });

            modelBuilder.Entity<Walletadjustment>(entity =>
            {
                entity.ToTable("walletadjustment");

                entity.HasIndex(e => e.AdjustmentType)
                    .HasName("FK_AdjustmentType_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdjustmentTypeNavigation)
                    .WithMany(p => p.Walletadjustment)
                    .HasForeignKey(d => d.AdjustmentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdjustmentType");
            });

            modelBuilder.Entity<Walletdeduction>(entity =>
            {
                entity.ToTable("walletdeduction");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_walletdeduction_CategoryId_idx");

                entity.HasIndex(e => e.WalletStatus)
                    .HasName("FK_walletdeduction_WalletStatus_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.DeductedAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WalletBalance).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.WalletdeductionCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_walletdeduction_CategoryId");

                entity.HasOne(d => d.WalletStatusNavigation)
                    .WithMany(p => p.WalletdeductionWalletStatusNavigation)
                    .HasForeignKey(d => d.WalletStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_walletdeduction_WalletStatus");
            });

            modelBuilder.Entity<Walletrule>(entity =>
            {
                entity.ToTable("walletrule");

                entity.HasIndex(e => e.Mode)
                    .HasName("FK_Mode_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Cplamount)
                    .HasColumnName("CPLAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.ServiceCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModeNavigation)
                    .WithMany(p => p.Walletrule)
                    .HasForeignKey(d => d.Mode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mode");
            });

            modelBuilder.Entity<Walletstatus>(entity =>
            {
                entity.ToTable("walletstatus");

                entity.HasIndex(e => e.Status)
                    .HasName("FK_Status_idx");

                entity.HasIndex(e => e.WalletId)
                    .HasName("FK_WalletId_idx");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Walletstatus)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletStatus");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Walletstatus)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
