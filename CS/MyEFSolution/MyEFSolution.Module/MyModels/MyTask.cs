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
    [DevExpress.Persistent.Base.DefaultClassOptions]
    public partial class MyTask
    {
        [Key]
        public virtual Guid Oid { get; set; }
        [StringLength(100)]
        public virtual string Subject { get; set; }
        public virtual Guid? AssignedTo { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual int? Priority { get; set; }
        public virtual int? OptimisticLockField { get; set; }
        [Column("GCRecord")]
        public virtual int? Gcrecord { get; set; }

        [ForeignKey("AssignedTo")]
        [InverseProperty("MyTasks")]
        public virtual Contact AssignedToNavigation { get; set; }
    }
}
