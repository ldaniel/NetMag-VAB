using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace NetMag.Validation.WCF
{
    [ServiceContract(Name="IInscricao")]
    [ValidationBehavior(RuleSet="Validar")]
    public interface IInscricao
    {
        [OperationContract(Name = "ValidarAcessoInscricao")]
        [FaultContract(typeof(ValidationFault))]
        bool ValidarAcessoInscricao(Funcionario funcionario);
    }

    [DataContract]
    public class Funcionario
    {
        [DataMember]
        [NotNullValidator(Ruleset="Validar")]
        [RangeValidator(100, 
            RangeBoundaryType.Inclusive, 200, 
            RangeBoundaryType.Inclusive, 
            MessageTemplate="A matricula deve ser um número entre 100 e 200",
            Ruleset = "Validar")]
        public int Matricula { get; set; }
        
        [DataMember]
        [NotNullValidator(Ruleset = "Validar")]
        [StringLengthValidator(6, 8, 
            MessageTemplate = "O login deve ter entre 6 e 8 caracteres",
            Ruleset = "Validar")]
        public string Login { get; set; }
    }
}
