﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Convertors
{
  public  class FixedText
    {
        public static string FixedEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
