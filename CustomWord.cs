using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rectangle_sample
{
    class CustomWord
    {
        private int xMax = int.MaxValue;
        private int thresholdX = 50;
        private int thresholdY = 50;
       

        public int XMax
        {
            get { return xMax; }
            set { xMax = value; }
        }
        private int xMin = 0;

        public int XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }
        private int yMax = int.MaxValue;

        public int YMax
        {
            get { return yMax; }
            set { yMax = value; }
        }
        private int yMin = 0;

        public int YMin
        {
            get { return yMin; }
            set { yMin = value; }
        }



        public CustomWord(int row, int col) {
            
            if (row < xMax)
            {
                xMax = row;
            }
            if (row > xMin)
            {
                xMin = row;
            }

            if (col < yMax)
            {
                yMax = col;
            }
            if (col > yMin)
            {
                yMin = col;
            }


        }


        public Boolean updateIfNecessary(int row, int col) {
            Boolean isUpdated = false;
            if ((row - xMin < thresholdX) && (col - yMin < thresholdY))
            {

                if (row < xMax)
                {
                    xMax = row;
                }
                if (row > xMin)
                {
                    xMin = row;
                }

                if (col < yMax)
                {
                    yMax = col;
                }
                if (col > yMin)
                {
                    yMin = col;
                }

                isUpdated = true;
            }

            return isUpdated;
        }
    }
}
