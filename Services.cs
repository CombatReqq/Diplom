//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Services()
        {
            this.alt_serv = new HashSet<alt_serv>();
            this.alt_tov = new HashSet<alt_tov>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
        public string description { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> discount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alt_serv> alt_serv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alt_tov> alt_tov { get; set; }
    }
}
