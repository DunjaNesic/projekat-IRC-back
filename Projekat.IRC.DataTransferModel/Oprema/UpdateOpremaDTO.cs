using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.DataTransferModel.Oprema
{
    public class UpdateOpremaDTO
    {
        public int Status { get; set; }
        public byte[] RowVersion { get; set; }
        
    }
}
