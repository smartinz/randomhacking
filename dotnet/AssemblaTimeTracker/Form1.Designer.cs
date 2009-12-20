namespace AssemblaTimeTracker
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
			this.spaceComboBox = new System.Windows.Forms.ComboBox();
			this.ticketComboBox = new System.Windows.Forms.ComboBox();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.usernameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.loadButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.timerTextBox = new System.Windows.Forms.TextBox();
			this.remainingTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// spaceComboBox
			// 
			this.spaceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.spaceComboBox.DisplayMember = "Description";
			this.spaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.spaceComboBox.Location = new System.Drawing.Point(96, 64);
			this.spaceComboBox.Name = "spaceComboBox";
			this.spaceComboBox.Size = new System.Drawing.Size(273, 21);
			this.spaceComboBox.TabIndex = 0;
			this.spaceComboBox.ValueMember = "Id";
			this.spaceComboBox.SelectedValueChanged += new System.EventHandler(this.spaceComboBox_SelectedValueChanged);
			// 
			// ticketComboBox
			// 
			this.ticketComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ticketComboBox.DisplayMember = "Description";
			this.ticketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketComboBox.Location = new System.Drawing.Point(96, 91);
			this.ticketComboBox.Name = "ticketComboBox";
			this.ticketComboBox.Size = new System.Drawing.Size(273, 21);
			this.ticketComboBox.TabIndex = 1;
			this.ticketComboBox.ValueMember = "Id";
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "notifyIcon";
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Username";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(52, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Space";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(53, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Ticket";
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.usernameTextBox.Location = new System.Drawing.Point(96, 12);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size(367, 20);
			this.usernameTextBox.TabIndex = 6;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.passwordTextBox.Location = new System.Drawing.Point(96, 38);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(367, 20);
			this.passwordTextBox.TabIndex = 7;
			// 
			// loadButton
			// 
			this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadButton.Location = new System.Drawing.Point(375, 64);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new System.Drawing.Size(88, 48);
			this.loadButton.TabIndex = 8;
			this.loadButton.Text = "Load/Refresh";
			this.loadButton.UseVisualStyleBackColor = true;
			this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.Location = new System.Drawing.Point(12, 170);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(451, 86);
			this.startButton.TabIndex = 9;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// timer
			// 
			this.timer.Interval = 1800000;
			// 
			// timerTextBox
			// 
			this.timerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.timerTextBox.Location = new System.Drawing.Point(96, 118);
			this.timerTextBox.Name = "timerTextBox";
			this.timerTextBox.Size = new System.Drawing.Size(367, 20);
			this.timerTextBox.TabIndex = 10;
			this.timerTextBox.Text = "0.5";
			// 
			// remainingTextBox
			// 
			this.remainingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.remainingTextBox.Location = new System.Drawing.Point(96, 144);
			this.remainingTextBox.Name = "remainingTextBox";
			this.remainingTextBox.Size = new System.Drawing.Size(367, 20);
			this.remainingTextBox.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 121);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Timer (hours)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 147);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Remaining (ms)";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(475, 265);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.remainingTextBox);
			this.Controls.Add(this.timerTextBox);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.loadButton);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ticketComboBox);
			this.Controls.Add(this.spaceComboBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AssemblaTimeTracker";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox spaceComboBox;
		private System.Windows.Forms.ComboBox ticketComboBox;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.TextBox timerTextBox;
		private System.Windows.Forms.TextBox remainingTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;


	}
}

