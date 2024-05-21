using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class MyForm : Form
{
    private int _x;
    private int _smokeCount;
    private Random _random;

    public MyForm()
    {
        // ���������� ����� ����
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        // ������� ��'��� Bitmap �� ������ ���� �� ����� �����
        this.BackgroundImage = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        using (var g = Graphics.FromImage(this.BackgroundImage))
        {
            //������� ����
            g.Clear(Color.Navy);
            // ����� �����
            g.FillRectangle(new SolidBrush(Color.DarkGreen), new Rectangle(0, this.ClientSize.Height - 50, this.ClientSize.Width, 50));
            //����� ���� �� ���
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(100, 50, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(470, 100, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(300, 150, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(400, 300, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(500, 250, 5, 5));
            //����� �����
            g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(20, 20, 40, 40));
        }
        // ��������� ���� _x, _smokeCount �� _random
        _x = -100;
        _smokeCount = 0;
        _random = new Random();
        //������� ������
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 80;
        timer.Tick += OnTimerTick;
        //�������� ������
        timer.Start();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        //�������� ������ ������� ��� ��������� �����
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality;
        // ����� ���� �� ���� ������������, �� ������������� ������
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x + 50, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x + 100, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x + 150, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(_x + 200, this.ClientSize.Height - 70, 30, 30));
        //����� ��� �� ������
        for (int i = 0; i < _smokeCount; i++)
        {
            //�������� ����������� ������� ��� ������� ���� �� ��������� ������� Math.Sin ��� ������� ������������� ���� ����
            int y = this.ClientSize.Height - 100 - i * 20;
            //�������� ��������� ������������� ������� ��� ������� ���� �� ��������� ��'���� _random
            int offset = _random.Next(-20, 20);
            // ����� ���� ����, ���� � ���� �����
            g.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Gray)), new Rectangle(_x + 125 + offset + i * 5, y, 20, 20));
        }
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        //���� ����� ��� ���������� ������
        _x += 5;
        if (_x > this.ClientSize.Width)
        {
            _x = -100;
            _smokeCount = 0;
        }
        //�������� �������� ����� _smokeCount �� 1, ���� ���� ����������� �� ����� �� ������� ���� ����� 10
        if (_x > 0 && _smokeCount < 10)
        {
            _smokeCount++;
        }
        this.Invalidate();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MyForm());
    }
}
