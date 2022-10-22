using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia
{
    public partial class F_Login : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();
        public F_Login(Form1 f)
        {
            InitializeComponent();
            form1 = f;
           
        }

        private void btn_Logar_Click(object sender, EventArgs e)
        {
            // pegar os dados e colcoar em variáveis
            string username = tb_UserName.Text;
            string senha = tb_Senha.Text;

            if (username == "" || senha == "")
            {
                MessageBox.Show("Usuário ou senha inválidos");
                tb_UserName.Focus();
                return;
            }

            string sql = "SELECT * FROM tb_usuarios WHERE T_USER_NAME='" + username + "' AND T_SENHA_USUARIO = '" + senha + "'";
            // DataTable retorna o resultado da consulta
            dt = Banco.Consulta(sql);


            //Colcoar o username como chave primaria e nao existir dois dados com o mesmo valor
            if (dt.Rows.Count == 1)
            {
                form1.lb_Acesso.Text = dt.Rows[0].ItemArray[5].ToString();
                form1.lb_NomeUsuario.Text = dt.Rows[0].Field<string>("T_NOME_USUARIO");
                form1.pb_LedLogado.Image = Properties.Resources.icons8_unlocked_48;
                Globais.nivel = int.Parse(dt.Rows[0].Field<Int64>("N_NIVEL_USUARIO").ToString());
                Globais.logado = true;
                this.Close();
            }

            else
            {

                MessageBox.Show("Usuário não eencontrado");
            }

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();  
        }
    }
}
