using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class MyForm : Form
{
    public MyForm()
    {
        this.Text = "Drawing Landscape";
        this.Size = new Size(800, 500);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // малюю небо
        g.FillRectangle(new SolidBrush(Color.FromArgb(135, 206, 235)), new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height / 2));

        // малюю хмари
        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(100, 50, 100, 50));
        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(150, 100, 100, 50));
        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(250, 80, 100, 50));

        // малюю траву
        g.FillRectangle(new SolidBrush(Color.FromArgb(34, 139, 34)), new Rectangle(0, this.ClientSize.Height / 2, this.ClientSize.Width, this.ClientSize.Height / 2));

        // малюю солнце
        g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(this.ClientSize.Width - 150, 50, 75, 75));

        // малюю дерева
        for (int i = 0; i < 3; i++)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(150, 69, 19)), new Rectangle(this.ClientSize.Width / 4 * (i + 1) - 10, this.ClientSize.Height - 190, 25, 50));
            g.FillEllipse(new SolidBrush(Color.FromArgb(144, 238, 144)), new Rectangle(this.ClientSize.Width / 4 * (i + 1) - 30, this.ClientSize.Height - 250, 70, 70));
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MyForm());
    }
}
