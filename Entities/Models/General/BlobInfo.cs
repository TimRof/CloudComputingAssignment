using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Blob
{
    public class BlobInfo
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
    }
}
