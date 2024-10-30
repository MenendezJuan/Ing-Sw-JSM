using BEs.Clases;
using BEs.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BEs
{
    public class Usuario : Entidad, IVerificableEntity
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [PropiedadVerificable]
        public string Email { get; set; }

        protected string _Contraaseña;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(1)]
        [PropiedadVerificable]
        public string Contraseña
        {
            get
            {
                return _Contraaseña;
            }
            set
            {
                _Contraaseña = value;
            }
        }

        public string DV { get; set; }

        public Usuario()
        { }

        public Usuario(string email, string contraseña)
        {
            Email = email;
            Contraseña = contraseña;
            DV = null;
        }

        public Usuario(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public Usuario(int id, string email, string contraseña)
        {
            Id = id;
            Email = email;
            Contraseña = contraseña;
        }

        public Usuario(int id, string email, string contraseña, string dv)
        {
            Id = id;
            Email = email;
            Contraseña = contraseña;
            DV = dv;
        }

        public override string ToString()
        {
            return Email;
        }
    }
}