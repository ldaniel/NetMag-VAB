using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NetMag.Validation.Web.ServicoInscricao;
using NetMag.Validation.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;

namespace NetMag.Validation.Web.exemplos
{
    public partial class Exemplo03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidarAcesso_Click(object sender, EventArgs e)
        {
            // Instância do serviço WCF
            InscricaoClient inscricao = new InscricaoClient();
            Funcionario funcionario = new Funcionario();
            
            funcionario.Matricula = Convert.ToInt32(txtMatricula.Text);
            funcionario.Login = txtLogin.Text;
            
            divAlerta.Visible = true;

            try
            {
                /* Executa o método de validação de acesso,
                 * o Validation Application Block irá validar
                 * a entidade Funcionario com as definições de 
                 * validação.
                 */
                if (inscricao.ValidarAcessoInscricao(funcionario))
                {
                    lblMensagemValidacao.Text = "Acesso válido.";
                }
            }
            catch (FaultException<ValidationFault> ex)
            {
                /* Para acessarmos os erros encontrados
                 * na validação devemos recuperar a exceção do tipo
                 * ValidationFault.
                 */
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
