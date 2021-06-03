
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsTemperatura
{
    partial class Temperatura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Temperatura));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.btnSearchFilter = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxDrzave = new System.Windows.Forms.ComboBox();
            this.txtBoxLongituda = new System.Windows.Forms.TextBox();
            this.txtBoxLatituda = new System.Windows.Forms.TextBox();
            this.txtBoxNazivGrada = new System.Windows.Forms.TextBox();
            this.txtBoxIdGrada = new System.Windows.Forms.TextBox();
            this.btnDodajGrad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nGrad_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGrad_Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGrad_Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGrad_Lng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGrad_Drzava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.btnLatLng = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSortGradove = new System.Windows.Forms.ComboBox();
            this.dataGridViewPovijest = new System.Windows.Forms.DataGridView();
            this.TempK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumMjerenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IIdGrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MjerenjeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFarad = new System.Windows.Forms.Button();
            this.btnCelzij = new System.Windows.Forms.Button();
            this.btnKelvin = new System.Windows.Forms.Button();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.comboBoxGradovi = new System.Windows.Forms.ComboBox();
            this.lblGrad = new System.Windows.Forms.Label();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.lblProsjek = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBoxGradovi = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSortGradove2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageStatistika = new MetroFramework.Controls.MetroTabPage();
            this.lblTotalMjerenja = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAvgTempValue = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMinTempValue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMaxTempValue = new System.Windows.Forms.Label();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblProgramiranjeUdotnet = new System.Windows.Forms.Label();
            this.lblImePrezime = new System.Windows.Forms.Label();
            this.lblMadeBy = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_Maximize = new System.Windows.Forms.Button();
            this.metroTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPovijest)).BeginInit();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPageStatistika.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.metroTabPage1);
            this.metroTabControl.Controls.Add(this.metroTabPage3);
            this.metroTabControl.Controls.Add(this.metroTabPage4);
            this.metroTabControl.Controls.Add(this.metroTabPage2);
            this.metroTabControl.Controls.Add(this.metroTabPageStatistika);
            this.metroTabControl.Controls.Add(this.metroTabPage5);
            this.metroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl.Location = new System.Drawing.Point(0, 50);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 5;
            this.metroTabControl.Size = new System.Drawing.Size(798, 418);
            this.metroTabControl.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControl.TabIndex = 1;
            this.metroTabControl.UseCustomBackColor = true;
            this.metroTabControl.UseCustomForeColor = true;
            this.metroTabControl.UseSelectable = true;
            this.metroTabControl.SelectedIndexChanged += new System.EventHandler(this.metroTabControl_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.Black;
            this.metroTabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroTabPage1.BackgroundImage")));
            this.metroTabPage1.Controls.Add(this.btnSearchFilter);
            this.metroTabPage1.Controls.Add(this.textBoxFilter);
            this.metroTabPage1.Controls.Add(this.pictureBox1);
            this.metroTabPage1.Controls.Add(this.comboBoxDrzave);
            this.metroTabPage1.Controls.Add(this.txtBoxLongituda);
            this.metroTabPage1.Controls.Add(this.txtBoxLatituda);
            this.metroTabPage1.Controls.Add(this.txtBoxNazivGrada);
            this.metroTabPage1.Controls.Add(this.txtBoxIdGrada);
            this.metroTabPage1.Controls.Add(this.btnDodajGrad);
            this.metroTabPage1.Controls.Add(this.dataGridView1);
            this.metroTabPage1.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(790, 376);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Gradovi";
            this.metroTabPage1.UseCustomBackColor = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // btnSearchFilter
            // 
            this.btnSearchFilter.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearchFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchFilter.BackgroundImage")));
            this.btnSearchFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchFilter.FlatAppearance.BorderSize = 0;
            this.btnSearchFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchFilter.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchFilter.Location = new System.Drawing.Point(201, 344);
            this.btnSearchFilter.Name = "btnSearchFilter";
            this.btnSearchFilter.Size = new System.Drawing.Size(39, 30);
            this.btnSearchFilter.TabIndex = 11;
            this.btnSearchFilter.UseVisualStyleBackColor = false;
            this.btnSearchFilter.Click += new System.EventHandler(this.btnSearchFilter_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.BackColor = System.Drawing.Color.OliveDrab;
            this.textBoxFilter.Location = new System.Drawing.Point(8, 348);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(187, 20);
            this.textBoxFilter.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFormsTemperatura.Properties.Resources.Sjeva;
            this.pictureBox1.Location = new System.Drawing.Point(685, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 380);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxDrzave
            // 
            this.comboBoxDrzave.BackColor = System.Drawing.Color.Blue;
            this.comboBoxDrzave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrzave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDrzave.ForeColor = System.Drawing.Color.White;
            this.comboBoxDrzave.FormattingEnabled = true;
            this.comboBoxDrzave.Location = new System.Drawing.Point(417, 279);
            this.comboBoxDrzave.Name = "comboBoxDrzave";
            this.comboBoxDrzave.Size = new System.Drawing.Size(269, 21);
            this.comboBoxDrzave.TabIndex = 8;
            // 
            // txtBoxLongituda
            // 
            this.txtBoxLongituda.BackColor = System.Drawing.Color.Blue;
            this.txtBoxLongituda.ForeColor = System.Drawing.Color.White;
            this.txtBoxLongituda.Location = new System.Drawing.Point(312, 279);
            this.txtBoxLongituda.Name = "txtBoxLongituda";
            this.txtBoxLongituda.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLongituda.TabIndex = 7;
            this.txtBoxLongituda.Text = "Longituda";
            this.txtBoxLongituda.Enter += new System.EventHandler(this.txtBoxLongituda_Enter);
            this.txtBoxLongituda.Leave += new System.EventHandler(this.txtBoxLongituda_Leave);
            // 
            // txtBoxLatituda
            // 
            this.txtBoxLatituda.BackColor = System.Drawing.Color.Blue;
            this.txtBoxLatituda.ForeColor = System.Drawing.Color.White;
            this.txtBoxLatituda.Location = new System.Drawing.Point(209, 279);
            this.txtBoxLatituda.Name = "txtBoxLatituda";
            this.txtBoxLatituda.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLatituda.TabIndex = 6;
            this.txtBoxLatituda.Text = "Latituda";
            this.txtBoxLatituda.Enter += new System.EventHandler(this.txtBoxLatituda_Enter);
            this.txtBoxLatituda.Leave += new System.EventHandler(this.txtBoxLatituda_Leave);
            // 
            // txtBoxNazivGrada
            // 
            this.txtBoxNazivGrada.BackColor = System.Drawing.Color.Blue;
            this.txtBoxNazivGrada.ForeColor = System.Drawing.Color.White;
            this.txtBoxNazivGrada.Location = new System.Drawing.Point(105, 279);
            this.txtBoxNazivGrada.Name = "txtBoxNazivGrada";
            this.txtBoxNazivGrada.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNazivGrada.TabIndex = 5;
            this.txtBoxNazivGrada.Text = "Naziv grada";
            this.txtBoxNazivGrada.Enter += new System.EventHandler(this.txtBoxNazivGrada_Enter);
            this.txtBoxNazivGrada.Leave += new System.EventHandler(this.txtBoxNazivGrada_Leave);
            // 
            // txtBoxIdGrada
            // 
            this.txtBoxIdGrada.BackColor = System.Drawing.Color.Blue;
            this.txtBoxIdGrada.ForeColor = System.Drawing.Color.White;
            this.txtBoxIdGrada.Location = new System.Drawing.Point(2, 279);
            this.txtBoxIdGrada.Name = "txtBoxIdGrada";
            this.txtBoxIdGrada.Size = new System.Drawing.Size(100, 20);
            this.txtBoxIdGrada.TabIndex = 4;
            this.txtBoxIdGrada.Text = "Id grada";
            this.txtBoxIdGrada.Enter += new System.EventHandler(this.txtBoxIdGrada_Enter);
            this.txtBoxIdGrada.Leave += new System.EventHandler(this.txtBoxIdGrada_Leave);
            // 
            // btnDodajGrad
            // 
            this.btnDodajGrad.BackColor = System.Drawing.Color.Transparent;
            this.btnDodajGrad.FlatAppearance.BorderSize = 0;
            this.btnDodajGrad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajGrad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodajGrad.ForeColor = System.Drawing.Color.Lime;
            this.btnDodajGrad.Location = new System.Drawing.Point(8, 305);
            this.btnDodajGrad.Name = "btnDodajGrad";
            this.btnDodajGrad.Size = new System.Drawing.Size(112, 21);
            this.btnDodajGrad.TabIndex = 3;
            this.btnDodajGrad.Text = "DODAJ GRAD";
            this.btnDodajGrad.UseVisualStyleBackColor = false;
            this.btnDodajGrad.Click += new System.EventHandler(this.btnDodajGrad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nGrad_Id,
            this.sGrad_Naziv,
            this.sGrad_Lat,
            this.sGrad_Lng,
            this.sGrad_Drzava});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 270);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nGrad_Id
            // 
            this.nGrad_Id.DataPropertyName = "nGrad_Id";
            this.nGrad_Id.HeaderText = "Id grada";
            this.nGrad_Id.Name = "nGrad_Id";
            this.nGrad_Id.ReadOnly = true;
            this.nGrad_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nGrad_Id.Width = 80;
            // 
            // sGrad_Naziv
            // 
            this.sGrad_Naziv.DataPropertyName = "sGrad_Naziv";
            this.sGrad_Naziv.HeaderText = "Naziv grada";
            this.sGrad_Naziv.Name = "sGrad_Naziv";
            this.sGrad_Naziv.ReadOnly = true;
            // 
            // sGrad_Lat
            // 
            this.sGrad_Lat.DataPropertyName = "sGrad_Lat";
            this.sGrad_Lat.HeaderText = "Latituda";
            this.sGrad_Lat.Name = "sGrad_Lat";
            this.sGrad_Lat.ReadOnly = true;
            this.sGrad_Lat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sGrad_Lat.Width = 90;
            // 
            // sGrad_Lng
            // 
            this.sGrad_Lng.DataPropertyName = "sGrad_Lng";
            this.sGrad_Lng.HeaderText = "Longituda";
            this.sGrad_Lng.Name = "sGrad_Lng";
            this.sGrad_Lng.ReadOnly = true;
            this.sGrad_Lng.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sGrad_Lng.Width = 90;
            // 
            // sGrad_Drzava
            // 
            this.sGrad_Drzava.DataPropertyName = "sGrad_Drzava";
            this.sGrad_Drzava.HeaderText = "Drzava";
            this.sGrad_Drzava.Name = "sGrad_Drzava";
            this.sGrad_Drzava.ReadOnly = true;
            this.sGrad_Drzava.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sGrad_Drzava.Width = 235;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.BackColor = System.Drawing.Color.Black;
            this.metroTabPage3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroTabPage3.BackgroundImage")));
            this.metroTabPage3.Controls.Add(this.btnLatLng);
            this.metroTabPage3.Controls.Add(this.label2);
            this.metroTabPage3.Controls.Add(this.comboBoxSortGradove);
            this.metroTabPage3.Controls.Add(this.dataGridViewPovijest);
            this.metroTabPage3.Controls.Add(this.btnFarad);
            this.metroTabPage3.Controls.Add(this.btnCelzij);
            this.metroTabPage3.Controls.Add(this.btnKelvin);
            this.metroTabPage3.Controls.Add(this.lblTemperatura);
            this.metroTabPage3.Controls.Add(this.comboBoxGradovi);
            this.metroTabPage3.Controls.Add(this.lblGrad);
            this.metroTabPage3.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(790, 376);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Mjerenja";
            this.metroTabPage3.UseCustomBackColor = true;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // btnLatLng
            // 
            this.btnLatLng.FlatAppearance.BorderSize = 0;
            this.btnLatLng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLatLng.ForeColor = System.Drawing.Color.Gold;
            this.btnLatLng.Location = new System.Drawing.Point(0, 340);
            this.btnLatLng.Name = "btnLatLng";
            this.btnLatLng.Size = new System.Drawing.Size(116, 36);
            this.btnLatLng.TabIndex = 12;
            this.btnLatLng.Text = "Izmjeri temperaturu po Latitudi i Longitudi";
            this.btnLatLng.UseVisualStyleBackColor = true;
            this.btnLatLng.Click += new System.EventHandler(this.btnLatLng_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(55, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Odaberite državu";
            // 
            // comboBoxSortGradove
            // 
            this.comboBoxSortGradove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortGradove.FormattingEnabled = true;
            this.comboBoxSortGradove.Location = new System.Drawing.Point(13, 55);
            this.comboBoxSortGradove.Name = "comboBoxSortGradove";
            this.comboBoxSortGradove.Size = new System.Drawing.Size(253, 21);
            this.comboBoxSortGradove.TabIndex = 10;
            this.comboBoxSortGradove.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortGradove_SelectedIndexChanged);
            // 
            // dataGridViewPovijest
            // 
            this.dataGridViewPovijest.AllowUserToAddRows = false;
            this.dataGridViewPovijest.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPovijest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewPovijest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPovijest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TempK,
            this.DatumMjerenja,
            this.IIdGrada,
            this.MjerenjeID});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPovijest.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewPovijest.GridColor = System.Drawing.Color.Black;
            this.dataGridViewPovijest.Location = new System.Drawing.Point(536, -1);
            this.dataGridViewPovijest.Name = "dataGridViewPovijest";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPovijest.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewPovijest.RowHeadersVisible = false;
            this.dataGridViewPovijest.Size = new System.Drawing.Size(254, 377);
            this.dataGridViewPovijest.TabIndex = 9;
            this.dataGridViewPovijest.Visible = false;
            // 
            // TempK
            // 
            this.TempK.DataPropertyName = "sMjerenje_Iznos";
            this.TempK.HeaderText = "Temperatura u Kelvinima";
            this.TempK.Name = "TempK";
            this.TempK.ReadOnly = true;
            // 
            // DatumMjerenja
            // 
            this.DatumMjerenja.DataPropertyName = "sMjerenje_Datum";
            this.DatumMjerenja.HeaderText = "DatumMjerenja";
            this.DatumMjerenja.Name = "DatumMjerenja";
            this.DatumMjerenja.ReadOnly = true;
            this.DatumMjerenja.Width = 150;
            // 
            // IIdGrada
            // 
            this.IIdGrada.DataPropertyName = "nMjerenje_IdGrada";
            this.IIdGrada.HeaderText = "ID GRADA";
            this.IIdGrada.Name = "IIdGrada";
            this.IIdGrada.Visible = false;
            // 
            // MjerenjeID
            // 
            this.MjerenjeID.DataPropertyName = "nMjerenje_Id";
            this.MjerenjeID.HeaderText = "MjerenjeID";
            this.MjerenjeID.Name = "MjerenjeID";
            this.MjerenjeID.Visible = false;
            // 
            // btnFarad
            // 
            this.btnFarad.BackColor = System.Drawing.Color.Transparent;
            this.btnFarad.FlatAppearance.BorderSize = 0;
            this.btnFarad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFarad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFarad.ForeColor = System.Drawing.Color.SpringGreen;
            this.btnFarad.Location = new System.Drawing.Point(225, 323);
            this.btnFarad.Name = "btnFarad";
            this.btnFarad.Size = new System.Drawing.Size(50, 50);
            this.btnFarad.TabIndex = 8;
            this.btnFarad.Text = "°F";
            this.btnFarad.UseVisualStyleBackColor = false;
            this.btnFarad.Click += new System.EventHandler(this.btnFarad_Click);
            // 
            // btnCelzij
            // 
            this.btnCelzij.BackColor = System.Drawing.Color.Transparent;
            this.btnCelzij.FlatAppearance.BorderSize = 0;
            this.btnCelzij.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCelzij.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCelzij.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnCelzij.Location = new System.Drawing.Point(271, 323);
            this.btnCelzij.Name = "btnCelzij";
            this.btnCelzij.Size = new System.Drawing.Size(50, 50);
            this.btnCelzij.TabIndex = 7;
            this.btnCelzij.Text = "°C";
            this.btnCelzij.UseVisualStyleBackColor = false;
            this.btnCelzij.Click += new System.EventHandler(this.btnCelzij_Click);
            // 
            // btnKelvin
            // 
            this.btnKelvin.BackColor = System.Drawing.Color.Transparent;
            this.btnKelvin.FlatAppearance.BorderSize = 0;
            this.btnKelvin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKelvin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKelvin.ForeColor = System.Drawing.Color.Lime;
            this.btnKelvin.Location = new System.Drawing.Point(182, 323);
            this.btnKelvin.Name = "btnKelvin";
            this.btnKelvin.Size = new System.Drawing.Size(50, 50);
            this.btnKelvin.TabIndex = 6;
            this.btnKelvin.Text = "°K";
            this.btnKelvin.UseVisualStyleBackColor = false;
            this.btnKelvin.Click += new System.EventHandler(this.btnKelvin_Click);
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.BackColor = System.Drawing.Color.Transparent;
            this.lblTemperatura.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTemperatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTemperatura.Font = new System.Drawing.Font("Arial Rounded MT Bold", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.ForeColor = System.Drawing.Color.Aqua;
            this.lblTemperatura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTemperatura.Location = new System.Drawing.Point(24, 106);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(0, 84);
            this.lblTemperatura.TabIndex = 4;
            this.lblTemperatura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemperatura.UseMnemonic = false;
            // 
            // comboBoxGradovi
            // 
            this.comboBoxGradovi.BackColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxGradovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGradovi.Location = new System.Drawing.Point(296, 55);
            this.comboBoxGradovi.Name = "comboBoxGradovi";
            this.comboBoxGradovi.Size = new System.Drawing.Size(225, 21);
            this.comboBoxGradovi.TabIndex = 3;
            this.comboBoxGradovi.Visible = false;
            this.comboBoxGradovi.SelectedIndexChanged += new System.EventHandler(this.comboBoxGradovi_SelectedIndexChanged);
            // 
            // lblGrad
            // 
            this.lblGrad.AutoSize = true;
            this.lblGrad.BackColor = System.Drawing.Color.Transparent;
            this.lblGrad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGrad.ForeColor = System.Drawing.Color.Yellow;
            this.lblGrad.Location = new System.Drawing.Point(336, 10);
            this.lblGrad.Name = "lblGrad";
            this.lblGrad.Size = new System.Drawing.Size(155, 25);
            this.lblGrad.TabIndex = 2;
            this.lblGrad.Text = "Odaberite grad";
            this.lblGrad.Visible = false;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.BackColor = System.Drawing.Color.Black;
            this.metroTabPage4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroTabPage4.BackgroundImage")));
            this.metroTabPage4.Controls.Add(this.panel2);
            this.metroTabPage4.Controls.Add(this.lblMaxTemp);
            this.metroTabPage4.Controls.Add(this.lblMinTemp);
            this.metroTabPage4.Controls.Add(this.lblProsjek);
            this.metroTabPage4.Controls.Add(this.button2);
            this.metroTabPage4.Controls.Add(this.label9);
            this.metroTabPage4.Controls.Add(this.label8);
            this.metroTabPage4.Controls.Add(this.label7);
            this.metroTabPage4.Controls.Add(this.checkedListBoxGradovi);
            this.metroTabPage4.Controls.Add(this.label6);
            this.metroTabPage4.Controls.Add(this.label5);
            this.metroTabPage4.Controls.Add(this.comboBoxSortGradove2);
            this.metroTabPage4.Controls.Add(this.label4);
            this.metroTabPage4.Controls.Add(this.label3);
            this.metroTabPage4.Controls.Add(this.dateTimePicker2);
            this.metroTabPage4.Controls.Add(this.dateTimePicker1);
            this.metroTabPage4.ForeColor = System.Drawing.Color.White;
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(790, 376);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Grafikon";
            this.metroTabPage4.UseCustomBackColor = true;
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(302, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 376);
            this.panel2.TabIndex = 20;
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.AutoSize = true;
            this.lblMaxTemp.Location = new System.Drawing.Point(168, 240);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Size = new System.Drawing.Size(43, 13);
            this.lblMaxTemp.TabIndex = 19;
            this.lblMaxTemp.Text = "------------";
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.AutoSize = true;
            this.lblMinTemp.Location = new System.Drawing.Point(37, 240);
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Size = new System.Drawing.Size(43, 13);
            this.lblMinTemp.TabIndex = 18;
            this.lblMinTemp.Text = "------------";
            // 
            // lblProsjek
            // 
            this.lblProsjek.AutoSize = true;
            this.lblProsjek.BackColor = System.Drawing.Color.Transparent;
            this.lblProsjek.Location = new System.Drawing.Point(96, 310);
            this.lblProsjek.Name = "lblProsjek";
            this.lblProsjek.Size = new System.Drawing.Size(43, 13);
            this.lblProsjek.TabIndex = 17;
            this.lblProsjek.Text = "------------";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(132, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Prikaži";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(60, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Prosječna temperatura";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(129, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Maksimalna temperatura";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(7, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Minimalna temperatura";
            // 
            // checkedListBoxGradovi
            // 
            this.checkedListBoxGradovi.FormattingEnabled = true;
            this.checkedListBoxGradovi.Location = new System.Drawing.Point(8, 114);
            this.checkedListBoxGradovi.Name = "checkedListBoxGradovi";
            this.checkedListBoxGradovi.Size = new System.Drawing.Size(281, 94);
            this.checkedListBoxGradovi.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Wheat;
            this.label6.Location = new System.Drawing.Point(5, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Odaberite gradove:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Wheat;
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Odaberi državu:";
            // 
            // comboBoxSortGradove2
            // 
            this.comboBoxSortGradove2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortGradove2.FormattingEnabled = true;
            this.comboBoxSortGradove2.Location = new System.Drawing.Point(89, 66);
            this.comboBoxSortGradove2.Name = "comboBoxSortGradove2";
            this.comboBoxSortGradove2.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSortGradove2.TabIndex = 7;
            this.comboBoxSortGradove2.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortGradove2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Wheat;
            this.label4.Location = new System.Drawing.Point(5, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mjerenja do:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Wheat;
            this.label3.Location = new System.Drawing.Point(5, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mjerenja od:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(89, 40);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BackColor = System.Drawing.Color.Black;
            this.metroTabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroTabPage2.BackgroundImage")));
            this.metroTabPage2.ForeColor = System.Drawing.Color.White;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(790, 376);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Karta";
            this.metroTabPage2.UseCustomBackColor = true;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroTabPageStatistika
            // 
            this.metroTabPageStatistika.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroTabPageStatistika.BackgroundImage")));
            this.metroTabPageStatistika.Controls.Add(this.lblTotalMjerenja);
            this.metroTabPageStatistika.Controls.Add(this.label14);
            this.metroTabPageStatistika.Controls.Add(this.lblAvgTempValue);
            this.metroTabPageStatistika.Controls.Add(this.label12);
            this.metroTabPageStatistika.Controls.Add(this.lblMinTempValue);
            this.metroTabPageStatistika.Controls.Add(this.label11);
            this.metroTabPageStatistika.Controls.Add(this.label10);
            this.metroTabPageStatistika.Controls.Add(this.lblMaxTempValue);
            this.metroTabPageStatistika.HorizontalScrollbarBarColor = true;
            this.metroTabPageStatistika.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPageStatistika.HorizontalScrollbarSize = 10;
            this.metroTabPageStatistika.Location = new System.Drawing.Point(4, 38);
            this.metroTabPageStatistika.Name = "metroTabPageStatistika";
            this.metroTabPageStatistika.Size = new System.Drawing.Size(790, 376);
            this.metroTabPageStatistika.TabIndex = 5;
            this.metroTabPageStatistika.Text = "Statistika";
            this.metroTabPageStatistika.VerticalScrollbarBarColor = true;
            this.metroTabPageStatistika.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPageStatistika.VerticalScrollbarSize = 10;
            // 
            // lblTotalMjerenja
            // 
            this.lblTotalMjerenja.AutoSize = true;
            this.lblTotalMjerenja.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalMjerenja.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalMjerenja.Location = new System.Drawing.Point(684, 35);
            this.lblTotalMjerenja.Name = "lblTotalMjerenja";
            this.lblTotalMjerenja.Size = new System.Drawing.Size(0, 13);
            this.lblTotalMjerenja.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(659, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Ukupno mjerenja";
            // 
            // lblAvgTempValue
            // 
            this.lblAvgTempValue.AutoSize = true;
            this.lblAvgTempValue.BackColor = System.Drawing.Color.Transparent;
            this.lblAvgTempValue.ForeColor = System.Drawing.Color.Transparent;
            this.lblAvgTempValue.Location = new System.Drawing.Point(471, 35);
            this.lblAvgTempValue.Name = "lblAvgTempValue";
            this.lblAvgTempValue.Size = new System.Drawing.Size(0, 13);
            this.lblAvgTempValue.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.GreenYellow;
            this.label12.Location = new System.Drawing.Point(380, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Srednja vrijednost svih izmjerenih temperatura";
            // 
            // lblMinTempValue
            // 
            this.lblMinTempValue.AutoSize = true;
            this.lblMinTempValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMinTempValue.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinTempValue.Location = new System.Drawing.Point(246, 35);
            this.lblMinTempValue.Name = "lblMinTempValue";
            this.lblMinTempValue.Size = new System.Drawing.Size(0, 13);
            this.lblMinTempValue.TabIndex = 6;
            this.lblMinTempValue.Click += new System.EventHandler(this.lblMinTempValue_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(191, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Najmanja izmjerena temperatura";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(8, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Najveća izmjerena temperatura";
            // 
            // lblMaxTempValue
            // 
            this.lblMaxTempValue.AutoSize = true;
            this.lblMaxTempValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxTempValue.ForeColor = System.Drawing.Color.Transparent;
            this.lblMaxTempValue.Location = new System.Drawing.Point(64, 35);
            this.lblMaxTempValue.Name = "lblMaxTempValue";
            this.lblMaxTempValue.Size = new System.Drawing.Size(0, 13);
            this.lblMaxTempValue.TabIndex = 2;
            this.lblMaxTempValue.Click += new System.EventHandler(this.lblMaxTempValue_Click);
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.BackColor = System.Drawing.Color.Black;
            this.metroTabPage5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroTabPage5.BackgroundImage")));
            this.metroTabPage5.Controls.Add(this.pictureBox3);
            this.metroTabPage5.Controls.Add(this.lblProgramiranjeUdotnet);
            this.metroTabPage5.Controls.Add(this.lblImePrezime);
            this.metroTabPage5.Controls.Add(this.lblMadeBy);
            this.metroTabPage5.ForeColor = System.Drawing.Color.White;
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(790, 376);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = "O aplikaciji";
            this.metroTabPage5.UseCustomBackColor = true;
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(225, 316);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(317, 60);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lblProgramiranjeUdotnet
            // 
            this.lblProgramiranjeUdotnet.AutoSize = true;
            this.lblProgramiranjeUdotnet.BackColor = System.Drawing.Color.Transparent;
            this.lblProgramiranjeUdotnet.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Italic);
            this.lblProgramiranjeUdotnet.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblProgramiranjeUdotnet.Location = new System.Drawing.Point(238, 91);
            this.lblProgramiranjeUdotnet.Name = "lblProgramiranjeUdotnet";
            this.lblProgramiranjeUdotnet.Size = new System.Drawing.Size(304, 24);
            this.lblProgramiranjeUdotnet.TabIndex = 5;
            this.lblProgramiranjeUdotnet.Text = "Programiranje u .NET okolini";
            // 
            // lblImePrezime
            // 
            this.lblImePrezime.AutoSize = true;
            this.lblImePrezime.BackColor = System.Drawing.Color.Transparent;
            this.lblImePrezime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImePrezime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblImePrezime.Location = new System.Drawing.Point(291, 52);
            this.lblImePrezime.Name = "lblImePrezime";
            this.lblImePrezime.Size = new System.Drawing.Size(197, 24);
            this.lblImePrezime.TabIndex = 3;
            this.lblImePrezime.Text = "Nikola Stjepanović";
            // 
            // lblMadeBy
            // 
            this.lblMadeBy.AutoSize = true;
            this.lblMadeBy.BackColor = System.Drawing.Color.Transparent;
            this.lblMadeBy.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadeBy.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMadeBy.Location = new System.Drawing.Point(339, 11);
            this.lblMadeBy.Name = "lblMadeBy";
            this.lblMadeBy.Size = new System.Drawing.Size(100, 24);
            this.lblMadeBy.TabIndex = 2;
            this.lblMadeBy.Text = "Made by:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Minimize);
            this.panel1.Controls.Add(this.btn_Maximize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 50);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(666, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 50);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.WaitOnLoad = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(156, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "ＴＥＭＰＥＲＡＴＵＲＡ v1.0";
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.BackColor = System.Drawing.Color.Yellow;
            this.btn_Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Minimize.BackgroundImage")));
            this.btn_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimize.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Minimize.Location = new System.Drawing.Point(713, 9);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(35, 35);
            this.btn_Minimize.TabIndex = 3;
            this.btn_Minimize.UseVisualStyleBackColor = false;
            this.btn_Minimize.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Maximize
            // 
            this.btn_Maximize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Maximize.BackgroundImage = global::WinFormsTemperatura.Properties.Resources.close1;
            this.btn_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Maximize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Maximize.FlatAppearance.BorderSize = 0;
            this.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Maximize.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Maximize.ForeColor = System.Drawing.Color.Red;
            this.btn_Maximize.Location = new System.Drawing.Point(754, 9);
            this.btn_Maximize.Name = "btn_Maximize";
            this.btn_Maximize.Size = new System.Drawing.Size(35, 35);
            this.btn_Maximize.TabIndex = 1;
            this.btn_Maximize.UseVisualStyleBackColor = false;
            this.btn_Maximize.Click += new System.EventHandler(this.button1_Click);
            // 
            // Temperatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(798, 468);
            this.Controls.Add(this.metroTabControl);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.GreenYellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Temperatura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperatura";
            this.Load += new System.EventHandler(this.Temperatura_Load);
            this.metroTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPovijest)).EndInit();
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.metroTabPageStatistika.ResumeLayout(false);
            this.metroTabPageStatistika.PerformLayout();
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Maximize;
        private MetroFramework.Controls.MetroTabControl metroTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private System.Windows.Forms.Button btn_Minimize;
        private System.Windows.Forms.Label label1;
        public TextBox txtBoxIdGrada;
        private Button btnDodajGrad;
        public TextBox txtBoxLongituda;
        public TextBox txtBoxLatituda;
        public TextBox txtBoxNazivGrada;
        public MetroFramework.Controls.MetroTabPage metroTabPage1;
        public ComboBox comboBoxDrzave;
        private Label lblGrad;
        private ComboBox comboBoxGradovi;
        private Label lblTemperatura;
        private Button btnFarad;
        private Button btnCelzij;
        private Button btnKelvin;
        private DataGridView dataGridViewPovijest;
        private DataGridViewTextBoxColumn TempK;
        private DataGridViewTextBoxColumn DatumMjerenja;
        private DataGridViewTextBoxColumn IIdGrada;
        private DataGridViewTextBoxColumn MjerenjeID;
        private PictureBox pictureBox2;
        private ComboBox comboBoxSortGradove;
        private Label label2;
        private PictureBox pictureBox3;
        private Label lblProgramiranjeUdotnet;
        private Label lblImePrezime;
        private Label lblMadeBy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public DataGridView dataGridView1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private ComboBox comboBoxSortGradove2;
        private CheckedListBox checkedListBoxGradovi;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button button1;
        private Button button2;
        private Label lblProsjek;
        private Label lblMinTemp;
        private Label lblMaxTemp;
        private Panel panel2;
        private MetroFramework.Controls.MetroTabPage metroTabPageStatistika;
        private Label label10;
        private Label lblMaxTempValue;
        private Label label11;
        private Label lblMinTempValue;
        private Label label12;
        private Label lblAvgTempValue;
        private Label lblTotalMjerenja;
        private Label label14;
        private TextBox textBoxFilter;
        private Button btnSearchFilter;
        private DataGridViewTextBoxColumn nGrad_Id;
        private DataGridViewTextBoxColumn sGrad_Naziv;
        private DataGridViewTextBoxColumn sGrad_Lat;
        private DataGridViewTextBoxColumn sGrad_Lng;
        private DataGridViewTextBoxColumn sGrad_Drzava;
        private PictureBox pictureBox1;
        private Button btnLatLng;
    }
}

