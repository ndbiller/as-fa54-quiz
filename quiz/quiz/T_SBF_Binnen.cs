//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quiz
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_SBF_Binnen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_SBF_Binnen()
        {
            this.T_Fragebogen_unter_Maschine = new HashSet<T_Fragebogen_unter_Maschine>();
        }
    
        public int P_Id { get; set; }
        public string Frage { get; set; }
        public string Antwort1 { get; set; }
        public string Antwort2 { get; set; }
        public string Antwort3 { get; set; }
        public string Antwort4 { get; set; }
        public Nullable<byte> RichtigeAntwort { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Fragebogen_unter_Maschine> T_Fragebogen_unter_Maschine { get; set; }
    }
}
