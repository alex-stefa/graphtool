using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Graphs;

namespace GraphTool
{
	public class Input : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.TextBox textBox;
		internal System.Windows.Forms.ComboBox comboBox1;
		internal System.Windows.Forms.ComboBox comboBox2;
		private System.ComponentModel.Container components = null;

		public Input(Graph graph, String message, int loadType)
		{
			InitializeComponent();
            src = dst = 0;
            input = "";
            this.graph = graph;
            this.message = message;
            this.loadType = loadType;
		}

        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Input));
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bOK.Location = new System.Drawing.Point(216, 64);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(88, 18);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "--= OK =--";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bCancel.Location = new System.Drawing.Point(216, 88);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(88, 18);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "--= Cancel =--";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label
            // 
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.Location = new System.Drawing.Point(48, 8);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(256, 48);
            this.label.TabIndex = 2;
            this.label.Text = "tegztu\'";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Location = new System.Drawing.Point(8, 64);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(200, 20);
            this.textBox.TabIndex = 0;
            this.textBox.WordWrap = false;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(16, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Location = new System.Drawing.Point(112, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(88, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Input
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(314, 112);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Input";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*** Input Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Input_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public const int TYPE_TEXT = 1;
        public const int TYPE_VERTICES = 2;
        public const int TYPE_COMBO = 3;
        public const int TYPE_SOURCE = 4;

        private Graph graph;
		private String message;
        private int loadType;
		
        public int src, dst;
        public String input;
		
		private void Input_Load(object sender, System.EventArgs e)
		{
			label.Text = message;
			textBox.Text = "";
			comboBox1.Items.Clear();
			comboBox2.Items.Clear();
			comboBox1.Items.Add("Start");
			comboBox2.Items.Add("Finish");
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			
			if (loadType == TYPE_TEXT)
			{
				comboBox1.Enabled = false;
				comboBox2.Enabled = false;
				textBox.Enabled = true;
			}

			if (loadType == TYPE_VERTICES || loadType == TYPE_COMBO || loadType == TYPE_SOURCE)
			{
				comboBox1.Enabled = true;
				comboBox2.Enabled = !(loadType == TYPE_SOURCE);
                textBox.Enabled = loadType == TYPE_COMBO;
				
                if (graph.vertices.Count == 0) 
				{
					MessageBox.Show(" There are no vertices in current graph.","*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					this.DialogResult = DialogResult.Cancel;
					this.Close();
				}

				foreach (Vertex v in graph.vertices)
				{
					comboBox1.Items.Add("[" + (v.index + 1) + "] " + v.name);
					comboBox2.Items.Add("[" + (v.index + 1) + "] " + v.name);
				}
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dst = comboBox2.SelectedIndex - 1;
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			src = comboBox1.SelectedIndex - 1;
		}

		private void bOK_Click(object sender, System.EventArgs e)
		{
			if (((loadType == TYPE_COMBO || loadType == TYPE_VERTICES) && (comboBox1.SelectedIndex == 0 || comboBox2.SelectedIndex == 0))
                || (loadType == TYPE_SOURCE && comboBox1.SelectedIndex == 0))
			{
				MessageBox.Show(" Please specify the required vertices.","*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            input = textBox.Text;
        }
	}
}
