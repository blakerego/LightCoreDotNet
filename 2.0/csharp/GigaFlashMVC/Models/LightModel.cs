﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GigaFlashMVC.Models
{
    public class LightModel
    {
        [Key]
        public int index { get; set; }

        LightSetting Setting { get; set; }
    }
}