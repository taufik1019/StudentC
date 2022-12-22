using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class ProfilMahasiswa
    {
        [Key]
        public int Id { get; set; }
        public string Prodi { get; set; }
        public DateTime TanggalLahir { get; set; }
        public int Semester { get; set; }
        public int Npm { get; set; }
        public string Alamat { get; set; }
       
    }
}
