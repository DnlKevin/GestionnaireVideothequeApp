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
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class FILM
    {

        public int FILMID { get; set; }
        [Required]

        public string NOMFILM { get; set; }
        [Required]

        public string CATEGORIE { get; set; }
        [Required]
        public string REALISATEUR { get; set; }
        [Required]

       // [RegularExpression("^[1-9]{4}-(0?[1-9]|1[012])-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Le format date est : yyyy-mm-dd")]
        public DateTime DATESORTIE { get; set; }
        //[Required]
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}