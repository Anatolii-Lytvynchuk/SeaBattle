using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle.Kod
{
    internal class Bot
    {

        private int[,] masReal;
        protected int[,] masPrimerno;
        protected int mapSize;
      //  protected bool resultShotLeft = false;
      //  protected bool resultShotRight = false;
      //  protected bool resultShotUp = false;
      //  protected bool resultShotDown = false;
        protected bool resultShot = false;
        protected int quantityShots = 0,result=0;
        private int i1,j1,iContinue, jContinue;
        public Bot(int[,] mas, int mapSize)
        {
            this.masReal = mas;
            this.mapSize = mapSize;
            masPrimerno = new int[mapSize, mapSize];
        }
        protected void CheckResultShot1(int i, int j)
        {
            if (masReal[i, j] != 0)
            {
                i1 = i;
                j1 = j;
                iContinue = i;
                jContinue = j;
                masReal[i, j]++;
                resultShot = true;
                masPrimerno[i, j] = 2;
                return;
            }
            masPrimerno[i, j] = 1;
            masReal[i, j] = 1;
        }

        private void CheckResultShot(int i, int j)
        {
            if (masReal[i, j] != 0)
            {
                masPrimerno[i, j] = 2;
                iContinue = i;
                jContinue = j;
                masReal[i, j]++;
                return ;
            }
            masPrimerno[i, j] = 1;
            iContinue = i1;
            jContinue = j1;
            masReal[i, j] = 1;
            quantityShots++;
        }

        private bool CheckingPosibleShotUp(int i, int j)
        {
            if (i > 0)
            {
                if (masPrimerno[i - 1, j] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckingPosibleShotLeft(int i, int j)
        {
            if (j>0)
            {
                if (masPrimerno[i, j-1] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckingPosibleShotRight(int i, int j)
        {
            if (j + 1 < mapSize)
            {
                if (masPrimerno[i, j+1] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        protected void logicsDestruction()
        {
            switch (quantityShots)
            {
                case 0:
                    if (CheckingPosibleShotLeft(iContinue, jContinue))
                    {
                        CheckResultShot(iContinue, jContinue - 1);
                    }
                    else
                    {
                        iContinue = i1;
                        jContinue = j1;
                        quantityShots++;
                        goto case 1;
                    }
                    break;
                case 1:
                    if (CheckingPosibleShotRight(iContinue, jContinue))
                    {
                        CheckResultShot(iContinue, jContinue + 1);
                    }
                    else
                    {
                        iContinue = i1;
                        jContinue = j1;
                        quantityShots++;
                        goto case 2;
                    }
                    break;
                case 2:
                    if (CheckingPosibleShotUp(iContinue, jContinue))
                    {
                         CheckResultShot(iContinue - 1, jContinue);
                    }
                    else
                    {
                        iContinue = i1;
                        jContinue = j1;
                        quantityShots++;
                        goto default;
                    }
                    break;
                default:
                     CheckResultShot(iContinue + 1, jContinue);
                    break;
            
            }
        }

        protected void SifringField()
        {
            result = 0;
            for(int i = 1; i < mapSize-1; i++)
            {
                if (masPrimerno[i, 0] == 2)
                {
                    Verification(i - 1, 0);
                    Verification(i - 1, 1);
                    Verification(i, 1);
                    Verification(i + 1, 1);
                    Verification(i + 1, 0);
                    masPrimerno[i, 0] = 1;
                }
                if (masPrimerno[i, 9] == 2)
                {
                    Verification(i - 1, 9);
                    Verification(i - 1, 8);
                    Verification(i, 8);
                    Verification(i + 1, 8);
                    Verification(i + 1, 9);
                    masPrimerno[i, 9] = 1;
                }
            }
            if (masPrimerno[0, 0] == 2)
            {
                Verification(0, 1);
                Verification(1, 1);
                Verification(1, 0);
                masPrimerno[0, 0] = 1;
            }
            if (masPrimerno[9, 0] == 2)
            {
                Verification(8,0);
                Verification(8, 1);
                Verification(9, 1);
                masPrimerno[9, 0] = 1;
            }
            if (masPrimerno[0, 9] == 2)
            {
                Verification(0, 8);
                Verification(1, 8);
                Verification(1, 9);
                masPrimerno[0, 9] = 1;
            }
            if (masPrimerno[9, 9] == 2)
            {
                Verification(9, 8);
                Verification(8, 8);
                Verification(8, 9);
                masPrimerno[9, 9] = 1;
            }
            for(int j = 1; j < mapSize - 1; j++)
            {
                if (masPrimerno[0, j] == 2)
                {
                    Verification(0, j - 1);
                    Verification(1, j - 1);
                    Verification(1, j);
                    Verification(1, j + 1);
                    Verification(0, j + 1);
                    masPrimerno[0, j] = 1;
                }
                if (masPrimerno[9, j] == 2)
                {
                    Verification(9, j - 1);
                    Verification(8, j - 1);
                    Verification(8, j);
                    Verification(8, j + 1);
                    Verification(9, j + 1);
                    masPrimerno[9, j] = 1;
                }
            }
            for(int i = 1; i < mapSize - 1; i++)
            {
                for(int j=1;j<mapSize-1; j++)
                {
                    if (masPrimerno[i, j] == 2)
                    {
                        Verification(i - 1, j - 1);
                        Verification(i - 1, j);
                        Verification(i - 1, j + 1);
                        Verification(i, j + 1);
                        Verification(i + 1, j + 1);
                        Verification(i + 1, j);
                        Verification(i + 1, j - 1);
                        Verification(i, j - 1);
                    }
                }
            }
        }

        private void Verification(int i,int j)
        {
            if (masPrimerno[i, j] == 0)
            {
                masPrimerno[i, j] = 1;
                result++;
            }
        }
    }
}