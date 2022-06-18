using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Kod
{
    internal class CheckForVictiryAndDefeat
    {
        int[,] myMap;
        int [,] enemyMap;
        int mapSize;
        public CheckForVictiryAndDefeat(int[,] myMap, int[,] enemyMap,int mapSize)
        {
            this.myMap = myMap;
            this.enemyMap = enemyMap;
            this.mapSize = mapSize;
        }

        public Boolean CheckForVictory()
        {
            for(int i = 0; i < mapSize; i++)
            {
                for(int j=0; j < mapSize; j++)
                {
                    if (enemyMap[i,j]!=0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean CheckForDefeat()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (myMap[i, j]>1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}