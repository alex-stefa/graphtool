using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Graphs;

namespace GraphTool
{
	public class AEdit : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button bColor;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox tInfo;
		internal System.Windows.Forms.Button bInvert;
		private System.Windows.Forms.ColorDialog colDiag;
		private System.Windows.Forms.Button bOK;
		private System.ComponentModel.Container components = null;

		public AEdit(PictureBox pictureBox, Edge edge, Graph graph)
		{
			InitializeComponent();
            this.pictureBox = pictureBox;
            this.edge = edge;
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
            this.bColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tInfo = new System.Windows.Forms.TextBox();
            this.bInvert = new System.Windows.Forms.Button();
            this.colDiag = new System.Windows.Forms.ColorDialog();
            this.bOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bColor
            // 
            this.bColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bColor.Location = new System.Drawing.Point(160, 48);
            this.bColor.Name = "bColor";
            this.bColor.Size = new System.Drawing.Size(152, 24);
            this.bColor.TabIndex = 11;
            this.bColor.Text = "--= Change arc color =--";
            this.bColor.Click += new System.EventHandler(this.bColor_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 40);
            this.label2.TabIndex = 10;
            this.label2.Text = "Insert text to be displayed on arc label. Empty field means index display.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tInfo
            // 
            this.tInfo.Location = new System.Drawing.Point(8, 56);
            this.tInfo.MaxLength = 100;
            this.tInfo.Name = "tInfo";
            this.tInfo.Size = new System.Drawing.Size(136, 20);
            this.tInfo.TabIndex = 9;
            this.tInfo.TextChanged += new System.EventHandler(this.tInfo_TextChanged);
            // 
            // bInvert
            // 
            this.bInvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bInvert.Location = new System.Drawing.Point(160, 8);
            this.bInvert.Name = "bInvert";
            this.bInvert.Size = new System.Drawing.Size(152, 24);
            this.bInvert.TabIndex = 8;
            this.bInvert.Text = "--= Invert arc orientation =--";
            this.bInvert.Click += new System.EventHandler(this.bInvert_Click);
            // 
            // colDiag
            // 
            this.colDiag.AnyColor = true;
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bOK.Location = new System.Drawing.Point(320, 8);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(72, 64);
            this.bOK.TabIndex = 12;
            this.bOK.Text = "[ OK ]";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // AEdit
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.bOK;
            this.ClientSize = new System.Drawing.Size(394, 80);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tInfo);
            this.Controls.Add(this.bInvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*** Edge Editor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public PictureBox pictureBox;
		public Graph graph;
		public Edge edge;
		
		private void bColor_Click(object sender, System.EventArgs e)
		{
			colDiag.ShowDialog(this);
			edge.color = colDiag.Color;
			pictureBox.Refresh();
		}

		private void AEdit_Load(object sender, System.EventArgs e)
		{
			tInfo.Text = edge.name;
			tInfo.SelectAll();
			tInfo.TabIndex = 0;
			bOK.TabIndex = 1;
			bInvert.Enabled = graph.oriented;
		}

		private void tInfo_TextChanged(object sender, System.EventArgs e)
		{
			edge.name = tInfo.Text;
			pictureBox.Refresh();
		}

		private void bInvert_Click(object sender, System.EventArgs e)
		{
			Vertex aux = edge.src;
			edge.src = edge.dst;
			edge.dst = aux;
			graph.setAllPoints();
            graph.findConnectedComponents();
			pictureBox.Refresh();
		}

		private void bOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
