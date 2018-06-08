namespace MLP_GUI
{
    partial class WeightChart
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
            this.ChartUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ChartUpdate
            // 
            this.ChartUpdate.Tag = "ch";
            // 
            // WeightChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 600);
            this.Name = "WeightChart";
            this.Text = "WeightChart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ChartUpdate;
    }
}