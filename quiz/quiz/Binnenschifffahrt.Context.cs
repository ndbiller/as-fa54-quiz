﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BinnenschifffahrtEntities : DbContext
    {
        public BinnenschifffahrtEntities()
            : base("name=BinnenschifffahrtEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_SBF_Binnen> T_SBF_Binnen { get; set; }
        public virtual DbSet<T_Fragebogen_unter_Maschine> T_Fragebogen_unter_Maschine { get; set; }
    }
}
