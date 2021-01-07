using Happy.Weddings.Vendor.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Happy.Weddings.Vendor.Core.Entity.Commentreply;
using static Happy.Weddings.Vendor.Core.Entity.Review;
using static Happy.Weddings.Vendor.Core.Entity.Subscriptionbenefit;

namespace Happy.Weddings.Vendor.Data.DatabaseContext
{
    public partial class VendorContext : DbContext
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        public VendorContext(DbContextOptions<VendorContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// Get Connection String
        /// </summary>
        public string ConnectionString => configuration.GetConnectionString("Database");
        public virtual DbSet<Assets> Asset { get; set; }
        public virtual DbSet<Benefits> Benefits { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Branchserviceoffered> Branchserviceoffered { get; set; }
        public virtual DbSet<Commentreply> Commentreply { get; set; }
        public virtual DbSet<Categorydetails> Categorydetails { get; set; }
        public virtual DbSet<Events> Event { get; set; }
        public virtual DbSet<Eventphoto> Eventphoto { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Multicode> Multicode { get; set; }
        public virtual DbSet<Multidetail> Multidetail { get; set; }
        public virtual DbSet<Offers> Offer { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Services> Service { get; set; }
        public virtual DbSet<Serviceoffered> Serviceoffered { get; set; }
        public virtual DbSet<Serviceanswer> Serviceanswer { get; set; }
        public virtual DbSet<Servicequestion> Servicequestion { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Subscriptionbenefit> Subscriptionbenefit { get; set; }
        public virtual DbSet<Subscriptionoffer> Subscriptionoffer { get; set; }
        public virtual DbSet<Subscriptionlocation> Subscriptionlocation { get; set; }
        public virtual DbSet<Servicesubscription> Servicesubscription { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
        public virtual DbSet<Topup> Topup { get; set; }
        public virtual DbSet<Topupbenefit> Topupbenefit { get; set; }
        public virtual DbSet<Servicetopup> Servicetopup { get; set; }
        public virtual DbSet<Suggestionlist> Suggestionlist { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }      
        public virtual DbSet<ReplyCount> ReplyCount { get; set; }
       // public virtual DbSet<SubsBenefit> SubsBenefit { get; set; }
        public virtual DbSet<Vendorquestionanswers> Vendorquestionanswers { get; set; }

        public virtual DbSet<Vendorserviceutilisation> Vendorserviceutilisation { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assets>(entity =>
            {
                entity.ToTable("asset");

                entity.HasIndex(e => e.AssetCondition)
                    .HasName("asset-condition_idx");

                entity.HasIndex(e => e.AssetType)
                    .HasName("asset-type_idx");

                entity.HasIndex(e => e.AssociatedVendorService)
                    .HasName("asso-vendor-service_idx");

                entity.HasIndex(e => e.Status)
                    .HasName("asset-status_idx");

                entity.HasIndex(e => e.Unit)
                    .HasName("asset-unit_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.AssetName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.AssetConditionNavigation)
                    .WithMany(p => p.AssetAssetConditionNavigation)
                    .HasForeignKey(d => d.AssetCondition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asset-condition");

                entity.HasOne(d => d.AssetTypeNavigation)
                    .WithMany(p => p.AssetAssetTypeNavigation)
                    .HasForeignKey(d => d.AssetType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asset-type");

                entity.HasOne(d => d.AssociatedVendorServiceNavigation)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.AssociatedVendorService)
                    .HasConstraintName("asso-vendor-service");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.AssetStatusNavigation)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asset-status");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.AssetUnitNavigation)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asset-unit");
            });

            modelBuilder.Entity<Benefits>(entity =>
            {
                entity.ToTable("benefit");

                entity.HasIndex(e => e.BenefitUnit)
                    .HasName("benefitunit_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Benefit)
                    .IsRequired()
                    .HasColumnName("Benefit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.BenefitUnitNavigation)
                    .WithMany(p => p.Benefit)
                    .HasForeignKey(d => d.BenefitUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("benefitunit");
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.ToTable("branches");

                entity.HasIndex(e => e.DistrictId)
                    .HasName("FK_DistrictName_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EstablishedYear).HasColumnType("year");

                entity.Property(e => e.FlatPlotDoorNo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Floor)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Landmark)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ListingAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LocalityName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DistrictName");
            });

            modelBuilder.Entity<Branchserviceoffered>(entity =>
            {
                entity.ToTable("branchserviceoffered");

                entity.HasIndex(e => e.BranchId)
                    .HasName("FK_BranchId_idx");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("FK_Service_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryMobileNumber)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Branchserviceoffered)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Branch");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Branchserviceoffered)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service");
            });

            modelBuilder.Entity<Categorydetails>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                      .HasName("PRIMARY");

                entity.ToTable("categorydetails");

                entity.HasIndex(e => e.ServiceType)
                    .HasName("FK_ServiceType_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CategoryModeName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InstagramLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PinterestLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TwitterHandle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.VendorStatusName)
                   .IsRequired()
                   .HasMaxLength(45)
                   .IsUnicode(false);

                entity.Property(e => e.VideoLink)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.WebsiteLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ServiceTypeNavigation)
                    .WithMany(p => p.Categorydetails)
                    .HasForeignKey(d => d.ServiceType)
                    .HasConstraintName("FK_ServiceType");
            });

            modelBuilder.Entity<Commentreply>(entity =>
            {
                entity.ToTable("commentreply");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("FK_commentreply_ApprovalStatus_idx");

                entity.HasIndex(e => e.ReviewId)
                    .HasName("FK_commentreply_ReviewId_idx");

                entity.HasIndex(e => e.Type)
                    .HasName("FK_commentreply_Type_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CommentReply)
                    .IsRequired()
                    .HasColumnName("CommentReply")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.CommentreplyApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_commentreply_ApprovalStatus");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Commentreply)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_commentreply_ReviewId");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.CommentreplyTypeNavigation)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_commentreply_Type");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("FK_event_ApprovalStatus_idx");

                entity.HasIndex(e => e.EventType)
                    .HasName("event-type_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CoverPhoto)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedPrice).HasColumnType("decimal(8,2)");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tags)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.EventApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_event_ApprovalStatus");

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.EventEventTypeNavigation)
                    .HasForeignKey(d => d.EventType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event-type");
            });

            modelBuilder.Entity<Eventphoto>(entity =>
            {
                entity.ToTable("eventphoto");

                entity.HasIndex(e => e.EventId)
                    .HasName("eventphoto-eventid_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Eventphoto)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventphoto-eventid");
            });

            modelBuilder.Entity<Eventtagdata>(entity =>
            {
                entity.ToTable("eventtagdata");

                entity.HasIndex(e => e.EventId)
                    .HasName("FK_eventtagdata_EventId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.TagName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Eventtagdata)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eventtagdata_EventId");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.ToTable("gallery");

                entity.HasIndex(e => e.EventId)
                    .HasName("event-id_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoPath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Gallery)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event-id");
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

            modelBuilder.Entity<Offers>(entity =>
            {
                entity.ToTable("offer");

                entity.HasIndex(e => e.Conditions)
                    .HasName("off-condition_idx");

                entity.HasIndex(e => e.Type)
                    .HasName("val-unit_idx");

                entity.HasIndex(e => e.ValidityUnit)
                    .HasName("val-unit_idx1");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.OfferName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.ConditionsNavigation)
                    .WithMany(p => p.OfferConditionsNavigation)
                    .HasForeignKey(d => d.Conditions)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("off-conditions");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.OfferTypeNavigation)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("off-type");

                entity.HasOne(d => d.ValidityUnitNavigation)
                    .WithMany(p => p.OfferValidityUnitNavigation)
                    .HasForeignKey(d => d.ValidityUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("val-unit");
            });

            modelBuilder.Entity<Profilepictures>(entity =>
            {
                entity.HasKey(e => e.ProflePictureId)
                  .HasName("PRIMARY");

                entity.ToTable("profilepictures");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_profilepictures_categoryid_idx");

                entity.Property(e => e.ProfilePicturePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Profilepictures)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_profilepictures_categoryid");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("Review-ApprovalStatus_idx");

                entity.HasIndex(e => e.ReviewType)
                    .HasName("Review-Reviewtype_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailOf)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.ReviewApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review-ApprovalStatus");

                entity.HasOne(d => d.ReviewTypeNavigation)
                    .WithMany(p => p.ReviewReviewTypeNavigation)
                    .HasForeignKey(d => d.ReviewType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review-Reviewtype");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("service");

                entity.HasIndex(e => e.Currency)
                    .HasName("service-currency_idx");

                entity.HasIndex(e => e.ExperienceUnit)
                    .HasName("service-experience-unit_idx");

                entity.HasIndex(e => e.LocationId)
                 .HasName("service-type-location_idx");

                entity.HasIndex(e => e.RateType)
                    .HasName("service-ratetype_idx");

                entity.HasIndex(e => e.ServiceType)
                    .HasName("service-type_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Award)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Experience).HasColumnType("decimal(4,2)");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PriceRangeEnd).HasColumnType("decimal(8,2)");

                entity.Property(e => e.PriceRangeStart).HasColumnType("decimal(8,2)");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VendorStatusName)
                  .IsRequired()
                  .HasMaxLength(45)
                  .IsUnicode(false);

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.ServiceCurrencyNavigation)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("service-currency");

                entity.HasOne(d => d.ExperienceUnitNavigation)
                    .WithMany(p => p.ServiceExperienceUnitNavigation)
                    .HasForeignKey(d => d.ExperienceUnit)
                    .HasConstraintName("service-experience-unit");

                entity.HasOne(d => d.Location)
                   .WithMany(p => p.ServiceLocation)
                   .HasForeignKey(d => d.LocationId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("service-type-location");

                entity.HasOne(d => d.RateTypeNavigation)
                    .WithMany(p => p.ServiceRateTypeNavigation)
                    .HasForeignKey(d => d.RateType)
                    .HasConstraintName("service-ratetype");

                entity.HasOne(d => d.ServiceTypeNavigation)
                    .WithMany(p => p.ServiceServiceTypeNavigation)
                    .HasForeignKey(d => d.ServiceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service-type");
            });

            modelBuilder.Entity<Serviceanswer>(entity =>
            {
                entity.ToTable("serviceanswer");

                entity.HasIndex(e => e.ControlType)
                    .HasName("controltype_idx");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("questionid_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.ControlTypeNavigation)
                    .WithMany(p => p.Serviceanswer)
                    .HasForeignKey(d => d.ControlType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("controltype");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Serviceanswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("questionid");
            });

            modelBuilder.Entity<Serviceoffered>(entity =>
            {
                entity.ToTable("serviceoffered");

                entity.HasIndex(e => e.OfferedServiceId)
                    .HasName("FK_OfferedServiceId_idx");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("FK_ServiceId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.OfferedService)
                    .WithMany(p => p.Serviceoffered)
                    .HasForeignKey(d => d.OfferedServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferedServiceId");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Serviceoffered)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceId");
            });

            modelBuilder.Entity<Servicequestion>(entity =>
            {
                entity.ToTable("servicequestion");

                entity.HasIndex(e => e.ServiceType)
                    .HasName("servicetype_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsForVendor).HasColumnType("bit(1)");

                entity.Property(e => e.Question)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.ServiceTypeNavigation)
                    .WithMany(p => p.Servicequestion)
                    .HasForeignKey(d => d.ServiceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("servicetype");
            });

            modelBuilder.Entity<Servicesubscription>(entity =>
            {
                entity.ToTable("servicesubscription");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("servicesub-ApprovalStatus_idx");

                entity.HasIndex(e => e.PaymentStatus)
                    .HasName("vendorsub-paystatus_idx");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("service-ServiceId_idx");

                entity.HasIndex(e => e.Subscription)
                    .HasName("vendor-subid_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.WalletBalance).HasColumnType("decimal(8,2)");

                entity.Property(e => e.WalletStatusName)
                   .IsRequired()
                   .HasMaxLength(45)
                   .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.ServicesubscriptionApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("servicesub-ApprovalStatus");

                entity.HasOne(d => d.PaymentStatusNavigation)
                    .WithMany(p => p.ServicesubscriptionPaymentStatusNavigation)
                    .HasForeignKey(d => d.PaymentStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("servicesub-paystatus");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Servicesubscription)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service-ServiceId");

                entity.HasOne(d => d.SubscriptionNavigation)
                    .WithMany(p => p.Servicesubscription)
                    .HasForeignKey(d => d.Subscription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service-subid");
            });

            modelBuilder.Entity<Servicetopup>(entity =>
            {
                entity.ToTable("servicetopup");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("FK_servicetopup_ApprovalStatus_idx");

                entity.HasIndex(e => e.PaymentStatus)
                    .HasName("FK_servicetopup_PaymentStatus_idx");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("FK_servicetopup_ServiceId_idx");

                entity.HasIndex(e => e.TopUpId)
                    .HasName("FK_servicetopup_TopUpId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.WalletBalance).HasColumnType("decimal(8,2)");

                entity.Property(e => e.WalletStatusName)
                   .IsRequired()
                   .HasMaxLength(45)
                   .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.ServicetopupApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servicetopup_ApprovalStatus");

                entity.HasOne(d => d.PaymentStatusNavigation)
                    .WithMany(p => p.ServicetopupPaymentStatusNavigation)
                    .HasForeignKey(d => d.PaymentStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servicetopup_PaymentStatus");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Servicetopup)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servicetopup_ServiceId");

                entity.HasOne(d => d.TopUp)
                    .WithMany(p => p.Servicetopup)
                    .HasForeignKey(d => d.TopUpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servicetopup_TopUpId");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategory");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_category_idx");

                entity.HasIndex(e => e.SubCategoryType)
                    .HasName("FK_subcategory_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.SubCategoryValue)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryTypeNavigation)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_category");

                entity.HasOne(d => d.SubCategoryTypeNavigation)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.SubCategoryType)
                    .HasConstraintName("FK_subcategory");
            });


            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("FK_ApprovalStatus_idx");

                entity.HasIndex(e => e.Mode)
                    .HasName("FK_Mode_idx");

                entity.HasIndex(e => e.ParentsubscriptionId)
                    .HasName("FK_ParentsubscriptionId_idx");

                entity.HasIndex(e => e.ValidityUnit)
                    .HasName("validityunit_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CgstRatePercentage).HasColumnName("CGST_RatePercentage");

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Cplamount)
                    .HasColumnName("CPLAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GstRatePercentage).HasColumnName("GST_RatePercentage");

                entity.Property(e => e.Gstamount)
                    .HasColumnName("GSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.IgstRatePercentage).HasColumnName("IGST_RatePercentage");

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationFee).HasColumnType("decimal(8,2)");

                entity.Property(e => e.ServiceFee).HasColumnType("decimal(8,2)");

                entity.Property(e => e.SgstRatePercentage).HasColumnName("SGST_RatePercentage");

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.SubscriptionApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApprovalStatus");

                entity.HasOne(d => d.ModeNavigation)
                    .WithMany(p => p.SubscriptionModeNavigation)
                    .HasForeignKey(d => d.Mode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mode");

                entity.HasOne(d => d.Parentsubscription)
                    .WithMany(p => p.InverseParentsubscription)
                    .HasForeignKey(d => d.ParentsubscriptionId)
                    .HasConstraintName("FK_ParentsubscriptionId");

                entity.HasOne(d => d.ValidityUnitNavigation)
                    .WithMany(p => p.SubscriptionValidityUnitNavigation)
                    .HasForeignKey(d => d.ValidityUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_validityunit");
            });

            modelBuilder.Entity<Subscriptionbenefit>(entity =>
            {
                entity.ToTable("subscriptionbenefit");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("bene-ApprovalStatus_idx");

                entity.HasIndex(e => e.Benefit)
                    .HasName("bene-benefit_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("bene-subid_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.SubscriptionbenefitApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bene-ApprovalStatus");

                entity.HasOne(d => d.BenefitNavigation)
                    .WithMany(p => p.SubscriptionbenefitBenefitNavigation)
                    .HasForeignKey(d => d.Benefit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bene-benefit");

                entity.HasOne(d => d.Subscriptions)
                    .WithMany(p => p.Subscriptionbenefit)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bene-subid");
            });

            modelBuilder.Entity<Subscriptionlocation>(entity =>
            {
                entity.ToTable("subscriptionlocation");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_CategoryId_idx");

                entity.HasIndex(e => e.LocationId)
                    .HasName("FK_LocationId_idx");

                entity.HasIndex(e => e.Mode)
                    .HasName("FK_subscriptionlocation_Mode_idx");

                entity.HasIndex(e => e.PackageType)
                    .HasName("FK_PackageType_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("FK_subscriptionId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CgstRatePercentage).HasColumnName("CGST_RatePercentage");

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Cplamount)
                    .HasColumnName("CPLAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.GstRatePercentage).HasColumnName("GST_RatePercentage");

                entity.Property(e => e.Gstamount)
                    .HasColumnName("GSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.IgstRatePercentage).HasColumnName("IGST_RatePercentage");

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.RegistrationFee).HasColumnType("decimal(8,2)");

                entity.Property(e => e.ServiceFee).HasColumnType("decimal(8,2)");

                entity.Property(e => e.SgstRatePercentage).HasColumnName("SGST_RatePercentage");

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubscriptionlocationCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscriptionlocation_CategoryId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SubscriptionlocationLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscriptionlocation_LocationId");

                entity.HasOne(d => d.ModeNavigation)
                    .WithMany(p => p.SubscriptionlocationModeNavigation)
                    .HasForeignKey(d => d.Mode)
                    .HasConstraintName("FK_subscriptionlocation_Mode");

                entity.HasOne(d => d.PackageTypeNavigation)
                    .WithMany(p => p.SubscriptionlocationPackageTypeNavigation)
                    .HasForeignKey(d => d.PackageType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscriptionlocation_PackageType");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Subscriptionlocation)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscriptionlocation_SubscriptionId");
            });

            modelBuilder.Entity<Subscriptionoffer>(entity =>
            {
                entity.ToTable("subscriptionoffer");

                entity.HasIndex(e => e.OfferId)
                    .HasName("suboff-offid_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("subid-off_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Subscriptionoffer)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suboff-offid");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Subscriptionoffer)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subid-off");
            });

            modelBuilder.Entity<Suggestionlist>(entity =>
            {
                entity.ToTable("suggestionlist");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("FK_ApprovalStatus_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("FK_subscriptionId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SubscriptionId).HasColumnName("subscriptionId");

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.Suggestionlist)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_suggestionlist_ApprovalStatus");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Suggestionlist)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_suggestionlist_subscriptionId");
            });

            modelBuilder.Entity<Topup>(entity =>
            {
                entity.ToTable("topup");

                entity.HasIndex(e => e.Mode)
                    .HasName("FK_topup_Mode_idx");

                entity.HasIndex(e => e.TopUpType)
                    .HasName("FK_topup_TopUpType_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.CgstRatePercentage).HasColumnName("CGST_RatePercentage");

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.Cplamount)
                    .HasColumnName("CPLAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GstRatePercentage).HasColumnName("GST_RatePercentage");

                entity.Property(e => e.Gstamount)
                    .HasColumnName("GSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.IgstRatePercentage).HasColumnName("IGST_RatePercentage");

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");

                entity.Property(e => e.SgstRatePercentage).HasColumnName("SGST_RatePercentage");

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.ModeNavigation)
                    .WithMany(p => p.TopupModeNavigation)
                    .HasForeignKey(d => d.Mode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_topup_Mode");

                entity.HasOne(d => d.TopUpTypeNavigation)
                    .WithMany(p => p.TopupTopUpTypeNavigation)
                    .HasForeignKey(d => d.TopUpType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_topup_TopUpType");
            });

            modelBuilder.Entity<Topupbenefit>(entity =>
            {
                entity.ToTable("topupbenefit");

                entity.HasIndex(e => e.ApprovalStatus)
                    .HasName("FK_topupbenefit_ApprovalStatus_idx");

                entity.HasIndex(e => e.Benefit)
                    .HasName("FK_topupbenefit_Benefit_idx");

                entity.HasIndex(e => e.TopUpId)
                    .HasName("FK_topupbenefit_TopUpId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.ApprovalStatusNavigation)
                    .WithMany(p => p.TopupbenefitApprovalStatusNavigation)
                    .HasForeignKey(d => d.ApprovalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_topupbenefit_ApprovalStatus");

                entity.HasOne(d => d.BenefitNavigation)
                    .WithMany(p => p.TopupbenefitBenefitNavigation)
                    .HasForeignKey(d => d.Benefit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_topupbenefit_Benefit");

                entity.HasOne(d => d.TopUp)
                    .WithMany(p => p.Topupbenefit)
                    .HasForeignKey(d => d.TopUpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_topupbenefit_TopUpId");
            });

            modelBuilder.Entity<Vendorquestionanswers>(entity =>
            {
                entity.ToTable("vendorquestionanswers");

                entity.HasIndex(e => e.AnswerId)
                    .HasName("FK_AnsId_idx");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("FK_QusId_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsForVendor).HasColumnType("bit(1)");

                entity.Property(e => e.Vendoranswervalue)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Vendorquestionanswers)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnsId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Vendorquestionanswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QusId");
            });

            modelBuilder.Entity<Vendorserviceutilisation>(entity =>
            {
                entity.ToTable("vendorserviceutilisation");

                entity.HasIndex(e => e.Benefit)
                    .HasName("FK_Utilisation_Benefit_idx");

                entity.HasIndex(e => e.ServiceSubscriptionId)
                    .HasName("FK_Utilisation_Service_idx");

                entity.HasIndex(e => e.ServiceTopupId)
                    .HasName("FK_Utilisation_ServiceTopup_idx");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BenefitNavigation)
                    .WithMany(p => p.Vendorserviceutilisation)
                    .HasForeignKey(d => d.Benefit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Utilisation_Benefit");

                entity.HasOne(d => d.ServiceSubscription)
                    .WithMany(p => p.Vendorserviceutilisation)
                    .HasForeignKey(d => d.ServiceSubscriptionId)
                    .HasConstraintName("FK_Utilisation_ServiceSubscription");

                entity.HasOne(d => d.ServiceTopup)
                    .WithMany(p => p.Vendorserviceutilisation)
                    .HasForeignKey(d => d.ServiceTopupId)
                    .HasConstraintName("FK_Utilisation_ServiceTopup");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
