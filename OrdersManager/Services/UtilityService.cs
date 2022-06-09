using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class UtilityService
    {
        public bool IsDigitsOnly(string dane)
        {
            foreach (char c in dane)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
