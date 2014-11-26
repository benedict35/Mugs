using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mugs.Models
{
    [Table("Worker")]
    public abstract class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerId { get; protected set; }
        public virtual ICollection<Mug> Mugs { get; set; } 
        
    }

    public class HardWorker : Worker
    {
        
    }

    public class HappyWorker : Worker
    {
        
    }

    public class HopelessWorker : Worker
    {
        
    }
}