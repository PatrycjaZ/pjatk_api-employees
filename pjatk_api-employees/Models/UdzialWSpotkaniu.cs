using System;
using System.Collections.Generic;

namespace pjatk_api_employees.Models
{
    public partial class UdzialWSpotkaniu
    {
        public int SpotkanieIdspotkanie { get; set; }
        public int PracownikIdpracownik { get; set; }
        public string MiejsceSpotkania { get; set; }

        public virtual Pracownik PracownikIdpracownikNavigation { get; set; }
        public virtual Spotkanie SpotkanieIdspotkanieNavigation { get; set; }
    }
}
