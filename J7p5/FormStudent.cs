using J7p5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J7p5
{
    public partial class FormStudent : Form
    {
        List<Student> students;
        Student selectedStudent;
        List<Proof> proofs;
        public FormStudent()
        {
            InitializeComponent();
            students = new List<Student>();
            selectedStudent = null;
            proofs = new List<Proof>();
        }

        private void txt_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //MessageBox.Show($"{a}");
            e.Handled = !char.IsDigit(e.KeyChar);
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RightLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            ShowProof();
        }

        private void Register_Clilck(object sender, EventArgs e)
        {
            if (txt_FirstName.Text.Trim() == "" || txt_LastName.Text.Trim() == "" || txt_ID.Text.Trim() == "" )
            {
                MessageBox.Show("اطلاعات نام ونام خانوادگی و شماره دانشجویی نمی تواند خالی باشد");
                return; 
            }
            int ProofId = Convert.ToInt32(comboProof.SelectedValue);
            Proof selectedproof = FindProofs(ProofId);
            if (selectedStudent == null)
            {
               //Register
                Student student = new Student();
                student.FirstName = txt_FirstName.Text.Trim();
                student.LastName = txt_LastName.Text.Trim();
                student.ID = Convert.ToInt16(txt_ID.Text.Trim());
                student.IsMarried = check_Marrid.Checked;
                student.Gender = radio_Female.Checked;
                student.proof = selectedproof;
                students.Add(student);

                MessageBox.Show("اطلاعات ثبت  شد");

            }
            else {
                //edit
                selectedStudent.FirstName = txt_FirstName.Text.Trim();
                selectedStudent.LastName = txt_LastName.Text.Trim();
                selectedStudent.ID = Convert.ToInt16(txt_ID.Text.Trim());
                selectedStudent.IsMarried = check_Marrid.Checked;
                selectedStudent.Gender = radio_Female.Checked;
                selectedStudent.proof = selectedproof;
                MessageBox.Show("اطلاعات ویرایش  شد");
            }
            
            ShowStudents();
            ClearText();
        }

        private void ClearText()
        {
            txt_FirstName.Text = txt_LastName.Text = txt_ID.Text = "";
            txt_FirstName.Focus();

            radio_male.Checked = true;
            check_Marrid.Checked = false;
            selectedStudent = null;
        }

        private void ShowStudents()
        {
            gridStudents.AutoGenerateColumns = false;
            gridStudents.DataSource = students.ToList();
            if (gridStudents.RowCount > 0)
                gridStudents.Rows[0].Selected = false;
        }

        private void gridStudents_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;


            //MessageBox.Show(gridStudents[e.ColumnIndex, e.RowIndex].Value.ToString());
            //MessageBox.Show(gridStudents[1, e.RowIndex].Value.ToString());
            //MessageBox.Show(gridStudents["Col_ID", e.RowIndex].Value.ToString());

            int _id = Convert.ToInt32(gridStudents["Col_ID", e.RowIndex].Value);
             selectedStudent = FindStudent(_id);

            if (selectedStudent != null)
            {
                txt_FirstName.Text = selectedStudent.FirstName;
                txt_LastName.Text = selectedStudent.LastName;
                txt_ID.Text = selectedStudent.ID.ToString();

                check_Marrid.Checked = selectedStudent.IsMarried;
                radio_Female.Checked = selectedStudent.Gender;
                radio_male.Checked = !selectedStudent.Gender;

            }
        }

        private Student FindStudent(int id)
        {
            foreach (var student in students)
            {
                if (student.ID == id)
                {
                    return student;
                }
            }

            return null;
        
        }

        private void NewRegister_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("لطفا موردی را از لیست انتخاب نمایید","خطا" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           var res =  MessageBox.Show("ایا مطمعن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (res == DialogResult.No) 
            {
                return;
            }
            students.Remove(selectedStudent);
            ShowStudents();
            ClearText();
            MessageBox.Show("اطلاعات با موفقیت حدف شد");

        }
        private void ShowProof()
        {
            proofs.Add(new Proof()
            {
                ID = 1,
                ProofName = "کاردانی" 
            });
            proofs.Add(new Proof
            {
                ID = 2,
                ProofName = "کارشناسی" 
            }); 
            proofs.Add(new Proof
            {
                ID = 3,
                ProofName = "ارشد" 
            }); 
            proofs.Add(new Proof
            {
                ID = 4,
                ProofName = "دکتری" 
            });

            comboProof.DataSource = proofs.ToList();
            comboProof.DisplayMember = "ProofName";
            comboProof.SelectedIndex = -1;
            comboProof.ValueMember = "ID";

        }

        private void gridStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Proof FindProofs(int id)
        {
            foreach (var proof in proofs)
            {
                if (proof.ID == id)
                {
                    return proof;
                }
            }

            return null;

        }
    }
}
