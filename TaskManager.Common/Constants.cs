using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public class Constants
    {
        public enum Status
        {
            NotStarted,
            InProgress,
            Failure,
            Success,
            Cancelled
        }
    }
}
