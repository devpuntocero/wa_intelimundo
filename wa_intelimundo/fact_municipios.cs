//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wa_intelimundo
{
    using System;
    using System.Collections.Generic;
    
    public partial class fact_municipios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fact_municipios()
        {
            this.inf_contacto = new HashSet<inf_contacto>();
            this.inf_fiscales = new HashSet<inf_fiscales>();
        }
    
        public int id_municipio { get; set; }
        public string desc_municipio { get; set; }
        public Nullable<int> id_estado { get; set; }
    
        public virtual fact_estados fact_estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_contacto> inf_contacto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_fiscales> inf_fiscales { get; set; }
    }
}
