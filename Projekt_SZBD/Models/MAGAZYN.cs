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
    
    public partial class MAGAZYN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MAGAZYN()
        {
            this.EGZEMPLARZ = new HashSet<EGZEMPLARZ>();
            this.POZYCJA_ZAMOWIENIA = new HashSet<POZYCJA_ZAMOWIENIA>();
        }
    
        public int ID_Magazynu { get; set; }
        public string Opis { get; set; }
        public Nullable<int> ID_Adresu { get; set; }
    
        public virtual ADRES ADRES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EGZEMPLARZ> EGZEMPLARZ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POZYCJA_ZAMOWIENIA> POZYCJA_ZAMOWIENIA { get; set; }
    }
}