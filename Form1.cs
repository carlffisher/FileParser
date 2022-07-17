using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;
using ACSVFileParserForms1;
using System.Collections;

namespace ACSVFileParserForms
{
    public partial class Form1 : Form
    {
        public static List<CSVValues.getLine>? values;
        public string? filePathString;



        public Form1()
        {
            InitializeComponent();

            System.IO.Directory.SetCurrentDirectory("D:/Users/carlf/source/repos/AFileParser/");
            filePathString = Path.Combine(Directory.GetCurrentDirectory(), "csv", "input.csv");

            values = File.ReadAllLines(filePathString)
                                               .Skip(1)
                                               .Select(v => CSVValues.getLine.FromCsv(v))
                                               .ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Query 2: Return those living in Derbyshire ...

            ArrayList resultarraylist = CollectionOfQueries.ProcessQuery(values!, 2); //Send file and id of query

            StringBuilder outstringbuffer2 = new StringBuilder("", 200);

            foreach (var line in resultarraylist)
            {
                outstringbuffer2.Append("\n");
                outstringbuffer2.Append(line);
            }
            
            richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer2)));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Query 1: Return those with "esq" in Company Name ...

            ArrayList resultarraylist = CollectionOfQueries.ProcessQuery(values!, 1); //Send file and id of query

            StringBuilder outstringbuffer2 = new StringBuilder("", 200);

            foreach (var line in resultarraylist)
            {
                outstringbuffer2.Append("\n");
                outstringbuffer2.Append(line);
            }

            richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer2)));
        }
    }
}