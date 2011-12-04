using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;

namespace NetMag.Validation.Entidades.ValidadoresCustomizados
{
    [ConfigurationElementType(typeof(CustomValidatorData))]
    public class VoucherValidator : Validator
    {
        public VoucherValidator() : base(null, null) { }

        protected override string DefaultMessageTemplate
        {
            get { return "O voucher {0} é inválido"; }
        }

        protected override void DoValidate(
            object objectToValidate, 
            object currentTarget, 
            string key, 
            ValidationResults validationResults)  
        {
            if (!IsValidVoucher((string)objectToValidate))
            {
                string message = string.Format(base.MessageTemplate, objectToValidate);
                base.LogValidationResult(validationResults, message, currentTarget, key);
            }
        }

        private bool IsValidVoucher(string voucher)
        {
            if (voucher.Length != 10)
            {
                return false;
            }

            if (voucher.Substring(0, 6).ToLower() != "netmag")
            {
                return false;
            }

            return true;
        }
    }
}