using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EplAutoTuneConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Eplan.EplApi.DataModel.ProjectManager projectManager = new Eplan.EplApi.DataModel.ProjectManager();
            foreach (var item in projectManager.OpenProjects)
            {
                Console.WriteLine($"Project : {item.ProjectName}");
            }
            Console.ReadLine();
        }
    }
}
