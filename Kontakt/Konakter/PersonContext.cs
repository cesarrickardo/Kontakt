using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Kontakt.Konakter
{
   public class PersonContext : DbContext
    {
        public DbSet<Person> contact { get; set; }

        internal static Person FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
