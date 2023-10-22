
namespace Frogger
{
	partial class Igrica
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStart = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.lblRezultat = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(807, 36);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(65, 43);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(731, 96);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(141, 13);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text = "Ukupan broj preživelih žaba:";
			// 
			// lblRezultat
			// 
			this.lblRezultat.AutoSize = true;
			this.lblRezultat.Location = new System.Drawing.Point(786, 127);
			this.lblRezultat.Name = "lblRezultat";
			this.lblRezultat.Size = new System.Drawing.Size(21, 13);
			this.lblRezultat.TabIndex = 2;
			this.lblRezultat.Text = "rez";
			// 
			// Igrica
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lavender;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.lblRezultat);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.btnStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Igrica";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Frogger";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Igrica_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Label lblRezultat;
	}
}

