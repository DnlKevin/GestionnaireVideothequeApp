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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class LOCATION
    {
        [Key]
        public int LOCATIONID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DATEDEBUT { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DATEFIN { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DATERETOUREFF { get; set; }
        public int MONTANT { get; set; }

        //Relationships
        public List<EXEMPLAIRE> Exemplaires { get; set; }
        public List<FACTURE> Factures { get; set; }
        public List<CLIENT> Clients { get; set; }

        [ForeignKey("EXEMPLAIREID")]
        public int EXEMPLAIREID { get; set; }
        public EXEMPLAIRE Exemplaire { get; set; }
        
        [ForeignKey("FACTUREID")]
        public int FACTUREID { get; set; }
        public FACTURE Facture { get; set; }

        [ForeignKey("CLIENTID")]
        public int CLIENTID { get; set; }
        public CLIENT Client { get; set; }

    }
}
