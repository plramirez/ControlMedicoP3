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
    public class CitasMedicasController : Controller
    {
        private ControlMedicoContext db = new ControlMedicoContext();

        // GET: CitasMedicas
        public ActionResult Index()
        {
            var citasMedicas = db.CitasMedicas.Include(c => c.Medicos).Include(c => c.Pacientes);
            return View(citasMedicas.ToList());
        }

        // GET: CitasMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            if (citasMedicas == null)
            {
                return HttpNotFound();
            }
            return View(citasMedicas);
        }

        // GET: CitasMedicas/Create
        public ActionResult Create()
        {
            ViewBag.IdMedicos = new SelectList(db.Medicos, "IdMedico", "Nombre");
            ViewBag.IdPacientes = new SelectList(db.Pacientes, "IdPaciente", "Nombre");
            return View();
        }

        // POST: CitasMedicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCitas,IdPacientes,IdMedicos,Fecha,Hora")] CitasMedicas citasMedicas)
        {
            if (ModelState.IsValid)
            {
                db.CitasMedicas.Add(citasMedicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMedicos = new SelectList(db.Medicos, "IdMedico", "Nombre", citasMedicas.IdMedicos);
            ViewBag.IdPacientes = new SelectList(db.Pacientes, "IdPaciente", "Cedula", citasMedicas.IdPacientes);
            return View(citasMedicas);
        }

        // GET: CitasMedicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            if (citasMedicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMedicos = new SelectList(db.Medicos, "IdMedico", "Nombre", citasMedicas.IdMedicos);
            ViewBag.IdPacientes = new SelectList(db.Pacientes, "IdPaciente", "Cedula", citasMedicas.IdPacientes);
            return View(citasMedicas);
        }

        // POST: CitasMedicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCitas,IdPacientes,IdMedicos,Fecha,Hora")] CitasMedicas citasMedicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citasMedicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMedicos = new SelectList(db.Medicos, "IdMedico", "Nombre", citasMedicas.IdMedicos);
            ViewBag.IdPacientes = new SelectList(db.Pacientes, "IdPaciente", "Cedula", citasMedicas.IdPacientes);
            return View(citasMedicas);
        }

        // GET: CitasMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            if (citasMedicas == null)
            {
                return HttpNotFound();
            }
            return View(citasMedicas);
        }

        // POST: CitasMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            db.CitasMedicas.Remove(citasMedicas);
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
    }
}
