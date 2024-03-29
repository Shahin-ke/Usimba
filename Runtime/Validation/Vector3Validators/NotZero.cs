﻿using UnityEngine;

namespace SH_SWAT.Usimba.Validation.Vector3Validators
{
    public class NotZero : BaseTypedValidator<Vector3>
    {
        public override ValidationResult IsValid(Vector3 obj, ValidationContext context)
        {
            return Vector3.zero == obj ? ValidationResult.Rejected : ValidationResult.Accepted;
        }
    }
}