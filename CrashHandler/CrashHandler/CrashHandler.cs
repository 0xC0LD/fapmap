using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CrashHandler
{
    class CrashHandler
    {
        static int Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.Write("USAGE: CrashHandler.exe <pid> <path> <name>");
                return 1;
            }
            
            if (!int.TryParse(args[0], out int pid))
            {
                Console.Write("ERROR: Invalid PID");
                return 1;
            }

            string path = args[1];
            if (!File.Exists(path))
            {
                Console.Write("ERROR: File Not Found");
                return 1;
            }
            string name = args[2];

            while (true)
            {
                try
                {
                    Process p = Process.GetProcessById(pid);
                }
                catch (System.ArgumentException)
                {
                    switch (MessageBox.Show(
                        name + " exited unexpectedly..." + Environment.NewLine +
                        "Do you want to restart the program?",
                        name + " crashed?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error)
                    ) { case DialogResult.Yes: Process.Start(path); break; }

                    return 0;
                }
                Thread.Sleep(500);
            }
            
            return 0;
        }
    }
}
