using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Midia
    {
        public int MidiaId { get; set; }
        public string Description { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }

        public Midia()
        {
            if (Name != null)
            {
                var path = Path.GetFullPath(Name);
                var data = File.ReadAllBytes(path);
                Data = data;
                Name = path.ToString().Split('\\').Last();

                var ext = Name.Split('\\').Last().Split('.').Last();
                var base64 = Convert.ToBase64String(Data);
                Src = string.Format("data:image/{0};base64,{1}", ext, base64);
            }
        }

        public Midia(Midia midia)
        {
            MidiaId = midia.MidiaId;
            Description = midia.Description;
            var path = Path.GetFullPath(midia.Name);
            var data = File.ReadAllBytes(path);
            Data = data;
            Name = path.ToString().Split('\\').Last();

            var ext = Name.Split('\\').Last().Split('.').Last();
            var base64 = Convert.ToBase64String(Data);
            Src = string.Format("data:image/{0};base64,{1}", ext, base64);
        }
    }

}
