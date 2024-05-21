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
        // встановлюю розмір вікна
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        // створюю об'єкт Bitmap та ставлю його як задній екран
        this.BackgroundImage = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        using (var g = Graphics.FromImage(this.BackgroundImage))
        {
            //створюю небо
            g.Clear(Color.Navy);
            // малюю землю
            g.FillRectangle(new SolidBrush(Color.DarkGreen), new Rectangle(0, this.ClientSize.Height - 50, this.ClientSize.Width, 50));
            //малюю зірки на небі
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(100, 50, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(470, 100, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(300, 150, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(400, 300, 5, 5));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(500, 250, 5, 5));
            //малюю місяць
            g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(20, 20, 40, 40));
        }
        // ініціалізую змінні _x, _smokeCount та _random
        _x = -100;
        _smokeCount = 0;
        _random = new Random();
        //створюю таймер
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 80;
        timer.Tick += OnTimerTick;
        //запускаю таймер
        timer.Start();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        //добавляю потрібні частини для малювання поїзду
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality;
        // малюю чорні та сірий прямокутники, які представляють вагони
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x + 50, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x + 100, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(_x + 150, this.ClientSize.Height - 70, 50, 30));
        g.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(_x + 200, this.ClientSize.Height - 70, 30, 30));
        //малюю дим від потягу
        for (int i = 0; i < _smokeCount; i++)
        {
            //вичисляю вертикальне зміщення для кожного диму за допомогою функції Math.Sin для анімації вертикального руху диму
            int y = this.ClientSize.Height - 100 - i * 20;
            //вичисляю випадкове горизонтальне зміщення для кожного диму за допомогою об'єкта _random
            int offset = _random.Next(-20, 20);
            // малюю сірий еліпс, який в буде димом
            g.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Gray)), new Rectangle(_x + 125 + offset + i * 5, y, 20, 20));
        }
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        //пишу логіку для переміщення потягу
        _x += 5;
        if (_x > this.ClientSize.Width)
        {
            _x = -100;
            _smokeCount = 0;
        }
        //збульшую значення змінної _smokeCount на 1, якщо поїзд знаходиться на екрані та кількість димів менше 10
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
