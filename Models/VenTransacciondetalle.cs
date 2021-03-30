using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NetCoreExample.Models
{
    [Table("ven_transacciondetalle")]
    public partial class VenTransacciondetalle
    {
        [Key]
        [Column("det_id")]
        public int DetId { get; set; }
        [Column("cab_id")]
        public int CabId { get; set; }
        [Column("ite_id")]
        public int IteId { get; set; }
        [Column("det_cantidad")]
        public decimal? DetCantidad { get; set; }
        [Column("det_precio")]
        public decimal? DetPrecio { get; set; }
        [Column("det_total")]
        public decimal? DetTotal { get; set; }
        [Column("det_estado")]
        [StringLength(1)]
        public string DetEstado { get; set; }

        [ForeignKey(nameof(CabId))]
        [InverseProperty(nameof(VenTransaccioncabecera.VenTransacciondetalles))]
        public virtual VenTransaccioncabecera Cab { get; set; }
        [ForeignKey(nameof(IteId))]
        [InverseProperty(nameof(Item.VenTransacciondetalles))]
        public virtual Item Ite { get; set; }
    }
}
