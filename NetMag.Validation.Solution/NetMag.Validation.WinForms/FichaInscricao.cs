using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Practices.EnterpriseLibrary.Validation;

using NetMag.Validation.Entidades;

namespace NetMag.Validation.WinForms
{
    public partial class FichaInscricao : Form
    {
        public FichaInscricao()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Participante participante = new Participante(
                txtNome.Text, txtEmail.Text, 
                Convert.ToDateTime(txtDataNascimento.Text),
                DateTime.Now, cbxMeioComunicacao.SelectedText,
                txtVoucher.Text, txtComentario.Text);

            //Validator<Participante> validador =
            //    ValidationFactory.CreateValidator<Participante>("ValidacaoHTMLEmbedding");
            Validator<Participante> validador =
                ValidationFactory.CreateValidator<Participante>();
            ValidationResults resultados = 
                validador.Validate(participante);

            if (!resultados.IsValid)
            {
                StringBuilder sbValidacao = new StringBuilder();                    
                sbValidacao.Append("Os seguintes campos estão inconsistentes:"
                    + Environment.NewLine);

                foreach (ValidationResult result in resultados)
                {
                    sbValidacao.Append(String.Format("- {0}" + 
                        Environment.NewLine, result.Key.ToString()));
                    sbValidacao.Append(String.Format("  {0} ",
                        result.Message));
                    sbValidacao.Append(Environment.NewLine);
                    sbValidacao.Append(Environment.NewLine);
                }

                MessageBox.Show(sbValidacao.ToString(), "Atenção!");
            }
        }
    }
}
