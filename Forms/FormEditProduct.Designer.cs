
namespace Shop
{
    partial class FormEditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditProduct));
            this.button2 = new System.Windows.Forms.Button();
            this.EditProduct = new System.Windows.Forms.Button();
            this.KindG = new System.Windows.Forms.GroupBox();
            this.Chicken = new System.Windows.Forms.RadioButton();
            this.Mutton = new System.Windows.Forms.RadioButton();
            this.Pork = new System.Windows.Forms.RadioButton();
            this.Veal = new System.Windows.Forms.RadioButton();
            this.CategoryG = new System.Windows.Forms.GroupBox();
            this.First = new System.Windows.Forms.RadioButton();
            this.HighSort = new System.Windows.Forms.RadioButton();
            this.SecondSort = new System.Windows.Forms.RadioButton();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.Expiration = new System.Windows.Forms.NumericUpDown();
            this.Weight = new System.Windows.Forms.NumericUpDown();
            this.Price = new System.Windows.Forms.NumericUpDown();
            this.ProductName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProductR = new System.Windows.Forms.RadioButton();
            this.MeatR = new System.Windows.Forms.RadioButton();
            this.DairyR = new System.Windows.Forms.RadioButton();
            this.KindG.SuspendLayout();
            this.CategoryG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expiration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Weight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(323, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 35);
            this.button2.TabIndex = 32;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditProduct
            // 
            this.EditProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditProduct.Location = new System.Drawing.Point(137, 208);
            this.EditProduct.Name = "EditProduct";
            this.EditProduct.Size = new System.Drawing.Size(154, 35);
            this.EditProduct.TabIndex = 31;
            this.EditProduct.Text = "Edit Product";
            this.EditProduct.UseVisualStyleBackColor = true;
            this.EditProduct.Click += new System.EventHandler(this.EditProduct_Click);
            // 
            // KindG
            // 
            this.KindG.Controls.Add(this.Chicken);
            this.KindG.Controls.Add(this.Mutton);
            this.KindG.Controls.Add(this.Pork);
            this.KindG.Controls.Add(this.Veal);
            this.KindG.Enabled = false;
            this.KindG.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KindG.Location = new System.Drawing.Point(131, 70);
            this.KindG.Name = "KindG";
            this.KindG.Size = new System.Drawing.Size(117, 132);
            this.KindG.TabIndex = 30;
            this.KindG.TabStop = false;
            this.KindG.Text = "Kind";
            // 
            // Chicken
            // 
            this.Chicken.AutoSize = true;
            this.Chicken.Location = new System.Drawing.Point(6, 104);
            this.Chicken.Name = "Chicken";
            this.Chicken.Size = new System.Drawing.Size(97, 28);
            this.Chicken.TabIndex = 3;
            this.Chicken.TabStop = true;
            this.Chicken.Text = "Chicken";
            this.Chicken.UseVisualStyleBackColor = true;
            // 
            // Mutton
            // 
            this.Mutton.AutoSize = true;
            this.Mutton.Checked = true;
            this.Mutton.Location = new System.Drawing.Point(6, 24);
            this.Mutton.Name = "Mutton";
            this.Mutton.Size = new System.Drawing.Size(85, 28);
            this.Mutton.TabIndex = 0;
            this.Mutton.TabStop = true;
            this.Mutton.Text = "Mutton";
            this.Mutton.UseVisualStyleBackColor = true;
            // 
            // Pork
            // 
            this.Pork.AutoSize = true;
            this.Pork.Location = new System.Drawing.Point(6, 76);
            this.Pork.Name = "Pork";
            this.Pork.Size = new System.Drawing.Size(66, 28);
            this.Pork.TabIndex = 2;
            this.Pork.TabStop = true;
            this.Pork.Text = "Pork";
            this.Pork.UseVisualStyleBackColor = true;
            // 
            // Veal
            // 
            this.Veal.AutoSize = true;
            this.Veal.Location = new System.Drawing.Point(6, 51);
            this.Veal.Name = "Veal";
            this.Veal.Size = new System.Drawing.Size(66, 28);
            this.Veal.TabIndex = 1;
            this.Veal.TabStop = true;
            this.Veal.Text = "Veal";
            this.Veal.UseVisualStyleBackColor = true;
            // 
            // CategoryG
            // 
            this.CategoryG.Controls.Add(this.First);
            this.CategoryG.Controls.Add(this.HighSort);
            this.CategoryG.Controls.Add(this.SecondSort);
            this.CategoryG.Enabled = false;
            this.CategoryG.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryG.Location = new System.Drawing.Point(8, 70);
            this.CategoryG.Name = "CategoryG";
            this.CategoryG.Size = new System.Drawing.Size(117, 116);
            this.CategoryG.TabIndex = 29;
            this.CategoryG.TabStop = false;
            this.CategoryG.Text = "Category";
            // 
            // First
            // 
            this.First.AutoSize = true;
            this.First.Checked = true;
            this.First.Location = new System.Drawing.Point(6, 24);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(63, 28);
            this.First.TabIndex = 0;
            this.First.TabStop = true;
            this.First.Text = "First";
            this.First.UseVisualStyleBackColor = true;
            // 
            // HighSort
            // 
            this.HighSort.AutoSize = true;
            this.HighSort.Location = new System.Drawing.Point(6, 76);
            this.HighSort.Name = "HighSort";
            this.HighSort.Size = new System.Drawing.Size(68, 28);
            this.HighSort.TabIndex = 2;
            this.HighSort.TabStop = true;
            this.HighSort.Text = "High";
            this.HighSort.UseVisualStyleBackColor = true;
            // 
            // SecondSort
            // 
            this.SecondSort.AutoSize = true;
            this.SecondSort.Location = new System.Drawing.Point(6, 51);
            this.SecondSort.Name = "SecondSort";
            this.SecondSort.Size = new System.Drawing.Size(94, 28);
            this.SecondSort.TabIndex = 1;
            this.SecondSort.Text = "Second";
            this.SecondSort.UseVisualStyleBackColor = true;
            // 
            // Date
            // 
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date.Location = new System.Drawing.Point(437, 174);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(130, 29);
            this.Date.TabIndex = 28;
            // 
            // Expiration
            // 
            this.Expiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Expiration.Location = new System.Drawing.Point(563, 137);
            this.Expiration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Expiration.Name = "Expiration";
            this.Expiration.Size = new System.Drawing.Size(54, 29);
            this.Expiration.TabIndex = 27;
            // 
            // Weight
            // 
            this.Weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Weight.Location = new System.Drawing.Point(333, 137);
            this.Weight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(90, 29);
            this.Weight.TabIndex = 26;
            // 
            // Price
            // 
            this.Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Price.Location = new System.Drawing.Point(497, 93);
            this.Price.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(120, 29);
            this.Price.TabIndex = 25;
            // 
            // ProductName
            // 
            this.ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductName.Location = new System.Drawing.Point(323, 95);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(100, 29);
            this.ProductName.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(249, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Date of manufacture:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(427, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Expiration date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(253, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Weight:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(433, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(251, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProductR);
            this.groupBox1.Controls.Add(this.MeatR);
            this.groupBox1.Controls.Add(this.DairyR);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(50, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 55);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // ProductR
            // 
            this.ProductR.AutoSize = true;
            this.ProductR.Checked = true;
            this.ProductR.Location = new System.Drawing.Point(70, 19);
            this.ProductR.Name = "ProductR";
            this.ProductR.Size = new System.Drawing.Size(93, 28);
            this.ProductR.TabIndex = 0;
            this.ProductR.TabStop = true;
            this.ProductR.Text = "Product";
            this.ProductR.UseVisualStyleBackColor = true;
            // 
            // MeatR
            // 
            this.MeatR.AutoSize = true;
            this.MeatR.Location = new System.Drawing.Point(387, 19);
            this.MeatR.Name = "MeatR";
            this.MeatR.Size = new System.Drawing.Size(69, 28);
            this.MeatR.TabIndex = 2;
            this.MeatR.Text = "Meat";
            this.MeatR.UseVisualStyleBackColor = true;
            this.MeatR.CheckedChanged += new System.EventHandler(this.MeatR_CheckedChanged);
            // 
            // DairyR
            // 
            this.DairyR.AutoSize = true;
            this.DairyR.Location = new System.Drawing.Point(210, 19);
            this.DairyR.Name = "DairyR";
            this.DairyR.Size = new System.Drawing.Size(135, 28);
            this.DairyR.TabIndex = 1;
            this.DairyR.Text = "DairyProduct";
            this.DairyR.UseVisualStyleBackColor = true;
            // 
            // FormEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 260);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EditProduct);
            this.Controls.Add(this.KindG);
            this.Controls.Add(this.CategoryG);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Expiration);
            this.Controls.Add(this.Weight);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditProduct";
            this.KindG.ResumeLayout(false);
            this.KindG.PerformLayout();
            this.CategoryG.ResumeLayout(false);
            this.CategoryG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expiration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Weight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button EditProduct;
        private System.Windows.Forms.GroupBox KindG;
        private System.Windows.Forms.RadioButton Chicken;
        private System.Windows.Forms.RadioButton Mutton;
        private System.Windows.Forms.RadioButton Pork;
        private System.Windows.Forms.RadioButton Veal;
        private System.Windows.Forms.GroupBox CategoryG;
        private System.Windows.Forms.RadioButton First;
        private System.Windows.Forms.RadioButton HighSort;
        private System.Windows.Forms.RadioButton SecondSort;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.NumericUpDown Expiration;
        private System.Windows.Forms.NumericUpDown Weight;
        private System.Windows.Forms.NumericUpDown Price;
        private System.Windows.Forms.TextBox ProductName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ProductR;
        private System.Windows.Forms.RadioButton MeatR;
        private System.Windows.Forms.RadioButton DairyR;
    }
}