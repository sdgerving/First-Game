namespace Character_movement
{
    partial class Dungeon
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
            this.movedown = new System.Windows.Forms.Timer(this.components);
            this.moveup = new System.Windows.Forms.Timer(this.components);
            this.moveright = new System.Windows.Forms.Timer(this.components);
            this.moveleft = new System.Windows.Forms.Timer(this.components);
            this.movedownanim = new System.Windows.Forms.Timer(this.components);
            this.moveupanim = new System.Windows.Forms.Timer(this.components);
            this.moverightanim = new System.Windows.Forms.Timer(this.components);
            this.moveleftanim = new System.Windows.Forms.Timer(this.components);
            this.chestanim = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // movedown
            // 
            this.movedown.Tick += new System.EventHandler(this.movedown_Tick);
            // 
            // moveup
            // 
            this.moveup.Tick += new System.EventHandler(this.moveup_Tick);
            // 
            // moveright
            // 
            this.moveright.Tick += new System.EventHandler(this.moveright_Tick);
            // 
            // moveleft
            // 
            this.moveleft.Tick += new System.EventHandler(this.moveleft_Tick);
            // 
            // movedownanim
            // 
            this.movedownanim.Tick += new System.EventHandler(this.movedownanim_Tick);
            // 
            // moveupanim
            // 
            this.moveupanim.Tick += new System.EventHandler(this.moveupanim_Tick);
            // 
            // moverightanim
            // 
            this.moverightanim.Tick += new System.EventHandler(this.moverightanim_Tick);
            // 
            // moveleftanim
            // 
            this.moveleftanim.Tick += new System.EventHandler(this.moveleftanim_Tick);
            // 
            // chestanim
            // 
            this.chestanim.Tick += new System.EventHandler(this.chestanim_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(926, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Dungeon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1250, 907);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dungeon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer movedown;
        private System.Windows.Forms.Timer moveup;
        private System.Windows.Forms.Timer moveright;
        private System.Windows.Forms.Timer moveleft;
        private System.Windows.Forms.Timer movedownanim;
        private System.Windows.Forms.Timer moveupanim;
        private System.Windows.Forms.Timer moverightanim;
        private System.Windows.Forms.Timer moveleftanim;
        private System.Windows.Forms.Timer chestanim;
        private System.Windows.Forms.Label label1;
    }
}

