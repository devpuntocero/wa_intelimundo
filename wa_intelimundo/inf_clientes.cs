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
    
    public partial class inf_clientes
    {
        public System.Guid id_cliente { get; set; }
        public string codigo_cliente { get; set; }
        public Nullable<int> id_estatus { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
    
        public virtual fact_estatus fact_estatus { get; set; }
    }
}
