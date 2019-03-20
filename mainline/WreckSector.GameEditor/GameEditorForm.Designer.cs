namespace WreckSector.GameEditor
{
    partial class GameEditorForm
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
            this.m_tabContainer = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // m_tabContainer
            // 
            this.m_tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabContainer.Location = new System.Drawing.Point(0, 0);
            this.m_tabContainer.Name = "m_tabContainer";
            this.m_tabContainer.SelectedIndex = 0;
            this.m_tabContainer.Size = new System.Drawing.Size(824, 644);
            this.m_tabContainer.TabIndex = 0;
            // 
            // GameEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 644);
            this.Controls.Add(this.m_tabContainer);
            this.Name = "GameEditorForm";
            this.Text = "WreckSector Game Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_tabContainer;
    }
}

