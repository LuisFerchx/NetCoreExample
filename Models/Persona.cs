using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace NetCoreExample.Models
{
    [Table("persona")]
    public partial class Persona
    {
        public Persona()
        {
            VenTransaccioncabeceras = new HashSet<VenTransaccioncabecera>();
        }

        [Key]
        [Column("per_id")]
        public int PerId { get; set; }
        [BindProperty]
        [Column("per_nombre", TypeName = "character varying")]
        //[Required(ErrorMessage="Campo Obligatorio")]
        public string PerNombre { get; set; }

        //[Required(ErrorMessage="Campo Obligatorio")]
        [Column("per_apellido", TypeName = "character varying")]
        [BindProperty]
        public string PerApellido { get; set; }

        //[Required(ErrorMessage="Campo Obligatorio")]
        [Column("per_direccion", TypeName = "character varying")]
        [BindProperty]
        public string PerDireccion { get; set; }
        
         
        [Column("per_fecnac", TypeName = "date")]
        [BindProperty]
        public DateTime? PerFecnac { get; set; }

       // [Required(ErrorMessage="Campo Obligatorio")]
        [Column("per_email", TypeName = "character varying")]
        [BindProperty]
        public string PerEmail { get; set; }


        [Column("per_estado")]
        [StringLength(1)]
        public string PerEstado { get; set; }

        //[Required(ErrorMessage="Campo Obligatorio")]
        [MinLength(10,ErrorMessage="Cedula Incorrecta")]
        [RegularExpression("^[0-9]{9}-[0-9]{1}$",ErrorMessage="Cedula Incorrecta")]
        [BindProperty]
        [Column("per_identificacion", TypeName = "character varying")]
        
        public string PerIdentificacion { get; set; }

        [InverseProperty(nameof(VenTransaccioncabecera.Per))]
        public virtual ICollection<VenTransaccioncabecera> VenTransaccioncabeceras { get; set; }
    }
}
