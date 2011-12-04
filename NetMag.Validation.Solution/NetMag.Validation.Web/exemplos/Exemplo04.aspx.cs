using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

using NetMag.Validation.Web.ServicoInscricao;
using NetMag.Validation.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;

namespace NetMag.Validation.Web.exemplos
{
    public partial class Exemplo04 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public OperationDescription ObterOperationDescription(
            Type contractType,
            string operationName)
        {
            ContractDescription contract = new ContractDescription(contractType.Name);
            OperationDescription operation = new OperationDescription(operationName, contract);
            operation.SyncMethod = contractType.GetMethod(operationName);
            return operation;
        }

        protected void btnValidarAcesso_Click(object sender, EventArgs e)
        {
            InscricaoClient inscricao = new InscricaoClient();
            
            OperationDescription operation = 
                ObterOperationDescription(typeof(NetMag.Validation.WCF.IInscricao),
                "ValidarAcessoInscricao");
            
            ValidationParameterInspector validationInspector =
                new ValidationParameterInspector(operation, "Validar");
           
            divAlerta.Visible = true;

            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Matricula = Convert.ToInt32(txtMatricula.Text);
                funcionario.Login = txtLogin.Text;

                validationInspector.BeforeCall("ValidarAcessoInscricao", 
                    new object[] { funcionario });
                
                lblMensagemValidacao.Text = "Acesso válido.";

            }
            catch (FaultException<ValidationFault> ex)
            {
                ValidationFault inconsistencias = ex.Detail;

                StringBuilder resultado = new StringBuilder();
                resultado.Append("<b>Atenção!</b><br />");
                resultado.Append("<b>Os seguintes campos estão inconsistentes:</b><br /><br />");

                foreach (ValidationDetail validationResult in inconsistencias.Details)
                {
                    resultado.Append(String.Format("- <b>{0}</b><br />",
                        validationResult.Key.ToString()));
                    resultado.Append(String.Format("&nbsp; {0} ",
                        validationResult.Message));
                    resultado.Append("<br /><br />");
                }

                lblMensagemValidacao.Text = resultado.ToString();
            }
            finally
            {
                inscricao.Close();
            }
        }
    }
}
