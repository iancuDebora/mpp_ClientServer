using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.model
{
    public class CazCaritabil : HasId<int>
    {
        private int id;
        private String denumire;
        private Double sumaTotala;

        public CazCaritabil(int id, string denumire, double sumaTotala)
        {
            this.id = id;
            this.denumire = denumire;
            this.sumaTotala = sumaTotala;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Denumire
        {
            get { return denumire; }
            set { denumire = value; }
        }

        public Double SumaTotala
        {
            get { return sumaTotala; }
            set { sumaTotala = value; }
        }

        public override bool Equals(object obj)
        {
            var caritabil = obj as CazCaritabil;
            return caritabil != null &&
                   id == caritabil.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[CazCaritabil: Id={0}, Denumire={1}, SumaTotala={2}]", Id, Denumire, SumaTotala);
        }


    }
}
