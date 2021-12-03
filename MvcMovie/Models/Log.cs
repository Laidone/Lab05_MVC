using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Log
    {   [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Dataatualizacao { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Operacao { get; set; }
    }
}