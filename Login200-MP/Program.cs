using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login200_MP
{
    public delegate void inputHandler(State state, String args);
    public delegate void StateObs(State state);
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            CredentialsMP model = new CredentialsMP();
            ControllerMP controller = new ControllerMP(model);
            LoginMP view = new LoginMP(controller.handleEvents);
            controller.registerObs(view.DisplayState);
            Application.Run();
        }
    }
}
