using System;
namespace prism1.Models
{
    public class Infracao
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        public override string ToString()
        {
            return string.Format("[Infracao: Id={0}, Usuario={1}, Descricao={2}]", Id, Usuario, Descricao);
        }
    }
}
