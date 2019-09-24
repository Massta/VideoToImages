namespace VideoToImages
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.LabelIsMp4 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelResolution = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelDuration = new System.Windows.Forms.Label();
            this.TextBoxStart = new System.Windows.Forms.TextBox();
            this.TextBoxEnd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxStep = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelImageAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "File...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose file or enter path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Is .mp4 Video";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(566, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "T:\\Users\\Julius\\Videos\\Counter-strike  Global Offensive\\de_cache.mp4";
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate images";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // LabelIsMp4
            // 
            this.LabelIsMp4.AutoSize = true;
            this.LabelIsMp4.Location = new System.Drawing.Point(90, 34);
            this.LabelIsMp4.Name = "LabelIsMp4";
            this.LabelIsMp4.Size = new System.Drawing.Size(10, 13);
            this.LabelIsMp4.TabIndex = 5;
            this.LabelIsMp4.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resolution";
            // 
            // LabelResolution
            // 
            this.LabelResolution.AutoSize = true;
            this.LabelResolution.Location = new System.Drawing.Point(219, 34);
            this.LabelResolution.Name = "LabelResolution";
            this.LabelResolution.Size = new System.Drawing.Size(10, 13);
            this.LabelResolution.TabIndex = 7;
            this.LabelResolution.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output path";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(141, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Folder...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(222, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(566, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Start at [s]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Duration";
            // 
            // LabelDuration
            // 
            this.LabelDuration.AutoSize = true;
            this.LabelDuration.Location = new System.Drawing.Point(414, 34);
            this.LabelDuration.Name = "LabelDuration";
            this.LabelDuration.Size = new System.Drawing.Size(10, 13);
            this.LabelDuration.TabIndex = 13;
            this.LabelDuration.Text = "-";
            // 
            // TextBoxStart
            // 
            this.TextBoxStart.Location = new System.Drawing.Point(141, 79);
            this.TextBoxStart.Name = "TextBoxStart";
            this.TextBoxStart.Size = new System.Drawing.Size(75, 20);
            this.TextBoxStart.TabIndex = 14;
            this.TextBoxStart.Text = "0";
            this.TextBoxStart.TextChanged += new System.EventHandler(this.TextBoxStart_TextChanged);
            // 
            // TextBoxEnd
            // 
            this.TextBoxEnd.Location = new System.Drawing.Point(280, 79);
            this.TextBoxEnd.Name = "TextBoxEnd";
            this.TextBoxEnd.Size = new System.Drawing.Size(75, 20);
            this.TextBoxEnd.TabIndex = 16;
            this.TextBoxEnd.TextChanged += new System.EventHandler(this.TextBoxEnd_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "End at [s]";
            // 
            // TextBoxStep
            // 
            this.TextBoxStep.Location = new System.Drawing.Point(428, 79);
            this.TextBoxStep.Name = "TextBoxStep";
            this.TextBoxStep.Size = new System.Drawing.Size(75, 20);
            this.TextBoxStep.TabIndex = 18;
            this.TextBoxStep.Text = "1";
            this.TextBoxStep.TextChanged += new System.EventHandler(this.TextBoxStep_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(361, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Stepsize [s]";
            // 
            // LabelImageAmount
            // 
            this.LabelImageAmount.AutoSize = true;
            this.LabelImageAmount.Location = new System.Drawing.Point(141, 205);
            this.LabelImageAmount.Name = "LabelImageAmount";
            this.LabelImageAmount.Size = new System.Drawing.Size(197, 13);
            this.LabelImageAmount.TabIndex = 20;
            this.LabelImageAmount.Text = "The chosen setup will generate - images";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 233);
            this.Controls.Add(this.LabelImageAmount);
            this.Controls.Add(this.TextBoxStep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TextBoxEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TextBoxStart);
            this.Controls.Add(this.LabelDuration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelResolution);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelIsMp4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Video To Images";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label LabelIsMp4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelDuration;
        private System.Windows.Forms.TextBox TextBoxStart;
        private System.Windows.Forms.TextBox TextBoxEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBoxStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LabelImageAmount;
    }
}

