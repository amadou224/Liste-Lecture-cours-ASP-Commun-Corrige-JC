﻿using ListeLectureJCC.Models;
using System;
using System.Web.Mvc;

namespace ListeLectureJCC.Controllers
{
    public class LivresController : Controller
    {
        public ActionResult Accueil()
        {
            return View();
        }

        public ActionResult Detail(int idLivre)
        {
            DetailModel model = DataAccess.ChargerDetailDepuisBDD(idLivre);
            return View(model);
        }

        public ActionResult TerminerLivre(int idLivre)
        {
            DataAccess.MettreAJourDateDeFinDeLecture(idLivre);
            return RedirectToAction("ConfirmationLecture", new { idLivre = idLivre });
        }

        public ActionResult ConfirmationLecture(int idLivre)
        {
            ConfirmationLectureModel model = DataAccess.ChargerConfirmationLectureDepuisBDD(idLivre);
            return View(model);
        }

        public ActionResult ConfirmationNotation()
        {
            return View();
        }

        public ActionResult FormulaireCreation()
        {
            return View();
        }

        public ActionResult ConfirmationCreation()
        {
            return View();
        }
            
        public ActionResult SubmitCreationLivre(string Titre,string Auteur)
        {
            Livre nouvoLivre = new Livre(0, Titre, Auteur, null, DateTime.Now, null);

           return View();
        }
    }
}