using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Company
    {
        public Company()
        {
            Tarifftype = new HashSet<Tarifftype>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Tarifftype> Tarifftype { get; set; }
    }
}
