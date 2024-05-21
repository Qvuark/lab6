using System;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : Form
{
    public MyForm()
    {
        this.Text = "Drawing Shapes";
        this.Size = new Size(600, 500);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen pen = new Pen(Color.Black);
        Brush brush = new SolidBrush(Color.Blue);

        // Малювання сектора еліпса
        Rectangle ellipseRect = new Rectangle(-100, -50, 250, 200);
        g.DrawPie(pen, ellipseRect, 0, 90);

        // Малювання сегмента кола
        Rectangle circleRect = new Rectangle(80, 150, 200, 200);
        g.DrawArc(pen, circleRect, 0, 90);

        // Малювання квадрата
        Rectangle squareRect = new Rectangle(320, 50, 100, 100);
        g.DrawRectangle(pen, squareRect);

        // Малювання зафарбованого трикутника
        Point[] trianglePoints = { new Point(450, 250), new Point(350, 400), new Point(550, 400) };
        g.FillPolygon(brush, trianglePoints);

        // Звільнення ресурсів
        pen.Dispose();
        brush.Dispose();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MyForm());
    }
}
