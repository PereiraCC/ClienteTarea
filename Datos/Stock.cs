//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public int idStock { get; set; }
        public int Stock1 { get; set; }
        public int idAlmacen { get; set; }
        public int idProducto { get; set; }
    
        public virtual Almacenes Almacenes { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
