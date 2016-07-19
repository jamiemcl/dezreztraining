using System.Collections.Generic;

namespace Dezrez.Rezi.DataContracts.System
{
    public class ApiErrorDataContract
    {
        public string Message { get; set; }
        public string ErrorReference { get; set; }
        public string Details { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
    }
}