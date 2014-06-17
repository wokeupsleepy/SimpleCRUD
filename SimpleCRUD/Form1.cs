using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SimpleCRUD
{
    public partial class Form1 : Form
    {
        //ArrayList listBoxContents = new ArrayList();
        List<string> listBoxContents = new List<string>();
        TextReader reader = new TextReader();
        
        public Form1()
        {
            InitializeComponent();

            // TODO need to save contents to a file

            listBox1.DataSource = listBoxContents;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RepopulateListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = listBoxContents;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "")
            {
                listBoxContents.Add(inputTextBox.Text);
                inputTextBox.Text = "";
            }

            RepopulateListBox();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            try
            {
                listBoxContents.RemoveAt(selectedIndex);
            }
            catch
            {
            }

            RepopulateListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reader.filePath = openFileDialog1.FileName;
                reader.AddText();

                while (reader.IsEndStream() == false)
                {
                    listBoxContents.Add(reader.ReadFirstLine());
                }

                reader.CloseStream();

                RepopulateListBox();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {

                System.IO.File.WriteAllLines(reader.filePath, listBoxContents);
                MessageBox.Show("Save completed!");
            }
            catch (ArgumentNullException noFileSelected)
            {
                MessageBox.Show("You have not selected a file to write to.");
            }
            
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            object selectedEntry = listBox1.SelectedItem;
            int selectedIndex = listBox1.SelectedIndex;

            listBoxContents.RemoveAt(selectedIndex);
            listBoxContents.Insert(selectedIndex, inputTextBox.Text);

            RepopulateListBox();
            inputTextBox.Text = "";
        }

    }
}
