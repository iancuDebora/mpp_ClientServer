using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.model
{
    public class Donatie : HasId<int>
    {
        private int id;
        private int idD;
        private int idC;
        private Double suma;

        public Donatie(int id, int idD, int idC, double suma)
        {
            this.id = id;
            this.idD = idD;
            this.idC = idC;
            this.suma = suma;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdD
        {
            get { return idD; }
            set { value = idD; }
        }

        public int IdC
        {
            get { return idC; }
            set { idC = value; }
        }

        public Double Suma
        {
            get { return suma; }
            set { suma = value; }
        }

        public override bool Equals(object obj)
        {
            var donatie = obj as Donatie;
            return donatie != null &&
                   id == donatie.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Donatie: Id={0}, IdD={1}, IdC={2}, SumaTotala={3}]", Id, IdD,IdC,Suma);
        }


    }
}
