using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using NetMag.Validation.Entidades.ValidadoresCustomizados;

namespace NetMag.Validation.Entidades
{
    [HasSelfValidation]
    public class Participante
    {
        #region Propriedades
        [NotNullValidator]
        [StringLengthValidator(5, 100, MessageTemplate="O nome deve ter entre 5 e 100 caracteres")]
        public string Nome { get; private set; }

        [NotNullValidator]
        [RegexValidator(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", MessageTemplate="O E-mail informado está em um formato inválido")]
        public string Email { get; private set; }

        [ValidatorComposition(CompositionType.And)]
        [NotNullValidator]
        [RelativeDateTimeValidator(-120, DateTimeUnit.Year, -16, DateTimeUnit.Year, MessageTemplate = "Idade fora da faixa permitida, o mínimo é 16 anos")]
        public DateTime DataNascimento { get; private set; }

        [NotNullValidator]
        public DateTime DataInscricao { get; private set; }        
        
        public string MeioComunicacao { get; private set; }
        
        [VoucherValidator(MessageTemplate="Voucher inválido, favor solicitar um novo voucher",  Ruleset="ValidacaoAlternativa")]
        [VoucherValidator]
        public string Voucher { get; private set; }
        
        [StringLengthValidator(500, MessageTemplate="Os comentários não podem exceder 500 caracteres")]
        [RegexValidator(@"^[a-zA-Z0-9\040]+$", Ruleset = "ValidacaoHTMLEmbedding")]
        public string Comentarios { get; private set; }
        #endregion

        #region Métodos
        [SelfValidation]
        public void ChecaEmail(ValidationResults resultados)
        {
            if (Email.IndexOf("@empresa.com.br") > 0)
            {
                string mensagem = "Não é permitido utilizar e-mail do domínio" +
                    "'empresa.com.br'";
                resultados.AddResult(new ValidationResult(mensagem,
                        this, "Email", "", null));
            }
        }
        #endregion

        #region Construtores
        public Participante() { }

        public Participante(
            string nome, string email, 
            DateTime dataNascimento, DateTime dataInscricao, 
            string meioComunicacao, string voucher, 
            string comentarios)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;            
            DataInscricao = dataInscricao;            
            MeioComunicacao = meioComunicacao;
            Voucher = voucher;
            Comentarios = comentarios;
        }
        #endregion
    }
}
