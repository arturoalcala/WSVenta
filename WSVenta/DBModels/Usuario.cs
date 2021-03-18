using System;
using System.Collections.Generic;

#nullable disable

namespace WSVenta.DBModels
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
