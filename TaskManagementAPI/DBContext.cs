using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserProfile> Waypoint { get; set; }
        public virtual DbSet<WorkTask> WorkTask { get; set; }
        public virtual DbSet<WorkTaskStatus> WorkTaskStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(e => e.UserProfileNavigation)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.UserProfile)
                    .HasConstraintName("FK_User_UserProfile");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Waypoint>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Order)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(e => e.WorkTaskNavigation)
                    .WithMany(e => e.Waypoints)
                    .HasForeignKey(e => e.WorkTask)
                    .HasConstraintName("FK_Waypoint_WorkTask");

                entity.HasOne(e => e.LocationNavigation)
                    .WithMany(e => e.Waypoints)
                    .HasForeignKey(e => e.Location)
                    .HasConstraintName("FK_Waypoint_Location");
            });

            modelBuilder.Entity<WorkTask>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Observation)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DeadLine)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(e => e.UserNavigation)
                    .WithMany(e => e.WorkTasks)
                    .HasForeignKey(e => e.User)
                    .HasConstraintName("FK_WorkTask_User");

                entity.HasOne(e => e.CategoryNavigation)
                    .WithMany(e => e.WorkTasks)
                    .HasForeignKey(e => e.Category)
                    .HasConstraintName("FK_WorkTask_Category");
            });

            modelBuilder.Entity<WorkTaskStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                
                entity.Property(e => e.Observation)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(e => e.WorkTaskNavigation)
                    .WithMany(e => e.WorkTaskStatuses)
                    .HasForeignKey(e => e.WorkTask)
                    .HasConstraintName("FK_WorkTaskStatus_WorkTask");

                entity.HasOne(e => e.StatusNavigation)
                    .WithMany(e => e.WorkTaskStatuses)
                    .HasForeignKey(e => e.Status)
                    .HasConstraintName("FK_WorkTaskStatus_Status");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
