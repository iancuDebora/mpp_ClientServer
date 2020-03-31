using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.model
{
    public class Voluntar : HasId<int>
    {
        private int id;
        private String nume;
        private String email;
        private String parola;

        public Voluntar(int id, String nume, String email, String parola)
        {
            this.id = id;
            this.nume = nume;
            this.email = email;
            this.parola = parola;
        }

        public Voluntar(int id, String parola) : this(id, "", "", parola)
        {

        }


        public Voluntar(int id): this(id,"","","")
        {

        }

        public int Id {
            get { return id; }
            set { id = value; }
        }

        public String Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
    
        public String Parola
        {
            get { return parola; }
            set { parola = value; }
        }

        public override bool Equals(object obj)
        {
            var voluntar = obj as Voluntar;
            return voluntar != null &&
                   Id == voluntar.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Voluntar: Id={0}, Nume={1}, Email={2}, Parola={3}]", Id, Nume, Email, Parola);
        }
    }
}
