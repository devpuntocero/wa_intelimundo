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
    
    public partial class inf_usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inf_usuarios()
        {
            this.inf_bancarios = new HashSet<inf_bancarios>();
            this.inf_centros_dep = new HashSet<inf_centros_dep>();
            this.inf_contacto = new HashSet<inf_contacto>();
            this.inf_escolares = new HashSet<inf_escolares>();
        }
    
        public System.Guid id_usuario { get; set; }
        public string codigo_usuario { get; set; }
        public string nombres { get; set; }
        public string a_paterno { get; set; }
        public string a_materno { get; set; }
        public string clave { get; set; }
        public Nullable<int> id_genero { get; set; }
        public Nullable<int> id_estatus { get; set; }
        public Nullable<int> id_tipo_usuario { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
    
        public virtual fact_estatus fact_estatus { get; set; }
        public virtual fact_generos fact_generos { get; set; }
        public virtual fact_tipo_usuarios fact_tipo_usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_bancarios> inf_bancarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_centros_dep> inf_centros_dep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_contacto> inf_contacto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inf_escolares> inf_escolares { get; set; }
    }
}
