//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt_SZBD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZAMOWIENIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZAMOWIENIA()
        {
            this.POZYCJA_ZAMOWIENIA = new HashSet<POZYCJA_ZAMOWIENIA>();
        }
    
        public int ID_Zamowienia { get; set; }
        public System.DateTime Data_Zlozenia { get; set; }
        public int ID_Klienta { get; set; }
        public int ID_Pracownika { get; set; }
    
        public virtual KLIENT KLIENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POZYCJA_ZAMOWIENIA> POZYCJA_ZAMOWIENIA { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
    }
}