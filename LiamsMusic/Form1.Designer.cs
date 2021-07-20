
namespace LiamsMusic
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnSettings = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.btnSkip = new System.Windows.Forms.Button();
			this.btnPlay = new System.Windows.Forms.Button();
			this.slider = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(433, 8);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(26, 23);
			this.btnSettings.TabIndex = 3;
			this.btnSettings.Text = ".";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView1.Location = new System.Drawing.Point(12, 37);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(776, 243);
			this.dataGridView1.TabIndex = 4;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// tbSearch
			// 
			this.tbSearch.Location = new System.Drawing.Point(65, 8);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(352, 20);
			this.tbSearch.TabIndex = 5;
			this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Search";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "LiamMusic";
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// btnSkip
			// 
			this.btnSkip.BackColor = System.Drawing.Color.Aqua;
			this.btnSkip.Image = global::LiamsMusic.Properties.Resources.SkipIcon;
			this.btnSkip.Location = new System.Drawing.Point(124, 283);
			this.btnSkip.Margin = new System.Windows.Forms.Padding(0);
			this.btnSkip.Name = "btnSkip";
			this.btnSkip.Size = new System.Drawing.Size(100, 100);
			this.btnSkip.TabIndex = 0;
			this.btnSkip.UseVisualStyleBackColor = false;
			this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
			// 
			// btnPlay
			// 
			this.btnPlay.BackColor = System.Drawing.Color.Aqua;
			this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnPlay.Image = global::LiamsMusic.Properties.Resources.play1;
			this.btnPlay.Location = new System.Drawing.Point(12, 283);
			this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(100, 100);
			this.btnPlay.TabIndex = 0;
			this.btnPlay.UseVisualStyleBackColor = false;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// slider
			// 
			this.slider.Location = new System.Drawing.Point(388, 316);
			this.slider.Maximum = 100;
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(389, 45);
			this.slider.TabIndex = 8;
			this.slider.ValueChanged += new System.EventHandler(this.slider_ValueChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::LiamsMusic.Properties.Resources.XDJ4aT;
			this.ClientSize = new System.Drawing.Size(800, 393);
			this.Controls.Add(this.slider);
			this.Controls.Add(this.btnSkip);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnPlay);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSkip;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TrackBar slider;
	}
}

