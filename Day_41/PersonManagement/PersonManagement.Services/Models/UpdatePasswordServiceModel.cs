﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Services.Models
{
    public class UpdatePasswordServiceModel
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
