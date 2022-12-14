using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyEFSolution.Module.MyModels
{
    [Table("Contact")]
    [Index("Gcrecord", Name = "iGCRecord_Contact")]
    public partial class Contact
    {
        public Contact()
        {
            MyTasks = new HashSet<MyTask>();
        }

        [Key]
        public virtual Guid Oid { get; set; }
        [StringLength(100)]
        public virtual string FirstName { get; set; }
        [StringLength(100)]
        public virtual string LastName { get; set; }
        public virtual int? Age { get; set; }
        public virtual int? OptimisticLockField { get; set; }
        [Column("GCRecord")]
        public virtual int? Gcrecord { get; set; }

        [InverseProperty("AssignedToNavigation")]
        public virtual ICollection<MyTask> MyTasks { get; set; }
    }
}
