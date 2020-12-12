using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AutoLotDAL.Models;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using AutoLotDAL.Interception;

namespace AutoLotDAL.EF
{
    

    public partial class AutoLotEntities : DbContext
    { 
        public virtual DbSet<CreditRisks> CreditRisks { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Test> Cars { get; set; }

        static readonly DatabaseLogger databaseLogger = new DatabaseLogger("sqllog.txt", true);

        public AutoLotEntities()
          : base("name=AutoLotConnection")
        {
            // DbInterception.Add(new ConsoleWriterlnterceptor());
            //databaseLogger.StartLogging();
            //DbInterception.Add(databaseLogger);
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);
        }

        protected override void Dispose (bool disposing)
        {
            DbInterception.Remove(databaseLogger);
            databaseLogger.StopLogging();
            base.Dispose(disposing);
        }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {

        }

        private void OnObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {

        }
    }
}
