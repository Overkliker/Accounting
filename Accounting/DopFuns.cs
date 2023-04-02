using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.countMoneyDataSetTableAdapters;

namespace Accounting
{
    internal class DopFuns
    {
        typesZapTableAdapter types = new typesZapTableAdapter();
        public static string dateCon()
        {
            string date = DateTime.Now.Date.ToString("dd/MM/yyyy");
            return date;
          
        }
        public static string timeCon(string date)
        {
            return date.Substring(0, 10);
        }
        public void addType(string name)
        {
            types.InsertQuery(name);
        }

    }
}
