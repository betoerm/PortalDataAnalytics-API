using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Tool
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Provedor { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        

    }
}
