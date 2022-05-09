namespace DLLTab
{
    partial class ImportsPropertyPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lv = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dll = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numLbl = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.dll,
            this.address});
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(3, 30);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(374, 370);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 144;
            // 
            // dll
            // 
            this.dll.Text = "DLL";
            this.dll.Width = 130;
            // 
            // address
            // 
            this.address.Text = "Address";
            this.address.Width = 51;
            // 
            // numLbl
            // 
            this.numLbl.AutoSize = true;
            this.numLbl.Location = new System.Drawing.Point(3, 403);
            this.numLbl.Name = "numLbl";
            this.numLbl.Size = new System.Drawing.Size(87, 13);
            this.numLbl.TabIndex = 1;
            this.numLbl.Text = "%d imports found";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(4, 4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(373, 20);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.OnSearchBoxEdit);
            // 
            // ImportsPropertyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.numLbl);
            this.Controls.Add(this.lv);
            this.Name = "ImportsPropertyPage";
            this.Size = new System.Drawing.Size(380, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader dll;
        private System.Windows.Forms.ColumnHeader address;
        private System.Windows.Forms.Label numLbl;
        private System.Windows.Forms.TextBox searchBox;
    }
}
