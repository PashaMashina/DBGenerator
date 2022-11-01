using System.Data;
using System.Data.SqlClient;

namespace DBGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new();
            connection.ConnectionString = txtConnectionString.Text;
            connection.Open();

            SqlCommand command = new();
            command.Connection = connection;
            command.CommandText = txtQuery.Text;

            var reader = command.ExecuteReader();

            DataTable table = new();
            table.Load(reader);
            dgName.DataSource = table;

            reader.Close();

            connection.Close();
        }
    }
}