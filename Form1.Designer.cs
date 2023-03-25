namespace password_generator
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
            sb_length = new NumericUpDown();
            lbl_length = new Label();
            lbl_times = new Label();
            sb_times = new NumericUpDown();
            btn_reset = new Button();
            cb_numeric = new CheckBox();
            tb_numeric = new TextBox();
            tb_symbol = new TextBox();
            cb_symbol = new CheckBox();
            tb_lcase = new TextBox();
            cb_lcase = new CheckBox();
            tb_ucase = new TextBox();
            cb_ucase = new CheckBox();
            lbl_passback = new Label();
            btn_generate = new Button();
            btn_copy = new Button();
            lbl_passfore = new Label();
            ((System.ComponentModel.ISupportInitialize)sb_length).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sb_times).BeginInit();
            SuspendLayout();
            // 
            // sb_length
            // 
            sb_length.Location = new Point(99, 12);
            sb_length.Name = "sb_length";
            sb_length.Size = new Size(48, 23);
            sb_length.TabIndex = 0;
            sb_length.ValueChanged += sb_length_ValueChanged;
            // 
            // lbl_length
            // 
            lbl_length.AutoSize = true;
            lbl_length.Location = new Point(12, 14);
            lbl_length.Name = "lbl_length";
            lbl_length.Size = new Size(81, 15);
            lbl_length.TabIndex = 1;
            lbl_length.Text = "パスワードの長さ";
            // 
            // lbl_times
            // 
            lbl_times.AutoSize = true;
            lbl_times.Location = new Point(169, 14);
            lbl_times.Name = "lbl_times";
            lbl_times.Size = new Size(89, 15);
            lbl_times.TabIndex = 3;
            lbl_times.Text = "文字の使用回数";
            // 
            // sb_times
            // 
            sb_times.Location = new Point(264, 12);
            sb_times.Name = "sb_times";
            sb_times.Size = new Size(48, 23);
            sb_times.TabIndex = 2;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(344, 12);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(104, 23);
            btn_reset.TabIndex = 4;
            btn_reset.Text = "初期値にリセット";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // cb_numeric
            // 
            cb_numeric.AutoSize = true;
            cb_numeric.Location = new Point(21, 43);
            cb_numeric.Name = "cb_numeric";
            cb_numeric.Size = new Size(90, 19);
            cb_numeric.TabIndex = 5;
            cb_numeric.Text = "数値を含める";
            cb_numeric.UseVisualStyleBackColor = true;
            // 
            // tb_numeric
            // 
            tb_numeric.Location = new Point(128, 41);
            tb_numeric.Name = "tb_numeric";
            tb_numeric.Size = new Size(320, 23);
            tb_numeric.TabIndex = 6;
            // 
            // tb_symbol
            // 
            tb_symbol.Location = new Point(128, 128);
            tb_symbol.Name = "tb_symbol";
            tb_symbol.Size = new Size(320, 23);
            tb_symbol.TabIndex = 8;
            // 
            // cb_symbol
            // 
            cb_symbol.AutoSize = true;
            cb_symbol.Location = new Point(21, 130);
            cb_symbol.Name = "cb_symbol";
            cb_symbol.Size = new Size(90, 19);
            cb_symbol.TabIndex = 7;
            cb_symbol.Text = "記号を含める";
            cb_symbol.UseVisualStyleBackColor = true;
            // 
            // tb_lcase
            // 
            tb_lcase.Location = new Point(128, 99);
            tb_lcase.Name = "tb_lcase";
            tb_lcase.Size = new Size(320, 23);
            tb_lcase.TabIndex = 10;
            // 
            // cb_lcase
            // 
            cb_lcase.AutoSize = true;
            cb_lcase.Location = new Point(21, 101);
            cb_lcase.Name = "cb_lcase";
            cb_lcase.Size = new Size(102, 19);
            cb_lcase.TabIndex = 9;
            cb_lcase.Text = "小文字を含める";
            cb_lcase.UseVisualStyleBackColor = true;
            // 
            // tb_ucase
            // 
            tb_ucase.Location = new Point(128, 70);
            tb_ucase.Name = "tb_ucase";
            tb_ucase.Size = new Size(320, 23);
            tb_ucase.TabIndex = 12;
            // 
            // cb_ucase
            // 
            cb_ucase.AutoSize = true;
            cb_ucase.Location = new Point(21, 72);
            cb_ucase.Name = "cb_ucase";
            cb_ucase.Size = new Size(102, 19);
            cb_ucase.TabIndex = 11;
            cb_ucase.Text = "大文字を含める";
            cb_ucase.UseVisualStyleBackColor = true;
            // 
            // lbl_passback
            // 
            lbl_passback.BackColor = Color.FromArgb(255, 255, 192);
            lbl_passback.BorderStyle = BorderStyle.FixedSingle;
            lbl_passback.Font = new Font("Consolas", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_passback.ForeColor = Color.FromArgb(64, 64, 0);
            lbl_passback.Location = new Point(21, 163);
            lbl_passback.Name = "lbl_passback";
            lbl_passback.Size = new Size(427, 76);
            lbl_passback.TabIndex = 13;
            lbl_passback.TextAlign = ContentAlignment.MiddleCenter;
            lbl_passback.UseMnemonic = false;
            // 
            // btn_generate
            // 
            btn_generate.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_generate.Location = new Point(21, 246);
            btn_generate.Name = "btn_generate";
            btn_generate.Size = new Size(214, 47);
            btn_generate.TabIndex = 15;
            btn_generate.Text = "パスワード作成！";
            btn_generate.UseVisualStyleBackColor = true;
            btn_generate.Click += btn_generate_Click;
            // 
            // btn_copy
            // 
            btn_copy.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_copy.Location = new Point(241, 246);
            btn_copy.Name = "btn_copy";
            btn_copy.Size = new Size(207, 47);
            btn_copy.TabIndex = 16;
            btn_copy.Text = "コピー！";
            btn_copy.UseVisualStyleBackColor = true;
            btn_copy.Click += btn_copy_Click;
            // 
            // lbl_passfore
            // 
            lbl_passfore.Anchor = AnchorStyles.None;
            lbl_passfore.BackColor = Color.Transparent;
            lbl_passfore.Font = new Font("Consolas", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_passfore.ForeColor = Color.Olive;
            lbl_passfore.Location = new Point(21, 300);
            lbl_passfore.Name = "lbl_passfore";
            lbl_passfore.Size = new Size(427, 76);
            lbl_passfore.TabIndex = 17;
            lbl_passfore.TextAlign = ContentAlignment.MiddleCenter;
            lbl_passfore.UseMnemonic = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 305);
            Controls.Add(lbl_passfore);
            Controls.Add(lbl_passback);
            Controls.Add(btn_copy);
            Controls.Add(btn_generate);
            Controls.Add(tb_ucase);
            Controls.Add(cb_ucase);
            Controls.Add(tb_lcase);
            Controls.Add(cb_lcase);
            Controls.Add(tb_symbol);
            Controls.Add(cb_symbol);
            Controls.Add(tb_numeric);
            Controls.Add(cb_numeric);
            Controls.Add(btn_reset);
            Controls.Add(lbl_times);
            Controls.Add(sb_times);
            Controls.Add(lbl_length);
            Controls.Add(sb_length);
            Name = "Form1";
            Text = "パスワードジェネレータ";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)sb_length).EndInit();
            ((System.ComponentModel.ISupportInitialize)sb_times).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown sb_length;
        private Label lbl_length;
        private Label lbl_times;
        private NumericUpDown sb_times;
        private Button btn_reset;
        private CheckBox cb_numeric;
        private TextBox tb_numeric;
        private TextBox tb_symbol;
        private CheckBox cb_symbol;
        private TextBox tb_lcase;
        private CheckBox cb_lcase;
        private TextBox tb_ucase;
        private CheckBox cb_ucase;
        private Label lbl_passback;
        private Button btn_generate;
        private Button btn_copy;
        private Label lbl_passfore;
    }
}