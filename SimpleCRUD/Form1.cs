using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRUD
{
    public partial class Form1 : Form
    {

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

        private void repopulateListBox()
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

            repopulateListBox();
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

            repopulateListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reader.filePath = openFileDialog1.FileName;
                reader.addText();

                while (reader.isEndStream() == false)
                {
                    listBoxContents.Add(reader.readFirstLine());
                }

                reader.closeStream();

                repopulateListBox();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
