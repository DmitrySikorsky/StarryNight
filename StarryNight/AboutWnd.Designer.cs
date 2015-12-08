namespace StarryNight
{
  partial class AboutWnd
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
      this.lNameAndVersion = new System.Windows.Forms.Label();
      this.bClose = new System.Windows.Forms.Button();
      this.llWebsite = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // lNameAndVersion
      // 
      this.lNameAndVersion.AutoSize = true;
      this.lNameAndVersion.Location = new System.Drawing.Point(10, 10);
      this.lNameAndVersion.Name = "lNameAndVersion";
      this.lNameAndVersion.Size = new System.Drawing.Size(116, 13);
      this.lNameAndVersion.TabIndex = 0;
      this.lNameAndVersion.Text = "StarryNight 1.0.0.0";
      // 
      // bClose
      // 
      this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bClose.Location = new System.Drawing.Point(310, 70);
      this.bClose.Name = "bClose";
      this.bClose.Size = new System.Drawing.Size(75, 23);
      this.bClose.TabIndex = 2;
      this.bClose.Text = "Закрыть";
      this.bClose.UseVisualStyleBackColor = true;
      // 
      // llWebsite
      // 
      this.llWebsite.AutoSize = true;
      this.llWebsite.Location = new System.Drawing.Point(10, 24);
      this.llWebsite.Name = "llWebsite";
      this.llWebsite.Size = new System.Drawing.Size(119, 13);
      this.llWebsite.TabIndex = 1;
      this.llWebsite.TabStop = true;
      this.llWebsite.Text = "http://sikorsky.pro/";
      this.llWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llWebsite_LinkClicked);
      // 
      // AboutWnd
      // 
      this.AcceptButton = this.bClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bClose;
      this.ClientSize = new System.Drawing.Size(394, 102);
      this.Controls.Add(this.llWebsite);
      this.Controls.Add(this.bClose);
      this.Controls.Add(this.lNameAndVersion);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutWnd";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "О программе";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lNameAndVersion;
    private System.Windows.Forms.Button bClose;
    private System.Windows.Forms.LinkLabel llWebsite;
  }
}