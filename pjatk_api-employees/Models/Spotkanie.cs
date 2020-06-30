using System;
using System.Collections.Generic;

namespace pjatk_api_employees.Models
{
    public partial class Spotkanie
    {
        public Spotkanie()
        {
            UdzialWSpotkaniu = new HashSet<UdzialWSpotkaniu>();
        }

        public int Idspotkanie { get; set; }
        public string Spotkanie1 { get; set; }
        public string Cel { get; set; }
        public string Opis { get; set; }
        public DateTime DataSpotkania { get; set; }
        public TimeSpan GodzRozp { get; set; }
        public TimeSpan GodzZak { get; set; }
        public int? ProjektIdprojekt { get; set; }

        public virtual Projekt ProjektIdprojektNavigation { get; set; }
        public virtual ICollection<UdzialWSpotkaniu> UdzialWSpotkaniu { get; set; }
    }
}
