using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class MyForm : Form
{
    private Rectangle _rectangle;
    private int _angle;
    private int _x;
    private int _amplitude;

    public MyForm()
    {
        //������� ����
        this.Text = "Moving and Rotating Rectangle";
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        //������� ������� ���� �����
        _rectangle = new Rectangle(0, 0, 100, 50);
        _angle = 0;
        _x = -_rectangle.Width;
        _amplitude = _rectangle.Height;
        //������� ������ ���� ��������� ���� 20 ���������
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 20;
        timer.Tick += OnTimerTick;
        timer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        //�������� ������ ������� ��� ��������� �������������
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality;
        //����� �������� ������������
        var matrix = new Matrix();
        matrix.Translate(_x, (int)(_amplitude * Math.Sin(_angle * Math.PI / 180)) + this.ClientSize.Height / 2);
        matrix.RotateAt(_angle, new PointF(_rectangle.Width / 2, _rectangle.Height / 2));
        g.Transform = matrix;
        //���������� ������������
        g.FillRectangle(new SolidBrush(Color.FromArgb(34, 139, 34)), _rectangle);
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        //������� ��� ������� ���� ������������
        _angle++;
        _x += 5;
        if (_x > this.ClientSize.Width)
        {
            _x = -_rectangle.Width;
        }
        this.Invalidate();
    }

    [STAThread]
    public static void Main()
    {
        //������ ����
        Application.EnableVisualStyles();
        Application.Run(new MyForm());
    }
}
