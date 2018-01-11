using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExportPrograms {
  public partial class AllDone : Form {
    public AllDone() {
      InitializeComponent();
      List<Bitmap> bmps = new List<Bitmap>();
      bmps.AddRange(new Bitmap[] {
        Properties.Resources.meaning_of_vault_boy_thumbs_up_jpg,
        Properties.Resources.sarcastic_thumbs_up,
        Properties.Resources.Thumbs_Up,
        Properties.Resources.Thumbs_Up_1_copy,
        Properties.Resources.thumbs_up_bciy,
        Properties.Resources.thumbs_up_through_wall_T,
        Properties.Resources.thumbsAmmo03,
        Properties.Resources.thumbsup6
      });
      Random r = new Random();
      int selection = r.Next(0, bmps.Count);
      pictureBox1.Size = bmps[selection].Size;
      pictureBox1.Image = bmps[selection];
      StartPosition = FormStartPosition.CenterParent;
      Size s = new Size(bmps[selection].Size.Width + 5, bmps[selection].Size.Height + 160);
      this.Size = s;
    }

    private void button1_Click(object sender, EventArgs e) {
      Close();
    }
  }
}