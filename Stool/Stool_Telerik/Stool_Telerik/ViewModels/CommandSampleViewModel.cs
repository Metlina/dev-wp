using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Stool_Telerik.Commands;

namespace Stool_Telerik.ViewModels
{
    public class CommandSampleViewModel
    {
        public ICommand SendAnEmailCommand
        {
            get;
            private set;
        }

        public CommandSampleViewModel()
        {
            SendAnEmailCommand = new SendAnEmailCommand();
        }
    }
}
