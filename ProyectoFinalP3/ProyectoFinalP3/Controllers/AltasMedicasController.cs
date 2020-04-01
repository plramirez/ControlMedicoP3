using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalP3.Models;

namespace ProyectoFinalP3.Controllers
{
    public class AltasMedicasController : Controller
    {
        private ControlMedicoContext db = new ControlMedicoContext();

        // GET: AltasMedicas
        public ActionResult Index()
        {
            var altasMedicas = db.AltasMedicas.Include(a => a.Ingresos);
            return View(altasMedicas.ToList());
        }

        // GET: AltasMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltasMedicas altasMedicas = db.AltasMedicas.Find(id);
            if (altasMedicas == null)
            {
                return HttpNotFound();
            }
            return View(altasMedicas);
        }

        // GET: AltasMedicas/Create
        public ActionResult Create()
        {
            ViewBag.IdIngresos = new SelectList(db.Ingresos, "IdIngreso", "IdIngreso");
            return View();
        }

        // POST: AltasMedicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAltaMedica,Paciente,IdIngresos,Habitacion,FechaIngreso,FechaSalido,PrecioTotal")] AltasMedicas altasMedicas)
        {
            if (ModelState.IsValid)
            {
                db.AltasMedicas.Add(altasMedicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIngresos = new SelectList(db.Ingresos, "IdIngreso", "FechaIngreso", altasMedicas.IdIngresos);
            return View(altasMedicas);
        }

        // GET: AltasMedicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltasMedicas altasMedicas = db.AltasMedicas.Find(id);
            if (altasMedicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIngresos = new SelectList(db.Ingresos, "IdIngreso", "FechaIngreso", altasMedicas.IdIngresos);
            return View(altasMedicas);
        }

        // POST: AltasMedicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAltaMedica,Paciente,IdIngresos,Habitacion,FechaIngreso,FechaSalido,PrecioTotal")] AltasMedicas altasMedicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altasMedicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIngresos = new SelectList(db.Ingresos, "IdIngreso", "FechaIngreso", altasMedicas.IdIngresos);
            return View(altasMedicas);
        }

        // GET: AltasMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltasMedicas altasMedicas = db.AltasMedicas.Find(id);
            if (altasMedicas == null)
            {
                return HttpNotFound();
            }
            return View(altasMedicas);
        }

        // POST: AltasMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AltasMedicas altasMedicas = db.AltasMedicas.Find(id);
            db.AltasMedicas.Remove(altasMedicas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult Nombre(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join p in db.Pacientes
                             on i.IdPacientes equals p.IdPaciente
                             where i.IdIngreso == clavePaciente
                             select p.Nombre).ToList();
            return Json(duplicado);
        }

        public JsonResult Monto(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join h in db.Habitaciones
                             on i.IdHabitaciones equals h.IdHabitacion
                             where i.IdIngreso == clavePaciente
                             select h.Precio).ToList();
            return Json(duplicado);
        }

        public JsonResult FechaIngreso(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             where i.IdIngreso == clavePaciente
                             select i.FechaIngreso).ToList();
            return Json(duplicado);
        }

        public JsonResult NumeroHabitacion(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join h in db.Habitaciones
                             on i.IdHabitaciones equals h.IdHabitacion
                             where i.IdIngreso == clavePaciente
                             select h.Numero).ToList();
            return Json(duplicado);
        }
    }
}
