using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    [Table("Midias")]
    public class Midia
    {
        public int MidiaId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
