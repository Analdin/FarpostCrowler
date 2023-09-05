namespace FarpostCrowler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxLimit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timeFrom = new System.Windows.Forms.TextBox();
            this.timeTo = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timeToSetFrom = new System.Windows.Forms.TextBox();
            this.timeToSetTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rubrikaBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Контроль ставок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Лимит";
            // 
            // boxLimit
            // 
            this.boxLimit.Location = new System.Drawing.Point(73, 46);
            this.boxLimit.Name = "boxLimit";
            this.boxLimit.PlaceholderText = "1000";
            this.boxLimit.Size = new System.Drawing.Size(100, 29);
            this.boxLimit.TabIndex = 5;
            this.boxLimit.TextChanged += new System.EventHandler(this.boxLimit_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(15, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Время работы программы";
            // 
            // timeFrom
            // 
            this.timeFrom.Location = new System.Drawing.Point(15, 110);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.PlaceholderText = "11:05:00";
            this.timeFrom.Size = new System.Drawing.Size(100, 29);
            this.timeFrom.TabIndex = 7;
            this.timeFrom.TextChanged += new System.EventHandler(this.timeFrom_TextChanged);
            // 
            // timeTo
            // 
            this.timeTo.Location = new System.Drawing.Point(120, 110);
            this.timeTo.Name = "timeTo";
            this.timeTo.PlaceholderText = "19:05:00";
            this.timeTo.Size = new System.Drawing.Size(100, 29);
            this.timeTo.TabIndex = 8;
            this.timeTo.TextChanged += new System.EventHandler(this.timeTo_TextChanged);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(110, 438);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(89, 44);
            this.startBtn.TabIndex = 9;
            this.startBtn.Text = "Старт";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(205, 438);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(89, 44);
            this.stopBtn.TabIndex = 10;
            this.stopBtn.Text = "Стоп";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(15, 341);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Данные для входа";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(12, 368);
            this.loginBox.Name = "loginBox";
            this.loginBox.PlaceholderText = "Login";
            this.loginBox.Size = new System.Drawing.Size(208, 29);
            this.loginBox.TabIndex = 12;
            this.loginBox.TextChanged += new System.EventHandler(this.loginBox_TextChanged);
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(12, 403);
            this.passBox.Name = "passBox";
            this.passBox.PlaceholderText = "Password";
            this.passBox.Size = new System.Drawing.Size(208, 29);
            this.passBox.TabIndex = 13;
            this.passBox.TextChanged += new System.EventHandler(this.passBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 282);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Интервал применения ставки";
            // 
            // timeToSetFrom
            // 
            this.timeToSetFrom.Location = new System.Drawing.Point(15, 306);
            this.timeToSetFrom.Name = "timeToSetFrom";
            this.timeToSetFrom.PlaceholderText = "От (в мсек)";
            this.timeToSetFrom.Size = new System.Drawing.Size(100, 29);
            this.timeToSetFrom.TabIndex = 15;
            this.timeToSetFrom.TextChanged += new System.EventHandler(this.timeToSetFrom_TextChanged);
            // 
            // timeToSetTo
            // 
            this.timeToSetTo.Location = new System.Drawing.Point(120, 306);
            this.timeToSetTo.Name = "timeToSetTo";
            this.timeToSetTo.PlaceholderText = "До (в мсек)";
            this.timeToSetTo.Size = new System.Drawing.Size(100, 29);
            this.timeToSetTo.TabIndex = 16;
            this.timeToSetTo.TextChanged += new System.EventHandler(this.timeToSetTo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(15, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Рубрика для работы";
            // 
            // rubrikaBox
            // 
            this.rubrikaBox.Location = new System.Drawing.Point(15, 173);
            this.rubrikaBox.Name = "rubrikaBox";
            this.rubrikaBox.PlaceholderText = "Ноутбуки";
            this.rubrikaBox.Size = new System.Drawing.Size(208, 29);
            this.rubrikaBox.TabIndex = 18;
            this.rubrikaBox.TextChanged += new System.EventHandler(this.rubrikaBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(15, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "id объявления";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(15, 245);
            this.idBox.Name = "idBox";
            this.idBox.PlaceholderText = "24763915";
            this.idBox.Size = new System.Drawing.Size(208, 29);
            this.idBox.TabIndex = 20;
            this.idBox.TextChanged += new System.EventHandler(this.idBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 494);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rubrikaBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeToSetTo);
            this.Controls.Add(this.timeToSetFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.timeTo);
            this.Controls.Add(this.timeFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox boxLimit;
        private Label label4;
        private TextBox timeFrom;
        private TextBox timeTo;
        private Button startBtn;
        private Button stopBtn;
        private Label label5;
        private TextBox loginBox;
        private TextBox passBox;
        private Label label2;
        private TextBox timeToSetFrom;
        private TextBox timeToSetTo;
        private Label label6;
        private TextBox rubrikaBox;
        private Label label7;
        private TextBox idBox;
    }
}