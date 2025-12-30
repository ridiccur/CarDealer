namespace CarDealer
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
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            cbFilterField = new ComboBox();
            cbFilterOperator = new ComboBox();
            txtFilterValue = new TextBox();
            btnAddFilter = new Button();
            lstFilters = new ListBox();
            btnApplyFilters = new Button();
            btnClearFilters = new Button();
            txtSearch = new TextBox();
            cbSearchField = new ComboBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 30);
            dataGridView1.Margin = new Padding(6, 7, 6, 7);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1767, 738);
            dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 819);
            btnAdd.Margin = new Padding(6, 7, 6, 7);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(162, 57);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(27, 883);
            btnDelete.Margin = new Padding(6, 7, 6, 7);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(162, 57);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cbFilterField
            // 
            cbFilterField.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterField.FormattingEnabled = true;
            cbFilterField.Location = new Point(847, 784);
            cbFilterField.Margin = new Padding(6, 7, 6, 7);
            cbFilterField.Name = "cbFilterField";
            cbFilterField.Size = new Size(204, 40);
            cbFilterField.TabIndex = 3;
            // 
            // cbFilterOperator
            // 
            cbFilterOperator.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterOperator.FormattingEnabled = true;
            cbFilterOperator.Location = new Point(1069, 784);
            cbFilterOperator.Margin = new Padding(6, 7, 6, 7);
            cbFilterOperator.Name = "cbFilterOperator";
            cbFilterOperator.Size = new Size(226, 40);
            cbFilterOperator.TabIndex = 4;
            cbFilterOperator.SelectedIndexChanged += cbFilterOperator_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(1307, 784);
            txtFilterValue.Margin = new Padding(6, 7, 6, 7);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(230, 39);
            txtFilterValue.TabIndex = 5;
            // 
            // btnAddFilter
            // 
            btnAddFilter.Location = new Point(1549, 779);
            btnAddFilter.Margin = new Padding(6, 7, 6, 7);
            btnAddFilter.Name = "btnAddFilter";
            btnAddFilter.Size = new Size(217, 57);
            btnAddFilter.TabIndex = 6;
            btnAddFilter.Text = "Добавить фильтр";
            btnAddFilter.UseVisualStyleBackColor = true;
            btnAddFilter.Click += btnAddFilter_Click;
            // 
            // lstFilters
            // 
            lstFilters.FormattingEnabled = true;
            lstFilters.Location = new Point(847, 846);
            lstFilters.Margin = new Padding(6, 7, 6, 7);
            lstFilters.Name = "lstFilters";
            lstFilters.Size = new Size(690, 132);
            lstFilters.TabIndex = 7;
            lstFilters.SelectedIndexChanged += lstFilters_SelectedIndexChanged;
            lstFilters.DoubleClick += lstFilters_DoubleClick;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Location = new Point(1549, 850);
            btnApplyFilters.Margin = new Padding(6, 7, 6, 7);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(217, 57);
            btnApplyFilters.TabIndex = 8;
            btnApplyFilters.Text = "Применить";
            btnApplyFilters.UseVisualStyleBackColor = true;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Location = new Point(1549, 921);
            btnClearFilters.Margin = new Padding(6, 7, 6, 7);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(217, 57);
            btnClearFilters.TabIndex = 9;
            btnClearFilters.Text = "Очистить";
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(212, 828);
            txtSearch.Margin = new Padding(6, 7, 6, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(429, 39);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbSearchField
            // 
            cbSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchField.FormattingEnabled = true;
            cbSearchField.Location = new Point(212, 892);
            cbSearchField.Margin = new Padding(6, 7, 6, 7);
            cbSearchField.Name = "cbSearchField";
            cbSearchField.Size = new Size(429, 40);
            cbSearchField.TabIndex = 11;
            cbSearchField.SelectedIndexChanged += cbSearchField_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(663, 819);
            btnSearch.Margin = new Padding(6, 7, 6, 7);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(156, 57);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(663, 883);
            btnClearSearch.Margin = new Padding(6, 7, 6, 7);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(156, 57);
            btnClearSearch.TabIndex = 13;
            btnClearSearch.Text = "Сброс";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1797, 1010);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(cbFilterField);
            Controls.Add(cbFilterOperator);
            Controls.Add(txtFilterValue);
            Controls.Add(btnAddFilter);
            Controls.Add(lstFilters);
            Controls.Add(btnApplyFilters);
            Controls.Add(btnClearFilters);
            Controls.Add(txtSearch);
            Controls.Add(cbSearchField);
            Controls.Add(btnSearch);
            Controls.Add(btnClearSearch);
            Margin = new Padding(6, 7, 6, 7);
            Name = "Form1";
            Text = "Информационная система автосалона";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.ComboBox cbFilterField;
        private System.Windows.Forms.ComboBox cbFilterOperator;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearchField;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
    }
}
