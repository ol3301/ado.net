//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityTran
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUTHORS_BOOKS
    {
        public int Id { get; set; }
        public Nullable<int> IdBook { get; set; }
        public Nullable<int> IdAuthor { get; set; }
    
        public virtual AUTHORS AUTHORS { get; set; }
        public virtual BOOKS BOOKS { get; set; }
    }
}
