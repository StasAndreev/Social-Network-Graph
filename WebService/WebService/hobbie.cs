//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class hobbie
    {
        public hobbie()
        {
            this.user = new HashSet<user>();
        }
    
        public System.Guid ID_Hobbie { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<user> user { get; set; }
    }
}
