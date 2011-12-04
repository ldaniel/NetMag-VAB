using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

using NetMag.Validation.Entidades;

namespace NetMag.Validation.Web.exemplos
{
    public partial class FichaInscricao02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Participante participante = new Participante(
                txtNome.Text, txtEmail.Text,
                Convert.ToDateTime(txtDataNascimento.Text), 
                DateTime.Now, ddlMeioComunicacao.SelectedValue,
                txtVoucher.Text, txtComentarios.Text);

            Validator<Participante> validador =
                ValidationFactory.CreateValidator<Participante>();
            
            ValidationResults resultados = validador.Validate(participante);

            if (!resultados.IsValid)
            {
                StringBuilder sbValidacao = new StringBuilder();
                sbValidacao.Append("<b>Atenção!</b><br />");
                sbValidacao.Append("<b>Os seguintes campos estão inconsistentes:</b><br /><br />");

                foreach (ValidationResult result in resultados)
                {
                    sbValidacao.Append(String.Format("- <b>{0}</b><br />",
                        result.Key.ToString()));
                    sbValidacao.Append(String.Format("&nbsp; {0} ",
                        result.Message));
                    sbValidacao.Append("<br /><br />");
                }

                divAlerta.Visible = true;
                lblMensagemValidacao.Text = sbValidacao.ToString();
            }
            else
            {
                divAlerta.Visible = false;
            }
        }
    }
}
