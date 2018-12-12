namespace CS008
{
    class Drawer
    {
        public Drawer(int w, int h, double x0, double y0, double x1, double y1)
        {
            W = w;
            H = h;
            X0 = x0;
            Y0 = y0;
            X1 = x1;
            Y1 = y1;
        }
        public int W { get; set; }
        public int H { get; set; }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public delegate double DrawDelegate(double x);
        public int[,] Draw(DrawDelegate f)
        {
            int[,] aImage = new int[H, W];

            for (int j = 0; j < W; j++)
            {
                double x = j * (X1 - X0) / (W - 1) + X0;
                double y = f(x);
                int i = (int)((H - 1) - (y - Y0) / (Y1 - Y0) * (H - 1));
                if (i >= 0 && i < H) aImage[i, j] = 1;
            }
            return aImage;
        }
    }
}
