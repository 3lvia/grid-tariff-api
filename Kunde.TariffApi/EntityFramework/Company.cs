using System.Collections.Generic;

namespace Kunde.TariffApi.EntityFramework
{
    public partial class Company
    {
        public Company()
        {
            TariffType = new HashSet<TariffType>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<TariffType> TariffType { get; set; }
    }
}
