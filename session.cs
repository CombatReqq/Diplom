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
    
    public partial class session
    {
        public int id_session { get; set; }
        public int id_user { get; set; }
        public System.DateTime start_session { get; set; }
        public System.DateTime end_session { get; set; }
    
        public virtual user user { get; set; }
    }
}
