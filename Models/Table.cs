//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Pokusaj3.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Table
    {
        [Required(ErrorMessage = "Sva polja moraju biti popunjena")]
        public int Sifra { get; set; }
        [Required(ErrorMessage = "Sva polja moraju biti popunjena")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Sva polja moraju biti popunjena"), EmailAddress(ErrorMessage = "Email adresa nije validna")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Sva polja moraju biti popunjena"), Phone(ErrorMessage = "Uneli ste slova umesto brojeva")]
        public string Kontakt { get; set; }
        [Required(ErrorMessage = "Sva polja moraju biti popunjena")]
        public string Komentar { get; set; }
        

    }
}
