using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class CoverDTO
    {
        public int CoversId { get; set; }
        public string Title { get; set; }
        public bool DigitalOnly { get; set; }

        public List<ArtistDTO> Artists { get; set; }
    }
}
