﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionnaireVideothequeApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GestionnaireVideothequeDBEntities : DbContext
    {
        public GestionnaireVideothequeDBEntities()
            : base("name=GestionnaireVideothequeDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLIENT> CLIENT { get; set; }
        public virtual DbSet<EXEMPLAIRE> EXEMPLAIRE { get; set; }
        public virtual DbSet<FACTURE> FACTURE { get; set; }
        public virtual DbSet<FILM> FILM { get; set; }
        public virtual DbSet<LOCATION> LOCATION { get; set; }
        public virtual DbSet<TARIF> TARIF { get; set; }
    }
}