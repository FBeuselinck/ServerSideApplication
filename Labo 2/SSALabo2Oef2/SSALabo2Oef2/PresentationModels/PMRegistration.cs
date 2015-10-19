using SSALabo2Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSALabo2Oef2.PresentationModels
{
    public class PMRegistration
    {
        public PMRegistration()
        {
            NewRegistration = new Registration();
        }

        public Registration NewRegistration { get; set; }

        public SelectList Slot1;
        public SelectList Slot2;
        public SelectList Slot3;
        public SelectList Organizations;
    }
}