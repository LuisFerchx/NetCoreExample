using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NetCoreExample.Models
{
    [Table("item")]
    public partial class Item
    {
        public Item()
        {
            VenTransacciondetalles = new HashSet<VenTransacciondetalle>();
        }

        [Key]
        [Column("ite_id")]
        public int IteId { get; set; }

        [Column("ite_nombre", TypeName = "character varying")]
        public string IteNombre { get; set; }

        [Column("ite_precio")]
        public decimal? ItePrecio { get; set; }

        [Column("ite_stock")]
        public decimal? IteStock { get; set; }
        
        [Required]
        [Column("ite_estado")]
        [StringLength(1)]
        public string IteEstado { get; set; }

        [InverseProperty(nameof(VenTransacciondetalle.Ite))]
        public virtual ICollection<VenTransacciondetalle> VenTransacciondetalles { get; set; }
    }
}
