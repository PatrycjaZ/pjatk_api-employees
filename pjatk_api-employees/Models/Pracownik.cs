using System;
using System.Collections.Generic;

namespace pjatk_api_employees.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            UdzialWSpotkaniu = new HashSet<UdzialWSpotkaniu>();
        }

        public int Idpracownik { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public int? RokUr { get; set; }
        public string Miasto { get; set; }
        public string Stanowisko { get; set; }
        public string Email { get; set; }
        public string NrTel { get; set; }
        public string TablicaInfo { get; set; }

        public virtual ICollection<UdzialWSpotkaniu> UdzialWSpotkaniu { get; set; }
    }
}
