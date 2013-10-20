using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace rectangle_sample
{
    class EdgeDectection
    {
        public List<CustomWord> words = new List<CustomWord>();
       
        public static bool isBlack(int red)
        {
            if (red < 10)
                return true;
            else
                return false;

        }

       
        public void getWordsNew(int[,] imageData, int startX, int endX, int startY, int endY)
        {

            for (int row = startX; row < endX; row++)
            {

                for (int col = startY; col < endY; col++)
                {
                    if (isBlack(imageData[row, col]))
                    {
                        updateWordsList(row, col);
                    }
                }
            }
        }

        public void updateWordsList(int row,int col) { 
            Boolean isUpdated = false;
            foreach(CustomWord word in words){
                isUpdated = word.updateIfNecessary(row, col);
                if (isUpdated) {
                    break;
                }
            }//closing for

            if (isUpdated == false) {
                CustomWord newWord = new CustomWord(row, col);
                words.Add(newWord);
            }
        }
    }

}
