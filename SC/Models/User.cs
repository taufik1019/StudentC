using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class User
    {
        [Key]
        [ForeignKey("ProfilMahasiswa")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public ProfilMahasiswa ProfilMahasiswa { get; set; }
        public int ProfilMahasiswaId { get; set; }
       
        
        
        
     
       
    }
}
