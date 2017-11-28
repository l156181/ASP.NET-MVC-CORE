using System;
using System.Collections.Generic;

namespace alura_tunes_entities.Model
{    
    public partial class Cliente
    {

        public Cliente()
        {
            this.NotaFiscals = new HashSet<NotaFiscal>();
        }
    
        public int ClienteId { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Empresa { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<int> SuporteId { get; set; }
    
        public virtual Funcionario Funcionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotaFiscal> NotaFiscals { get; set; }
    }
}
