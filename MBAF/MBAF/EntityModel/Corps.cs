//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBAF.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Corps
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corps()
        {
            this.AudienceType = new HashSet<AudienceType>();
        }
    
        public int Id { get; set; }
        public string CorpNumber { get; set; }
        public Nullable<int> NumberOfAudiences { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AudienceType> AudienceType { get; set; }

        public override string ToString()
        {
            return CorpNumber;
        }
    }
}
