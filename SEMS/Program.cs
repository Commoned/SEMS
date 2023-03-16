using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SEMS.Adapter;
using SEMS.Application;
using SEMS.Domain;


namespace SEMS
{
   
    public class Program
    {

        [STAThread]
        static public void Main(String[] args)
        {
            GuiAdapter page = new MainPage();
            
            page.invokeGUI();
        }
    }
}
