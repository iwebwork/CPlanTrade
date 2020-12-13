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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "iu89vBVEQLL9PvidW5ChOBeHbbKoCJCAHTqiNhRz",
            BasePath = "https://control-plain-trade-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;


        private void Register_Load(object sender, EventArgs e)
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)
                && string.IsNullOrWhiteSpace(tbLogin.Text)
                && string.IsNullOrWhiteSpace(tbSenha.Text))
            {
                MessageBox.Show("Por favor preencha todos os campos!");
                return;
            }

            User user = new User()
            {
                Name = txtFullName.Text,
                Login = tbLogin.Text,
                Password = tbSenha.Text
            };

            SetResponse set = client.Set(@"Users/" + tbLogin.Text, user);

            MessageBox.Show("Sucesso, usuario cadastrado com sucesso!");
            FormLogin lo = new FormLogin();
            this.Hide();
            lo.Show();
            
        }
    }
}
