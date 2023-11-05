using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para atualização de dados de um cliente.
    /// </summary>
    public class UpdateClienteModelView: NewClienteModelView
    {
        /// <summary>
        /// Id do cliente a ser atualizado.
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }
    }
}
