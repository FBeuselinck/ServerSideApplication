﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.WebApp.Models;

namespace Zoekertjes.WebApp.PresentationModels
{
    public class PMNewZoekertje
    {
        public PMNewZoekertje()
        {
            NewZoekertje = new Zoekertje();
        }
        public Zoekertje NewZoekertje { get; set; }
        public SelectList Categories;
        public SelectList Locaties;
    }
}