//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseOnHotel2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Hotel
    {
        [Key]
        [Display(Name = "ID")]
        public int HotelID { get; set; }
        [Display(Name = "Nome")]
        public string HotelName { get; set; }
        [Display(Name = "Avalia??o")]
        public int HotelEvaluation { get; set; }
        [Display(Name = "Descri??o")]
        public string HotelDescription { get; set; }
        [Display(Name = "Endere?o")]
        public string HotelAddress { get; set; }
        [Display(Name = "Complemento")]
        public string HotelComplement { get; set; }
        [Display(Name = "CEP")]
        public int HotelCEP { get; set; }
        [Display(Name = "Cidade")]
        public string HotelCity { get; set; }
        [Display(Name = "UF")]
        public string HotelState { get; set; }
        [Display(Name = "Comodidades")]
        public string HotelAmenities { get; set; }
    }
}
