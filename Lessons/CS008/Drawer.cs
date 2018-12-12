namespace CS008
{
    class Drawer
    {
        public Drawer(double x0, double y0, double x1, double y1)
        {
            X0 = x0;
            Y0 = y0;
            X1 = x1;
            Y1 = y1;
        }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public delegate double DrawDelegate(double x);
        public void Draw(int[,] aImage, DrawDelegate f)
        {
            int W = aImage.GetLength(1);
            int H = aImage.GetLength(0);
            for (int j = 0; j < W; j++)
            {
                double x = j * (X1 - X0) / (W - 1) + X0;
                double y = f(x);
                int i = (int)((H - 1) - (y - Y0) / (Y1 - Y0) * (H - 1));
                if (i >= 0 && i < H) aImage[i, j] = 1;
            }
        }
    }
}
