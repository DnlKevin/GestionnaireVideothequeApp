//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TARIF
    {
        [Key]
        public int TARIFID { get; set; }
        public string NOMTARIF { get; set; }
        public string SUPPORT { get; set; }
        public double TARIFJOURNALIER { get; set; }
    }
}
