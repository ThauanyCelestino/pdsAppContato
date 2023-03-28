using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para listar.xaml
    /// </summary>
    public partial class listar : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public listar()
        {
            InitializeComponent();

            Conexao();
            CarregarDados();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();

        }

        private void CarregarDados()
        {
            try
            {
                Conexao();
                string query = "Select * From contato_con";
                var comando = new MySqlCommand(query, conexao);
                var adaptador = new MySqlDataAdapter(comando);

                DataTable tabela = new DataTable();

                adaptador.Fill(tabela);
                dgvContato.DataSource = tabela;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao listar as informações!" +
                    "Contate a equipe de suporte do sistema. (cad 10)");
            }
        }
    }
}
