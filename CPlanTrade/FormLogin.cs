using Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPlanTrade
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "iu89vBVEQLL9PvidW5ChOBeHbbKoCJCAHTqiNhRz",
            BasePath = "https://control-plain-trade-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormRegister reg = new FormRegister();
            this.Hide();
            reg.ShowDialog();
            
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text)
                && string.IsNullOrWhiteSpace(tbSenha.Text))
            {
                MessageBox.Show("Por favor preencha todos os campos!");
                return;
            }

            FirebaseResponse response = client.Get(@"Users/" + tbLogin.Text);
            User Responseuser = response.ResultAs<User>();
            User currentUser = new User()
            {
                Login = tbLogin.Text,
                Password = tbSenha.Text

            };

            if (User.IsEqual(Responseuser, currentUser))
            {
                MessageBox.Show("Usuario logado com sucesso!");
            }
            else
            {
                MessageBox.Show(User.printError());
            }


        }
    }
}
