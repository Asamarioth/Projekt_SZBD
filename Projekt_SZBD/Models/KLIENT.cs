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
    
    public partial class KLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KLIENT()
        {
            this.ZAMOWIENIA = new HashSet<ZAMOWIENIA>();
        }
    
        public int ID_Klienta { get; set; }
        public string Nazwa { get; set; }
        public bool Czy_Firma { get; set; }
        public string NIP { get; set; }
        public int ID_Adresu { get; set; }
        public int ID_Kontaktu { get; set; }
    
        public virtual ADRES ADRES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZAMOWIENIA> ZAMOWIENIA { get; set; }
        public virtual KONTAKT KONTAKT { get; set; }
    }
}
