using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.client
{
    public enum VoluntarEvent
    {
        NewDonator,UpdatedCaz
    };
    public class VoluntarEventArgs : EventArgs
    {
        private readonly VoluntarEvent userEvent;
        private readonly Object data;

        public VoluntarEventArgs(VoluntarEvent userEvent, object data) : this(userEvent)
        {
            this.data = data;
        }

        public VoluntarEventArgs(VoluntarEvent userEvent)
        {
            this.userEvent = userEvent;
           
        }

        public VoluntarEvent UserEventType
        {
            get { return userEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}
