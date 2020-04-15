namespace SearchMoudle
{
    partial class SearchForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchCbo = new System.Windows.Forms.ComboBox();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.BrnPrt = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.SearchGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SearchCbo);
            this.panel1.Controls.Add(this.BtnExcel);
            this.panel1.Controls.Add(this.BrnPrt);
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 63);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "조회조건";
            // 
            // SearchCbo
            // 
            this.SearchCbo.FormattingEnabled = true;
            this.SearchCbo.Location = new System.Drawing.Point(82, 20);
            this.SearchCbo.Name = "SearchCbo";
            this.SearchCbo.Size = new System.Drawing.Size(121, 25);
            this.SearchCbo.TabIndex = 3;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExcel.Location = new System.Drawing.Point(418, 6);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(81, 50);
            this.BtnExcel.TabIndex = 2;
            this.BtnExcel.Text = "Excel";
            this.BtnExcel.UseVisualStyleBackColor = true;
            // 
            // BrnPrt
            // 
            this.BrnPrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrnPrt.Location = new System.Drawing.Point(331, 6);
            this.BrnPrt.Name = "BrnPrt";
            this.BrnPrt.Size = new System.Drawing.Size(81, 50);
            this.BrnPrt.TabIndex = 1;
            this.BrnPrt.Text = "출력";
            this.BrnPrt.UseVisualStyleBackColor = true;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRefresh.Location = new System.Drawing.Point(244, 6);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(81, 50);
            this.BtnRefresh.TabIndex = 0;
            this.BtnRefresh.Text = "조회";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // SearchGrid
            // 
            this.SearchGrid.BackgroundColor = System.Drawing.Color.White;
            this.SearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchGrid.GridColor = System.Drawing.Color.White;
            this.SearchGrid.Location = new System.Drawing.Point(0, 63);
            this.SearchGrid.Name = "SearchGrid";
            this.SearchGrid.RowTemplate.Height = 23;
            this.SearchGrid.Size = new System.Drawing.Size(506, 473);
            this.SearchGrid.TabIndex = 1;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 536);
            this.Controls.Add(this.SearchGrid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SearchCbo;
        private System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.Button BrnPrt;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.DataGridView SearchGrid;
    }
}

