using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mugs.Models
{

    public enum MugStatus
    {
        InUse = 1,
        Available
    }

    [Table("Mug")]
    public class Mug
    {
        public int MugId { get; set; }
        public MugStatus MugStatus { get; set; }
    }
}