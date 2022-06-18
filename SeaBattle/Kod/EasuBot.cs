using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle.Kod
{
    internal class EasuBot : Bot
    {
        int quantity;
        Random random;
        public EasuBot(int[,] mas, int mapSize) : base(mas, mapSize)
        {
            quantity = mapSize * mapSize;
            random = new Random();
        }

        public  void Logic()
        {
            if (resultShot) {
                logicsDestruction();
                quantity--;
            }
            else
            {
                int a = random.Next(quantity);
                for(int i = 0; i < mapSize; i++)
                {
                    for(int j = 0; j < mapSize; j++)
                    {
                        if (masPrimerno[i, j] == 0)
                        {
                            if (a == 0)
                            {
                                CheckResultShot1(i,j);
                                quantity--;
                                return;
                            }
                            a--;
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            resultShot = false;
            quantityShots = 0;
            SifringField();
            quantity -= result;
        }
    }
}
