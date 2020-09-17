using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login200_MP
{
    public partial class LoginMP : Form
    {
        inputHandler iHandler;

        public LoginMP(inputHandler ih)
        {
            InitializeComponent();
            this.iHandler = ih;
        }

        private void LoginMP_Load(object sender, EventArgs e)
        {
            
        }
        

        /// <summary>
        /// THis method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(State state)
        {
            switch (state)
            {
                case State.START:
                    lbStateMessage.Text = "Please Enter Username";
                    tbPassword.Enabled = false;
                    uxLoginBtn.Enabled = false;
                    break;
                case State.GOTUSERNAME:
                    lbStateMessage.Text = "Please Enter Password";
                    tbPassword.Enabled = true;
                    break;
                case State.GOTPASSWORD:
                    lbStateMessage.Text = "Validating Credentials...";
                    break;
                case State.DECLINED:
                    tbUserName.Text = "";
                    tbPassword.Text = "";
                    lbStateMessage.Text = "Sorry, Invalid Credentials";
                    break;
                case State.SUCCESS:
                    lbStateMessage.Text = "Congrats! You are Loggedin";
                    break;
                default:
                    lbStateMessage.Text = "Invalid State";
                    break;

            }
        }

        /// <summary>
        /// Listener to the Login button. It takes the user's input
        /// for the username and password and pass the values to the
        /// Controller along with the state the view is in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoginBtn_Click(object sender, EventArgs e)
        {
            String un = tbUserName.Text;
            String up = tbPassword.Text;
            Console.WriteLine(un + " " + up);
            iHandler(State.GOTPASSWORD, un + ":" + up);

        }

        /// <summary>
        /// Links the View to the controller.
        /// </summary>
        /// <param name="c">The App's main controller object. Later
        /// this shold be a delegate.</param>
        public void SetController(inputHandler c)
        {
            iHandler = c;
        }

        /// <summary>
        /// TO synch the View and the Controller objects.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            iHandler(State.START, "");
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            iHandler(State.GOTUSERNAME, "");
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            uxLoginBtn.Enabled = true;
        }
    }
}
