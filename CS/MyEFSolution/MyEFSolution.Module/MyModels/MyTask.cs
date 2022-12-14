using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyEFSolution.Module.MyModels
{
    [Table("MyTask")]
    [Index("AssignedTo", Name = "iAssignedTo_MyTask")]
    [Index("Gcrecord", Name = "iGCRecord_MyTask")]
    public partial class MyTask
    {
        [Key]
        public Guid Oid { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        public Guid? AssignedTo { get; set; }
        public bool? IsActive { get; set; }
        public int? Priority { get; set; }
        public int? OptimisticLockField { get; set; }
        [Column("GCRecord")]
        public int? Gcrecord { get; set; }

        [ForeignKey("AssignedTo")]
        [InverseProperty("MyTasks")]
        public virtual Contact AssignedToNavigation { get; set; }
    }
}
