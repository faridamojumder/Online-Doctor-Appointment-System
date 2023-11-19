using DoctorAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentSystem.Controllers
{
    public class HomeController : Controller
    {
       
        [HttpGet]
        public ActionResult Single(int? id)
        {
            var db = new Model1();
            var oDoctor = (from o in db.Doctors where o.DoctorID == id select o).FirstOrDefault();
            oDoctor = oDoctor == null ? new Doctor() : oDoctor;
            ViewData["List"] = db.Doctors.ToList();
            ViewBag.SpecialistID = new SelectList(db.Specialists, "SpecialistID", "SpecialistName");
            return View(oDoctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Single(Doctor model, HttpPostedFileBase img)
        {
            string fileName = "";
            if (img != null)
            {
                fileName = img.FileName;
                // To save a image to a folder
                string picture = System.IO.Path.GetFileName(img.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Imgs"), picture);
                img.SaveAs(path);
            }
            var db = new Model1();
            var oDoctor = db.Doctors.Find(model.DoctorID);
            ViewBag.SpecialistID = new SelectList(db.Specialists, "SpecialistID", "SpecialistName");
            if (oDoctor == null)
            {
                #region insert
                model.Prescription = "/Imgs/" + fileName;
                db.Doctors.Add(model);
                #endregion
                ViewBag.Message = "inserted successfully.";
            }
            else
            {
                #region update
                oDoctor.DoctorName = model.DoctorName;
                oDoctor.Gender = model.Gender;
                oDoctor.ScheduleDate = model.ScheduleDate;
                oDoctor.Prescription = "/Imgs/" + fileName;
                oDoctor.TotalPatient = model.TotalPatient;
                oDoctor.Specialist.SpecialistName = model.Specialist.SpecialistName;
                #endregion
                ViewBag.Message = "updated successfully.";
            }
            db.SaveChanges();
            ViewData["List"] = db.Doctors.ToList();
            return RedirectToAction("Single");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new Model1();
            var oDoctor = (from o in db.Doctors where o.DoctorID== id select o).FirstOrDefault();
            if (oDoctor != null)
            {
                db.Doctors.Remove(oDoctor);
                db.SaveChanges();
            }
            return RedirectToAction("Single");
        }

    }
}