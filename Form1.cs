using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Note_Taking_App_V2
{
    public partial class NoteBook : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteBook()
        {
            InitializeComponent();
        }


        private void NoteBook_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Text");
            dataGridPastNotes.DataSource = notes;
            dataGridPastNotes.Columns["Text"].Visible = false;
            dataGridPastNotes.Columns["Title"].Width = 275;
           
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (editing)
                {
                    notes.Rows[dataGridPastNotes.CurrentCell.RowIndex]["Title"] = textBoxTitle.Text;
                    notes.Rows[dataGridPastNotes.CurrentCell.RowIndex]["Text"] = textBoxText.Text;
                }
                else
                    notes.Rows.Add(textBoxTitle.Text, textBoxText.Text);
                editing = false;
            }
            catch (Exception ex) { Console.WriteLine("Invalid note"); }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = "";
            textBoxText.Text = "";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = notes.Rows[dataGridPastNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            textBoxText.Text = notes.Rows[dataGridPastNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void dataGridPastNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxTitle.Text = notes.Rows[dataGridPastNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
                textBoxText.Text = notes.Rows[dataGridPastNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
                editing = true;
            }
            catch { }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[dataGridPastNotes.CurrentCell.RowIndex].Delete();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid note");
            }
        }
        
private void NoteBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}