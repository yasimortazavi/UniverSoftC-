using J7p5.Framework;
using J7p5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J7p5
{
    public partial class FormProof : Form
    {
        List<Proof> proofs = null;
        Proof selectedProoof = null;
        public FormProof()
        {
            InitializeComponent();
            proofs = new List<Proof>();
        }

        private void RightLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.; Initial Catalog = UnivDB; Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);


            //if insert- update - delete 
            //Command.ExecuteNonQuery();


            //if select
            //Command.ExecuteReader();

            string cmd = $"insert into Proof(ProofName) values(N'{txt_ProofName.Text.Trim()}')";
            SqlCommand Command = new SqlCommand(connectionString);
            Command.CommandText = cmd;
            Command.Connection = connection;

            connection.Open();

            Command.ExecuteNonQuery();

            connection.Close();

            clearText();
            MessageBox.Show("با موفقیت ثبت شد.");
            ShowProofs();
        }

        private void clearText()
        {
            txt_ProofName.Text = "";
            txt_ProofName.Focus();
            if (gridProof.RowCount != 0)
                gridProof.Rows[0].Selected = false;
        }

        private void FormProof_Load(object sender, EventArgs e)
        {
            ShowProofs();
        }

        private void ShowProofs()
        {
            proofs.Clear();
            string connectionString = "Data Source=.; Initial Catalog = UnivDB; Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            string cmd = $"select * from Proof";
            SqlCommand Command = new SqlCommand(connectionString);
            Command.CommandText = cmd;
            Command.Connection = connection;

            connection.Open();

            var reader = Command.ExecuteReader();
            // reader.Read(); سطر به سطر میخواند


            while (reader.Read())
            {
                Proof proof = new Proof
                {
                    ProofName = reader[1].ToString(),
                    ID = Convert.ToInt32(reader[0])
                };
                
                proofs.Add(proof);

              
            }

            connection.Close();
            gridProof.AutoGenerateColumns = false;
            gridProof.DataSource = proofs.ToList();


        }

        private void gridProof_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridProof_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            int id = Convert.ToInt32(gridProof["Col_ID",e.RowIndex].Value);
            selectedProoof =  FindProof(id);
            if (selectedProoof != null)
            {
                txt_ProofName.Text = selectedProoof.ProofName;
            }
        }
        private Proof FindProof(int id)
        {
            foreach ( var proof in proofs)
            {
                if (proof.ID == id )
                
                    return proof;
                

               
            }
            return null;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (selectedProoof  == null) return;
            if (!MyMessageBox.ConfirmMsg()) return;

        }
    }
}
