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
        zapisTableAdapter zapis = new zapisTableAdapter();
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

        public int sum()
        {
            int ct = 0;
            var data = zapis.GetData();

            foreach (var i in data)
            {
                ct += i.countMoney;
            }
            return ct;
        }

    }
}
