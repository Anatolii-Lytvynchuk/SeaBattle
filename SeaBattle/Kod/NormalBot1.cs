using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Kod
{
    internal class NormalBot1 : Bot
    {
        private int[,] mapShot;
        private Random random;
        private int quantity=34;
        private Boolean firstStageCompleted = false;
        public NormalBot1(int[,] mas, int mapSize) : base(mas, mapSize)
        {
            CreateMapShot();
            random = new Random();
        }

        private void CreateMapShot()
        {
            mapShot = new int[,] { { 0, 0 },{1,1 },{2,2},{3,3},{4,4},{ 5,5},{ 6,6},{ 7,7},{ 8,8},{ 9, 9 },
                {0,3},{ 1,4},{2,5 },{3,6},{ 4,7},{ 5,8},{ 6,9}, {0,6 },{1,7},{2,8},{3,9},{ 0,9},
                {3,0 },{4,1},{5,2},{6,3},{7,4},{8,5},{9,6},{6,0},{7,1},{8,2},{9,3},{9,0}
            };
        }

        public void Logic()
        {
            if (resultShot)
            {
                logicsDestruction();
            }
            else
            {
                if (!firstStageCompleted)
                {
                    if (quantity > 0)
                    {
                        FirstStage();

                    }
                    else
                    {
                        firstStageCompleted = true;
                        CountQuantitySecondStage();
                        Logic();
                    }
                }
                else
                    SecondStage();
            }
        }

        private void FirstStage()
        {
            int a = random.Next(quantity);
            for(int i = 0; i < 34; i++)
            {
                if (masPrimerno[mapShot[i, 0], mapShot[i, 1]] == 0)
                {
                    if (a == 0)
                    {
                        CheckResultShot1(mapShot[i, 0], mapShot[i, 1]);
                        quantity--;
                        return;
                    }
                    a--;
                }
            }
         }

        private void CountQuantityFirstStage()
        {
            quantity = 0;
            for(int i=0;i< 34; i++)
            {
                if (masPrimerno[mapShot[i, 0], mapShot[i, 1]] == 0)
                {
                    quantity++;
                }
            }
        }

        private void SecondStage()
        {
            int a = random.Next(quantity);
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (masPrimerno[i, j] == 0)
                    {
                        if (a == 0)
                        {
                            CheckResultShot1(i, j);
                            quantity--;
                            return;
                        }
                        a--;
                    }
                }
            }
        }

        private void CountQuantitySecondStage()
        {
            quantity = 0;
            for(int i = 0; i < mapSize; i++)
            {
                for(int j=0;j<mapSize; j++)
                {
                    if (masPrimerno[i, j] == 0)
                        quantity++;                    
                }
            }
        }

        public void Clear()
        {
            if (firstStageCompleted)
            {
                ClearSecondStage();
                
            }
            else
            {
                ClearFirstStage();
            }
        }


        private void ClearFirstStage()
        {
            resultShot = false;
            quantityShots = 0;
            SifringField();
            CountQuantityFirstStage();
        }

        private void ClearSecondStage()
        {
            resultShot = false;
            quantityShots = 0;
            SifringField();
            CountQuantitySecondStage();
        }
    }
}
