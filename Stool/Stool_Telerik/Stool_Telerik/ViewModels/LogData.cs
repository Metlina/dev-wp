using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stool_Telerik.ViewModels
{
    public class LogData : ViewModelBase
    {
        private string log = string.Empty;
        private DateTime date = DateTime.Now;

        public string Log
        {
            get 
            {
                return log;
            }
            set
            {
                this.Set(ref this.log, value);
            }
        }

        public DateTime DateTime
        {
            get
            {
                return date;
            }
            set
            {
                this.Set(ref this.date, value);
            }
        }
        
        public LogData()
        {
            date = DateTime.Now;
        }
    }
}
