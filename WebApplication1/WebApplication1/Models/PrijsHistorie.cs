//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrijsHistorie
    {
        public int prijsCaterieId { get; set; }
        public int caterieId { get; set; }
        public System.DateTime beginDatum { get; set; }
        public Nullable<System.DateTime> eindDatum { get; set; }
        public decimal prijsPerDag { get; set; }
    
        public virtual Caterie Caterie { get; set; }
    }
}
