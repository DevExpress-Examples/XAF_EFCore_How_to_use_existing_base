using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyEFSolution.Module.BusinessObjects;

namespace MyEFSolution.Module.MyModels
{
    [TypesInfoInitializer(typeof(MyEFSolutionContextInitializer))]
    public partial class MyEFSolutionEFCoreDbContextNew : DbContext
    {
        public MyEFSolutionEFCoreDbContextNew()
        {
        }

        public MyEFSolutionEFCoreDbContextNew(DbContextOptions<MyEFSolutionEFCoreDbContextNew> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<MyTask> MyTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Oid).ValueGeneratedNever();
            });

            modelBuilder.Entity<MyTask>(entity =>
            {
                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_MyTask_AssignedTo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
