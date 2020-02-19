﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Template.Model.CoreHelpers
{
    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
          var isValid=  DateTime.TryParseExact(Convert.ToString(value),
              "dd/MM/yyyy",
              CultureInfo.CurrentCulture,
              DateTimeStyles.None,
              out dateTime);
            return (isValid);
        }
    }
}