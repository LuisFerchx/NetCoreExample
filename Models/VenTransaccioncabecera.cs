using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NetCoreExample.Models
{
    [Table("ven_transaccioncabecera")]
    public partial class VenTransaccioncabecera
    {
        public VenTransaccioncabecera()
        {
            VenTransacciondetalles = new HashSet<VenTransacciondetalle>();
        }

        [Key]
        [Column("cab_id")]
        public int CabId { get; set; }
        [Column("cab_secuencia")]
        public decimal CabSecuencia { get; set; }
        [Column("cab_fecha", TypeName = "date")]
        public DateTime? CabFecha { get; set; }
        [Required]
        [Column("cab_estado")]
        [StringLength(2)]
        public string CabEstado { get; set; }
        [Column("per_id")]
        public int PerId { get; set; }

        [ForeignKey(nameof(PerId))]
        [InverseProperty(nameof(Persona.VenTransaccioncabeceras))]
        public virtual Persona Per { get; set; }
        [InverseProperty(nameof(VenTransacciondetalle.Cab))]
        public virtual ICollection<VenTransacciondetalle> VenTransacciondetalles { get; set; }
    }
}
