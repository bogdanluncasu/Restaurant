//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public int Id { get; set; }
        public int Masa { get; set; }
        
        public int Comanda { get; set; }
        public int Chelner { get; set; }
        [Display(Name = "Chelner")]
        public virtual Chelner Chelner1 { get; set; }
        [Display(Name = "Meniu Client")]
        
        public virtual MeniuClient MeniuClient { get; set; }
    }
}
