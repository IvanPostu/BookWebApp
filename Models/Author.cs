using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Author
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public String FullName { get; set; }

        [DataMember(Order = 1)]
        public String Email { get; set; }

    }
}
