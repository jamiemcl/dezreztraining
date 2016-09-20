using System;

namespace Dezrez.Rezi.DataContracts
{
    public class BaseDataContract
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}