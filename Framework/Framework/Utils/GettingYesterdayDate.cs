using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Framework.Utils
{
    class GettingYesterdayDate
    {
        public static DateTime date = DateTime.Now;
        public string yesterdayDate = date.AddDays(-1).ToString("dd.MM.yyyy");
    }
}
