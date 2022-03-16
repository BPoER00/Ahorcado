using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ahorcado.Models;
using Microsoft.EntityFrameworkCore;

namespace Ahorcado.Controllers
{
    public class HomeController : Controller
    {
        public Conexion DbConexion;

        public HomeController (Conexion DbConexion)
        {
            this.DbConexion = DbConexion;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jugar(Dificultades dificultad)
        {
            try{
                var confi = this.DbConexion.Palabras.Where(x => x.IdDificultad == dificultad.IdDificultad).ToList();
                var largo = confi.Count();
                Random r = new Random();
                var total = r.Next(1, largo);
                ViewBag.Palabra = confi[total].Palabra;
                return View();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("ErrorSala");
            }
            
        }

        public ViewResult Jugadores()
        {
            return View();
        }

        public IActionResult Dificultad()
        {
            ViewBag.Dificultad = this.DbConexion.Dificultades.ToList();
            return View();
        }

        public ViewResult Sala()
        {
            return View();
        }

        public ViewResult EsperarSala()
        {
            return View();
        }

        public IActionResult Multijugador(TablaSalas sala)
        {
            if(ModelState.IsValid)
            {
                var token = this.Aleatorio();
                sala.Token = token;
                this.DbConexion.TablaSalas.Add(sala);
                this.DbConexion.SaveChanges();
                
                ViewBag.token = token;
                return View();
            }
            else
            {
                return BadRequest();
            }
        }

        public int Aleatorio()
        {
            var seed = Environment.TickCount;
            Random r = new Random();

            var dato = r.Next(0, seed);
            return dato;
        }
        public ViewResult CrearSala()
        {
            return View();
        }
    
        public IActionResult Jugador1(TablaSalas datos)
        {
            try
            {
                var dato = this.DbConexion.TablaSalas.Where(x => x.Token == datos.Token).ToList();
                this.Eliminar(dato[0]);
                this.DificultadPalabra(dato[0]);
                ViewBag.Palabra = dato[0].Palabra;
                return View();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("ErrorSala");
            }

        }

        public ViewResult ErrorSala()
        {
            return View();
        }
    
        public void Eliminar(TablaSalas dato)
        {
            this.DbConexion.TablaSalas.Remove(dato);
            this.DbConexion.SaveChanges();
        }
    
        public void DificultadPalabra(TablaSalas dato)
        {
            Palabras datos = new Palabras();
            datos.Palabra = dato.Palabra;

            var Palabra = dato.Palabra.Length;
            if(Palabra >=1 && Palabra <=5)
            {    
                datos.IdDificultad = 1;
            }else if(Palabra >=6 && Palabra <=11)
            {
                datos.IdDificultad = 2;
            }else if(Palabra >=12)
            {
                datos.IdDificultad = 3;
            }

            this.DbConexion.Palabras.Add(datos);
            this.DbConexion.SaveChanges();
        }
    }
}
