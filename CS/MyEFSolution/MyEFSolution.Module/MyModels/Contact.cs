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
        public Guid Oid { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? OptimisticLockField { get; set; }
        [Column("GCRecord")]
        public int? Gcrecord { get; set; }

        [InverseProperty("AssignedToNavigation")]
        public virtual ICollection<MyTask> MyTasks { get; set; }
    }
}
