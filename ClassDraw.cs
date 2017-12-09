using System;

namespace SpotoMasterRace
{
    internal class ClassDraw
    {
        private double XSheetMin;
        private double XSheetMax;
        private double YSheetMin;
        private double YSheetMax;
        private int XVideoMin;
        private int XVideoMax;
        private int YVideoMax;
        private int YVideoMin;

        public double xSheetMin
        {
            get { return XSheetMin; }
            set { XSheetMin = value; }
        }

        public double xSheetMax
        {
            get { return XSheetMax; }
            set { XSheetMax = value; }
        }

        public double ySheetMin
        {
            get { return YSheetMin; }
            set { YSheetMin = value; }
        }

        public double ySheetMax
        {
            get { return YSheetMax; }
            set { YSheetMax = value; }
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

        public int XVideo(double xs)
        { return Convert.ToInt32((((xVideoMax - xVideoMin) / (xSheetMax - xSheetMin)) * (xs - xSheetMin)) + xVideoMin); }

        public int YVideo(double ys)
        { return Convert.ToInt32((((yVideoMax - yVideoMin) / (ySheetMax - ySheetMin)) * (ys - ySheetMin)) + yVideoMin); }

        public double XSheet(int xv)
        { return Convert.ToDouble(((xv + xVideoMin) * ((xSheetMax - xSheetMin) / (xVideoMax - xVideoMin))) + xSheetMin); }

        public double YSheet(int yv)
        { return Convert.ToDouble(((yv + yVideoMin) * ((ySheetMax - ySheetMin) / (yVideoMax - yVideoMin))) + ySheetMin); }
    }
}