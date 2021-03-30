using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreExample.Models;
using Microsoft.EntityFrameworkCore;



namespace NetCoreExample.Controllers
{
    public class ven_transaccioncabecera:Controller
    {
        FacturaContext context;
        public ven_transaccioncabecera(FacturaContext _context){
            context = _context;
        }
        public async Task<IActionResult> Index(){
            
            List<VenTransaccioncabecera> VenTransaccioncabeceras = await context.VenTransaccioncabeceras.Include(x=>x.Per).ToListAsync(); 
            VenTransaccioncabecera VenTransaccioncabecera = new VenTransaccioncabecera();
            ViewBag.VenTransaccioncabeceras = VenTransaccioncabeceras;
            return View(VenTransaccioncabecera);
        }

    }
}