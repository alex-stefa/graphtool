using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphTool
{
    public partial class Output : Form
    {
        public Output(String message, String output_text)
        {
            InitializeComponent();
            label.Text = message;
            textBox.Text = output_text;
            textBox.SelectAll();
            ShowDialog();
        }
    }
}