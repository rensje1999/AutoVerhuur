//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoVerhuurJansen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Voertuigen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voertuigen()
        {
            this.Verhurens = new HashSet<Verhuren>();
        }
    
        public string kenteken { get; set; }
        public int categorieId { get; set; }
        public string merk { get; set; }
        public string type { get; set; }
    
        public virtual categorie categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verhuren> Verhurens { get; set; }
    }
}
