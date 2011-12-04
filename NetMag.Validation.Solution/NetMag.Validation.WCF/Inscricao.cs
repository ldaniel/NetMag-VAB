using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NetMag.Validation.WCF
{
    public class Inscricao : IInscricao
    {
        public bool ValidarAcessoInscricao(Funcionario funcionario)
        {
            /* Aqui será acrescentado o código
             * com as validações de acesso do
             * funcionário
            */
            return true;
        }
    }
}
