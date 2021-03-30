using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreExample.Models;


namespace NetCoreExample.Controllers
{
    public class Personas : Controller
    {
        FacturaContext context;

        public Personas(FacturaContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            Persona Persona = new Persona();
            ViewBag.Personas = context.Personas.ToList();
            return View(Persona); 
        }

        [BindProperty]
        public Persona Persona {get; set;}
        public IActionResult Guardar()
        {
            if (ModelState.IsValid) //las entidades cumplen con las validaciones
            {  
                return Redirect("/Personas/");
            }
            var _Persona = context.Personas.Where(x=>x.PerId == Persona.PerId).SingleOrDefault();
            if (_Persona == null)
            {
                context.Personas.Add(Persona);
            }else
            {
                _Persona.PerNombre = Persona.PerNombre;
                _Persona.PerApellido = Persona.PerApellido;
                _Persona.PerDireccion = Persona.PerDireccion;
                _Persona.PerEmail = Persona.PerEmail;
                _Persona.PerIdentificacion = Persona.PerIdentificacion;
            }
            context.SaveChanges(); //commit
            return RedirectToAction("Index");
            
        }
        public IActionResult Modificar(int id)
        {
            var Persona = context.Personas.Find(id);
            //var Persona = context.Personas.Where(x=>x.PerId == id).Single(); //cuando devuelva 1 registro
            //var Persona = context.Personas.Where(x=>x.PerId == id).SingleOrDefault(); // si no encuentra devuelve null
            if (Persona == null)
            {
                return Redirect("/Personas/");
            }
            return View(Persona); //envio entidad y se enlaza con el modelo 
        }

        public IActionResult Eliminar(int id)
        {
            var Persona = context.Personas.Find(id);
            if (Persona == null)
            {
                return StatusCode(404);
            }
            context.Personas.Remove(Persona);
            context.SaveChanges();
            return Redirect("/Personas/"); 
        }

    }
}