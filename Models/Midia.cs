using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    [Table("Midias")]
    public class Midia
    {
        public int MidiaId { get; set; }
        public string Name { get; set; }
        public IFormFile Data { get; set; }

        public Midia(string name, IFormFile data)
        {
            Name = name;
            Data = data;
        }
    }
}
