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
    
    public partial class EXEMPLAIRE
    {
        public int EXEMPLAIREID { get; set; }
        public string SUPPORT { get; set; }
        public System.DateTime DATEACQUISITION { get; set; }
        public bool DISPONIBILITE { get; set; }
        public string ETATEXEMPLAIRE { get; set; }
    }
}