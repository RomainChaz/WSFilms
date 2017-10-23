using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WSFilms.Models.Metadata
{
    public class T_E_COMPTE_CPTMetadata
    {
        [Key]
        [Display(Name = "Prenom")]
        [StringLength(50, MinimumLength = 1, ErrorMessage =
            "La longueur du prénom doit être comprise entre 1 et 50 caractères")]

        public string CPT_PRENOM { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage =
            "Le téléphone portable doit contenir 10 chiffres")]

        public string CPT_TELPORTABLE { get; set; }

        [Key]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*\W).{6,10}$", ErrorMessage =
            "Le mot de passe doit contenir entre 6 et 10 caractères avec au moins 1 lettre majuscule, 1 chiffre et 1 caractère spécial")]

        public string CPT_PWD { get; set; }

        [Key]
        [Display(Name = "Rue")]
        [StringLength(200, MinimumLength = 1, ErrorMessage =
            "La longueur de la rue doit être comprise entre 1 et 200 caractères")]

        public string CPT_RUE { get; set; }

        [Key]
        [Display(Name = "CP")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage =
            "Le code postal doit contenir 5 chiffres")]

        public string CPT_CP { get; set; }

        [Key]
        [Display(Name = "Ville")]
        [StringLength(50, MinimumLength = 1, ErrorMessage =
            "La longueur de la ville doit être comprise entre 1 et 50 caractères")]

        public string CPT_VILLE { get; set; }

        [Key]
        [Display(Name = "Pays")]
        [StringLength(50, MinimumLength = 1, ErrorMessage =
            "La longueur du pays doit être comprise entre 1 et 50 caractères")]

        public string CPT_PAYS { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 6, ErrorMessage =
            "La longueur d'un email doit être comprise entre 6 et 100 caractères")]

        public string CPT_MEL { get; set; }

    }
}