using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Konakter
{
  public  class Person_info
    {
        public int Person_infoID { get; set; }
        public string Phone { get; set; }
        public string Addres { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int PersonID { get; set; }
        public virtual Person person { get; set; }
    }
}
