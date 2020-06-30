using System;
using System.Collections.Generic;

namespace pjatk_api_employees.Models
{
    public partial class Projekt
    {
        public Projekt()
        {
            Spotkanie = new HashSet<Spotkanie>();
        }

        public int Idprojekt { get; set; }
        public string Projekt1 { get; set; }
        public string Opis { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Priorytet { get; set; }

        public virtual ICollection<Spotkanie> Spotkanie { get; set; }
    }
}
