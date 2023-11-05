using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Core.Domain
{
    /// <summary>
    /// Objeto cliente.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Id do cliente. Campo numérico inteiro, autoincrementável.
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente.
        /// </summary> 
        /// <example>José da Silva</example>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Data de nascimento do cliente.
        /// </summary>
        /// <example>1976-01-01</example>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gênero do cliente, só existem 2.
        /// </summary>
        /// <example>M</example>
        public char Gender { get; set; }

        /// <summary>
        /// Telefone do cliente. pode ser no formato (99)99999-9999 ou 9999999999.
        /// </summary>
        /// <example>(21)98767-9087</example>
        public string PhoneNumber { get; set; } = string.Empty.PadLeft(10, '0');

        /// <summary>
        /// Email do cliente.
        /// </summary>
        /// <example>jose.silva@email.com</example>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Documento do cliente. RG,CNH ou CPF. Aceita traços e pontos
        /// </summary>
        /// <example>024.653.984-85</example>
        public string Document { get; set; } = string.Empty;

        /// <summary>
        /// Data de criação do registro do cliente. Gerenciuada pela API.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização no registro do cliente. Gerenciada pela API.
        /// </summary>
        public DateTime? LastUpdatedAt { get; set;}
    }
}
