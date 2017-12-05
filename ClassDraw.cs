using System;

namespace SpotoMasterRace
{
    class ClassDraw
    {
        private double XFoglioMin;
        private double XFoglioMax;
        private double YFoglioMin;
        private double YFoglioMax;
        private int XVideoMin;
        private int XVideoMax;
        private int YVideoMax;
        private int YVideoMin;

        public double xFoglioMin
        {
            get { return XFoglioMin; }
            set { XFoglioMin = value; }
        }

        public double xFoglioMax
        {
            get { return XFoglioMax; }
            set { XFoglioMax = value; }
        }

        public double yFoglioMin
        {
            get { return YFoglioMin; }
            set { YFoglioMin = value; }
        }

        public double yFoglioMax
        {
            get { return YFoglioMax; }
            set { YFoglioMax = value; }
        }

        public int xVideoMin
        {
            get { return XVideoMin; }
            set { XVideoMin = value; }
        }

        public int xVideoMax
        {
            get { return XVideoMax; }
            set { XVideoMax = value; }
        }

        public int yVideoMin
        {
            get { return YVideoMin; }
            set { YVideoMin = value; }
        }

        public int yVideoMax
        {
            get { return YVideoMax; }
            set { YVideoMax = value; }
        }

        public int XVideo(double xf)
        { return Convert.ToInt32((((xVideoMax - xVideoMin) / (xFoglioMax - xFoglioMin)) * (xf - xFoglioMin)) + xVideoMin); }

        public int YVideo(double yf)
        { return Convert.ToInt32((((yVideoMax - yVideoMin) / (yFoglioMax - yFoglioMin)) * (yf - yFoglioMin)) + yVideoMin); }

        public double XFoglio(int xv)
        { return Convert.ToDouble(((xv + xVideoMin) * ((xFoglioMax - xFoglioMin) / (xVideoMax - xVideoMin))) + xFoglioMin); }

        public double YFoglio(int yv)
        { return Convert.ToDouble(((yv + yVideoMin) * ((yFoglioMax - yFoglioMin) / (yVideoMax - yVideoMin))) + yFoglioMin); }
        /*
        public void ZoomPlus()
        {
            xFoglioMin += 1;
            xFoglioMax -= 1;
            yFoglioMin += 0.1;
            yFoglioMax -= 0.1;
        }

        public void ZoomMinus()
        {
            xFoglioMin -= 1;
            xFoglioMax += 1;
            yFoglioMin -= 0.1;
            yFoglioMax += 0.1;
        }*/
    }
}