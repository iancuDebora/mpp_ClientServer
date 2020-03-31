using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.model
{
	public interface HasId<T>
	{
		T Id { get; set; }
	}
}
