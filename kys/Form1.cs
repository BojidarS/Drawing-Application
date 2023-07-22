namespace kys
{
    public partial class Form1 : Form
    {

        public Point current = new Point();
        public Point old = new Point();

        public Graphics g;

        public Graphics graph;

        public Pen pen = new Pen(Color.Black, 5);

        Bitmap surface;

        public Form1()
        {
            InitializeComponent();

            g = canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(canvas.Width, canvas.Height);

            graph = Graphics.FromImage(surface);

            canvas.BackgroundImage = surface;
            canvas.BackgroundImageLayout = ImageLayout.None;

            pen.Width = (float)sizebar.Value;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                current = e.Location;
                g.DrawLine(pen, old, current);
                graph.DrawLine(pen, old, current);

                old = current;
            }
        }

        private void eraserbtn_Click(object sender, EventArgs e)
        {
            pen.Color = canvas.BackColor;
        }

        private void brushbtn_Click(object sender, EventArgs e)
        {
            pen.Color = colorselector.BackColor;
        }

        private void colorselector_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
                colorselector.BackColor = cd.Color;
            }

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            graph.Clear(canvas.BackColor);
            canvas.Invalidate();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Png Files (*png) | *.png";
            sfd.DefaultExt = "png";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                surface.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void pbsize_Change(object sender, EventArgs e)
        {
            pen.Width = (float)sizebar.Value;
        }
    }
}