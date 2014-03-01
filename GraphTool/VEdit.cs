using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Graphs;

namespace GraphTool
{
	public class VEdit : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox tInfo;
		internal System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.CheckBox cbStart;
		private System.Windows.Forms.CheckBox cbFinish;
		private System.ComponentModel.Container components = null;

		public VEdit(PictureBox pictureBox, Vertex vertex, Graph graph)
		{
			InitializeComponent();
            this.pictureBox = pictureBox;
            this.vertex = vertex;
            this.graph = graph;
            this.ShowDialog();
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
		
        private void InitializeComponent()
		{
            this.Label2 = new System.Windows.Forms.Label();
            this.tInfo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.cbStart = new System.Windows.Forms.CheckBox();
            this.cbFinish = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Location = new System.Drawing.Point(152, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 24);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Select vertex type:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tInfo
            // 
            this.tInfo.Location = new System.Drawing.Point(8, 64);
            this.tInfo.MaxLength = 100;
            this.tInfo.Name = "tInfo";
            this.tInfo.Size = new System.Drawing.Size(136, 20);
            this.tInfo.TabIndex = 5;
            this.tInfo.TextChanged += new System.EventHandler(this.tInfo_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(136, 48);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Insert text to be displayed on vertex label. Empty field means index display.";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bOK.Location = new System.Drawing.Point(277, 8);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(80, 75);
            this.bOK.TabIndex = 8;
            this.bOK.Text = "[ OK ]";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // cbStart
            // 
            this.cbStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbStart.Location = new System.Drawing.Point(160, 40);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(104, 16);
            this.cbStart.TabIndex = 9;
            this.cbStart.Text = " Start Vertex";
            this.cbStart.CheckedChanged += new System.EventHandler(this.cbStart_CheckedChanged);
            // 
            // cbFinish
            // 
            this.cbFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFinish.Location = new System.Drawing.Point(160, 60);
            this.cbFinish.Name = "cbFinish";
            this.cbFinish.Size = new System.Drawing.Size(104, 24);
            this.cbFinish.TabIndex = 10;
            this.cbFinish.Text = " Finish Vertex";
            this.cbFinish.CheckedChanged += new System.EventHandler(this.cbFinish_CheckedChanged);
            // 
            // VEdit
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.bOK;
            this.ClientSize = new System.Drawing.Size(362, 88);
            this.Controls.Add(this.cbFinish);
            this.Controls.Add(this.cbStart);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.tInfo);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "VEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*** Vertex Editor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private PictureBox pictureBox;
		private Vertex vertex;
		private Graph graph;

		private void VEdit_Load(object sender, System.EventArgs e)
		{
			tInfo.Text = vertex.name;
			tInfo.SelectAll();
			tInfo.TabIndex = 0;
			bOK.TabIndex = 1;
			cbStart.Enabled = graph.oriented;
			cbFinish.Enabled = graph.oriented;
			cbStart.Checked = vertex.is_start;
			cbFinish.Checked = vertex.is_finish;
		}

		private void bOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tInfo_TextChanged(object sender, System.EventArgs e)
		{
			vertex.name = tInfo.Text;
			pictureBox.Refresh();
		}

		private void cbStart_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbStart.Checked)
				foreach (Vertex v in graph.vertices) v.is_start = false;
			vertex.is_start = cbStart.Checked;
			pictureBox.Refresh();
		}

		private void cbFinish_CheckedChanged(object sender, System.EventArgs e)
		{
			vertex.is_finish = cbFinish.Checked;
			pictureBox.Refresh();
		}
	}
}
