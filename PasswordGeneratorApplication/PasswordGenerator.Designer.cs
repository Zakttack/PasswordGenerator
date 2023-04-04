namespace PasswordGeneratorApplication
{
    partial class PasswordGenerator
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
            this.label2 = new System.Windows.Forms.Label();
            this.minInputBox = new System.Windows.Forms.TextBox();
            this.maxInputBox = new System.Windows.Forms.TextBox();
            this.containsCapitalInputBox = new System.Windows.Forms.CheckBox();
            this.containsDigitsInputBox = new System.Windows.Forms.CheckBox();
            this.containsLowercaseLettersInputBox = new System.Windows.Forms.CheckBox();
            this.containsSpecialCharactersInputBox = new System.Windows.Forms.CheckBox();
            this.generatePasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum Password Length:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum Password Length:";
            // 
            // minInputBox
            // 
            this.minInputBox.Location = new System.Drawing.Point(276, 38);
            this.minInputBox.Name = "minInputBox";
            this.minInputBox.Size = new System.Drawing.Size(150, 31);
            this.minInputBox.TabIndex = 2;
            // 
            // maxInputBox
            // 
            this.maxInputBox.Location = new System.Drawing.Point(276, 90);
            this.maxInputBox.Name = "maxInputBox";
            this.maxInputBox.Size = new System.Drawing.Size(150, 31);
            this.maxInputBox.TabIndex = 3;
            // 
            // containsCapitalInputBox
            // 
            this.containsCapitalInputBox.AutoSize = true;
            this.containsCapitalInputBox.Location = new System.Drawing.Point(54, 160);
            this.containsCapitalInputBox.Name = "containsCapitalInputBox";
            this.containsCapitalInputBox.Size = new System.Drawing.Size(211, 29);
            this.containsCapitalInputBox.TabIndex = 4;
            this.containsCapitalInputBox.Text = "Include Capital Letters";
            this.containsCapitalInputBox.UseVisualStyleBackColor = true;
            // 
            // containsDigitsInputBox
            // 
            this.containsDigitsInputBox.AutoSize = true;
            this.containsDigitsInputBox.Location = new System.Drawing.Point(54, 212);
            this.containsDigitsInputBox.Name = "containsDigitsInputBox";
            this.containsDigitsInputBox.Size = new System.Drawing.Size(146, 29);
            this.containsDigitsInputBox.TabIndex = 5;
            this.containsDigitsInputBox.Text = "Include Digits";
            this.containsDigitsInputBox.UseVisualStyleBackColor = true;
            // 
            // containsLowercaseLettersInputBox
            // 
            this.containsLowercaseLettersInputBox.AutoSize = true;
            this.containsLowercaseLettersInputBox.Location = new System.Drawing.Point(54, 260);
            this.containsLowercaseLettersInputBox.Name = "containsLowercaseLettersInputBox";
            this.containsLowercaseLettersInputBox.Size = new System.Drawing.Size(238, 29);
            this.containsLowercaseLettersInputBox.TabIndex = 6;
            this.containsLowercaseLettersInputBox.Text = "Include Lowercase Letters";
            this.containsLowercaseLettersInputBox.UseVisualStyleBackColor = true;
            // 
            // containsSpecialCharactersInputBox
            // 
            this.containsSpecialCharactersInputBox.AutoSize = true;
            this.containsSpecialCharactersInputBox.Location = new System.Drawing.Point(54, 313);
            this.containsSpecialCharactersInputBox.Name = "containsSpecialCharactersInputBox";
            this.containsSpecialCharactersInputBox.Size = new System.Drawing.Size(242, 29);
            this.containsSpecialCharactersInputBox.TabIndex = 7;
            this.containsSpecialCharactersInputBox.Text = "Include Special Characters";
            this.containsSpecialCharactersInputBox.UseVisualStyleBackColor = true;
            // 
            // generatePasswordButton
            // 
            this.generatePasswordButton.Location = new System.Drawing.Point(128, 374);
            this.generatePasswordButton.Name = "generatePasswordButton";
            this.generatePasswordButton.Size = new System.Drawing.Size(112, 34);
            this.generatePasswordButton.TabIndex = 8;
            this.generatePasswordButton.Text = "Generate";
            this.generatePasswordButton.UseVisualStyleBackColor = true;
            this.generatePasswordButton.Click += new System.EventHandler(this.GeneratePassword);
            // 
            // PasswordGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.Controls.Add(this.generatePasswordButton);
            this.Controls.Add(this.containsSpecialCharactersInputBox);
            this.Controls.Add(this.containsLowercaseLettersInputBox);
            this.Controls.Add(this.containsDigitsInputBox);
            this.Controls.Add(this.containsCapitalInputBox);
            this.Controls.Add(this.maxInputBox);
            this.Controls.Add(this.minInputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PasswordGenerator";
            this.Text = "Password Generator";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += new EventHandler(LoadGenerator);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox minInputBox;
        private TextBox maxInputBox;
        private CheckBox containsCapitalInputBox;
        private CheckBox containsDigitsInputBox;
        private CheckBox containsLowercaseLettersInputBox;
        private CheckBox containsSpecialCharactersInputBox;
        private Button generatePasswordButton;
    }
}