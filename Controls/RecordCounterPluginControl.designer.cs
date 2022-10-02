
using System.ComponentModel;

namespace DynamicTouch.RecordsByOwner
{
    partial class RecordCounterPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordCounterPluginControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selectUsersAndSolutions1 = new DynamicTouch.RecordsByOwner.SelectUsersAndSolutions();
            this.entityRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metadataIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.logicalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displaynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerRecordsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityRecordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.tsbClose});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(746, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 28);
            this.toolStripButton2.Text = "Count";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(107, 28);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.selectUsersAndSolutions1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(746, 339);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.metadataIdDataGridViewTextBoxColumn,
            this.visibleDataGridViewCheckBoxColumn,
            this.dataGridViewCheckBoxColumn2,
            this.logicalNameDataGridViewTextBoxColumn,
            this.displaynameDataGridViewTextBoxColumn,
            this.countStatusDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.ownerRecordsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.entityRecordBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(503, 339);
            this.dataGridView1.TabIndex = 7;
            // 
            // selectUsersAndSolutions1
            // 
            this.selectUsersAndSolutions1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectUsersAndSolutions1.Location = new System.Drawing.Point(0, 0);
            this.selectUsersAndSolutions1.Name = "selectUsersAndSolutions1";
            this.selectUsersAndSolutions1.Size = new System.Drawing.Size(239, 339);
            this.selectUsersAndSolutions1.TabIndex = 0;
            // 
            // entityRecordBindingSource
            // 
            this.entityRecordBindingSource.DataSource = typeof(DynamicTouch.RecordsByOwner.EntityRecord);
            // 
            // metadataIdDataGridViewTextBoxColumn
            // 
            this.metadataIdDataGridViewTextBoxColumn.DataPropertyName = "MetadataId";
            this.metadataIdDataGridViewTextBoxColumn.HeaderText = "MetadataId";
            this.metadataIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.metadataIdDataGridViewTextBoxColumn.Name = "metadataIdDataGridViewTextBoxColumn";
            this.metadataIdDataGridViewTextBoxColumn.Visible = false;
            this.metadataIdDataGridViewTextBoxColumn.Width = 84;
            // 
            // visibleDataGridViewCheckBoxColumn
            // 
            this.visibleDataGridViewCheckBoxColumn.DataPropertyName = "Visible";
            this.visibleDataGridViewCheckBoxColumn.HeaderText = "Visible";
            this.visibleDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.visibleDataGridViewCheckBoxColumn.Name = "visibleDataGridViewCheckBoxColumn";
            this.visibleDataGridViewCheckBoxColumn.Visible = false;
            this.visibleDataGridViewCheckBoxColumn.Width = 55;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "CountRecords";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Count records";
            this.dataGridViewCheckBoxColumn2.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 103;
            // 
            // logicalNameDataGridViewTextBoxColumn
            // 
            this.logicalNameDataGridViewTextBoxColumn.DataPropertyName = "LogicalName";
            this.logicalNameDataGridViewTextBoxColumn.HeaderText = "Logical name";
            this.logicalNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.logicalNameDataGridViewTextBoxColumn.Name = "logicalNameDataGridViewTextBoxColumn";
            this.logicalNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.logicalNameDataGridViewTextBoxColumn.Width = 121;
            // 
            // displaynameDataGridViewTextBoxColumn
            // 
            this.displaynameDataGridViewTextBoxColumn.DataPropertyName = "Displayname";
            this.displaynameDataGridViewTextBoxColumn.HeaderText = "Display name";
            this.displaynameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.displaynameDataGridViewTextBoxColumn.Name = "displaynameDataGridViewTextBoxColumn";
            this.displaynameDataGridViewTextBoxColumn.ReadOnly = true;
            this.displaynameDataGridViewTextBoxColumn.Width = 122;
            // 
            // countStatusDataGridViewTextBoxColumn
            // 
            this.countStatusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.countStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.countStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.countStatusDataGridViewTextBoxColumn.Name = "countStatusDataGridViewTextBoxColumn";
            this.countStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.countStatusDataGridViewTextBoxColumn.Width = 77;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RecordCount";
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 74;
            // 
            // ownerRecordsDataGridViewTextBoxColumn
            // 
            this.ownerRecordsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ownerRecordsDataGridViewTextBoxColumn.DataPropertyName = "OwnerRecords";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownerRecordsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.ownerRecordsDataGridViewTextBoxColumn.HeaderText = "Owners";
            this.ownerRecordsDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.ownerRecordsDataGridViewTextBoxColumn.Name = "ownerRecordsDataGridViewTextBoxColumn";
            this.ownerRecordsDataGridViewTextBoxColumn.Width = 200;
            // 
            // RecordCounterPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecordCounterPluginControl";
            this.Size = new System.Drawing.Size(746, 370);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityRecordBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SelectUsersAndSolutions selectUsersAndSolutions1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BindingList<EntityRecord> EntityItems { get; set; }
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn countRecordsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource entityRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn metadataIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn logicalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displaynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerRecordsDataGridViewTextBoxColumn;
    }
}
