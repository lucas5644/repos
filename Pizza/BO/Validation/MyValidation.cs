﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BO.Validation
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class MyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            if (value.ToString().StartsWith("F"))
            {
                result = true;
            }
            return result;
        }
    }
}