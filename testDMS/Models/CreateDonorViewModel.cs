﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testDMS.Models
{
    public class CreateDonorViewModel
    {
        public DONOR donor { get; set; }   
        public COMPANY company { get; set; }
        public CONTACT contact { get; set; }
        public IDENTITYMARKER identityMarker { get; set; }
    }
}