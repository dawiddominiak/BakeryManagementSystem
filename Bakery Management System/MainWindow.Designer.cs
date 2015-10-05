namespace BakeryManagementSystem
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorkingDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkingDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assortmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vatRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.managementToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorkingDayToolStripMenuItem,
            this.openWorkingDayToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.exportDataToolStripMenuItem,
            this.resetDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newWorkingDayToolStripMenuItem
            // 
            this.newWorkingDayToolStripMenuItem.Name = "newWorkingDayToolStripMenuItem";
            resources.ApplyResources(this.newWorkingDayToolStripMenuItem, "newWorkingDayToolStripMenuItem");
            this.newWorkingDayToolStripMenuItem.Click += new System.EventHandler(this.newWorkingDayToolStripMenuItem_Click);
            // 
            // openWorkingDayToolStripMenuItem
            // 
            this.openWorkingDayToolStripMenuItem.Name = "openWorkingDayToolStripMenuItem";
            resources.ApplyResources(this.openWorkingDayToolStripMenuItem, "openWorkingDayToolStripMenuItem");
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            resources.ApplyResources(this.recentToolStripMenuItem, "recentToolStripMenuItem");
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            resources.ApplyResources(this.importDataToolStripMenuItem, "importDataToolStripMenuItem");
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            resources.ApplyResources(this.exportDataToolStripMenuItem, "exportDataToolStripMenuItem");
            // 
            // resetDataToolStripMenuItem
            // 
            this.resetDataToolStripMenuItem.Name = "resetDataToolStripMenuItem";
            resources.ApplyResources(this.resetDataToolStripMenuItem, "resetDataToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            resources.ApplyResources(this.openSettingsToolStripMenuItem, "openSettingsToolStripMenuItem");
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assortmentToolStripMenuItem,
            this.shopsToolStripMenuItem,
            this.routesToolStripMenuItem,
            this.priceListsToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            resources.ApplyResources(this.managementToolStripMenuItem, "managementToolStripMenuItem");
            // 
            // assortmentToolStripMenuItem
            // 
            this.assortmentToolStripMenuItem.Name = "assortmentToolStripMenuItem";
            resources.ApplyResources(this.assortmentToolStripMenuItem, "assortmentToolStripMenuItem");
            this.assortmentToolStripMenuItem.Click += new System.EventHandler(this.assortmentToolStripMenuItem_Click);
            // 
            // shopsToolStripMenuItem
            // 
            this.shopsToolStripMenuItem.Name = "shopsToolStripMenuItem";
            resources.ApplyResources(this.shopsToolStripMenuItem, "shopsToolStripMenuItem");
            // 
            // routesToolStripMenuItem
            // 
            this.routesToolStripMenuItem.Name = "routesToolStripMenuItem";
            resources.ApplyResources(this.routesToolStripMenuItem, "routesToolStripMenuItem");
            // 
            // priceListsToolStripMenuItem
            // 
            this.priceListsToolStripMenuItem.Name = "priceListsToolStripMenuItem";
            resources.ApplyResources(this.priceListsToolStripMenuItem, "priceListsToolStripMenuItem");
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vatRatesToolStripMenuItem});
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            resources.ApplyResources(this.othersToolStripMenuItem, "othersToolStripMenuItem");
            // 
            // vatRatesToolStripMenuItem
            // 
            this.vatRatesToolStripMenuItem.Name = "vatRatesToolStripMenuItem";
            resources.ApplyResources(this.vatRatesToolStripMenuItem, "vatRatesToolStripMenuItem");
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWorkingDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWorkingDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assortmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shopsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vatRatesToolStripMenuItem;
    }
}