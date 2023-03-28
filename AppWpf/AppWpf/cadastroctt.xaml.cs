using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace AppWpf
{
    /// <summary>
    /// Lógica interna para cadastroctt.xaml
    /// </summary>
    public partial class cadastroctt : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public cadastroctt()
        {
            InitializeComponent();
            Conexao();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();

        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            try
            {


                var nome = txtNome.Text;
                var email = txtEmail.Text;
                var datanasc = dtpData.Value;
                var telefone = txtTelefone.Text;
                var sexo = txtSexo.Text;


                string query = "INSERT INTO contato_con (nome_con,email_con, data_nasc_con, sexo_con, telefone_con ) VALUES (@_nome,  @_email, @_dataNascimento, @_sexo, @_telefone)";
                var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@_nome", nome);
                comando.Parameters.AddWithValue("@_email", email);
                comando.Parameters.AddWithValue("@_dataNascimento", datanasc);
                comando.Parameters.AddWithValue("@_sexo", sexo);
                comando.Parameters.AddWithValue("@_telefone", telefone);

                comando.ExecuteNonQuery();
                comando.ExecuteNonQuery();

                MessageBox.Show("Dados salvos com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao salvar informações! " +
                    "Contate a equipe de suporte do sistema. (cad 10)");
            }
        }
    }
}
