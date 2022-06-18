using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle.Kod
{
    internal class GenerationMaps
    {

        public GenerationMaps()
        {

        }

        private void CreateMap(int[,] mas, int mapSize)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    mas[i, j] = 0;
                }
            }
        }

        public void FillingWithShips(int[,] mas, int mapSize)
        {
            CreateMap(mas, mapSize);
            ShipGeneration(4, mapSize, mas,41);
            ShipGeneration(3, mapSize, mas,33);
            ShipGeneration(3, mapSize, mas,31);
            ShipGeneration(2, mapSize, mas,25);
            ShipGeneration(2, mapSize, mas,23);
            ShipGeneration(2, mapSize, mas,21);
            ShipGeneration(1, mapSize, mas,17);
            ShipGeneration(1, mapSize, mas,15);
            ShipGeneration(1, mapSize, mas,13);
            ShipGeneration(1, mapSize, mas,11);
        }

        public void FillingWithShipsSeparatety(int[,] mas, int mapSize)
        {
            CreateMap(mas, mapSize);
            ShipGenerationSeparatety(4, mapSize, mas, 41);
            ShipGenerationSeparatety(3, mapSize, mas, 33);
            ShipGenerationSeparatety(3, mapSize, mas, 31);
            ShipGenerationSeparatety(2, mapSize, mas, 25);
            ShipGenerationSeparatety(2, mapSize, mas, 23);
            ShipGenerationSeparatety(2, mapSize, mas, 21);
            ShipGenerationSeparatety(1, mapSize, mas, 17);
            ShipGenerationSeparatety(1, mapSize, mas, 15);
            ShipGenerationSeparatety(1, mapSize, mas, 13);
            ShipGenerationSeparatety(1, mapSize, mas, 11);
            CleanerMap(mas,mapSize);
        }

        public void GoodFillingWithShipsSeparatety(int[,] mas, int mapSize)
        {
            CreateMap(mas, mapSize);
            GoodShipGeneration(mas);
            ShipGenerationSeparatety(1, mapSize, mas, 17);
            ShipGenerationSeparatety(1, mapSize, mas, 15);
            ShipGenerationSeparatety(1, mapSize, mas, 13);
            ShipGenerationSeparatety(1, mapSize, mas, 11);
            CleanerMap(mas, mapSize);
        }


        private void CleanerMap(int[,] mas, int mapSize)
        {
            for(int i = 0; i < mapSize; i++)
            {
                for(int j = 0; j < mapSize; j++)
                {
                    if (mas[i,j]==3)
                        mas[i,j] = 0;
                }
            }
        }

        private void ShipGeneration(int k, int mapSize, int[,] mas,int number)
        {
            int i1, j1;
            Random random = new Random();
            Boolean flag = true, result;
            if (random.Next(2) == 0)
            {
                flag = false;
            }
            while (k!=0)
            {
                result = true;
                i1 = random.Next(mapSize);
                j1 = random.Next(mapSize);
                if (flag == true && i1 <= mapSize - k)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (mas[i1 + i, j1] != 0)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            mas[i1 + i, j1] = number;
                        }
                        k = 0;
                    }
                }
                else if (flag == false && j1 <= mapSize - k)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (mas[i1, j1 + j] != 0)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            mas[i1, j1 + j] = number;
                        }
                        k = 0;
                    }
                }
            }
        }

        private void ShipGenerationSeparatety(int k, int mapSize, int[,] map, int number)
        {
            int i1, j1;
            Random random = new Random();
            Boolean flag = true, result;
            if (random.Next(2) == 0)
            {
                flag = false;
            }
            while (k != 0)
            {
                result = true;
                i1 = random.Next(mapSize);
                j1 = random.Next(mapSize);
                if (flag == true && i1 <= mapSize - k)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (map[i1 + i, j1] != 0)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            map[i1 + i, j1] = number;
                        }
                        if (i1 > 0)
                        {
                            map[i1 - 1, j1] = 3;
                            if(j1> 0)
                            {
                                map[i1 - 1, j1 - 1] = 3;
                            }
                            if (j1 < 9)
                            {
                                map[i1 - 1, j1 + 1] = 3;
                            }

                        }
                        if (i1+k < mapSize)
                        {
                            map[i1 + k, j1] = 3;
                            if (j1 > 0)
                            {
                                map[i1 + k, j1 - 1] = 3;
                            }
                            if (j1 < 9)
                            {
                                map[i1 + k, j1 + 1] = 3;
                            }
                        }
                        if (j1 > 0)
                        {
                            for(int i = 0; i < k; i++)
                            {
                                map[i1 + i, j1 - 1] = 3;
                            }
                        }
                        if (j1 < 9)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                map[i1 + i, j1 + 1] = 3;
                            }
                        }

                        k = 0;
                    }
                }
                else if (flag == false && j1 <= mapSize - k)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (map[i1, j1 + j] != 0)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            map[i1, j1 + j] = number;
                        }
                        if (j1 > 0)
                        {
                           
                                map[i1, j1-1] = 3;
                            if (i1 > 0)
                            {
                               
                                    map[i1 - 1, j1 - 1] = 3;
                            }
                            if (i1 < 9)
                            {
                               
                                    map[i1 + 1, j1 - 1] = 3;
                            }
                        }
                        if (j1+k < mapSize)
                        {
                           
                                map[i1, j1 + k] = 3;
                            if (i1 > 0)
                            {
                                if (map[i1 - 1, j1 + k] == 0)
                                    map[i1 - 1, j1 + k] = 3;
                            }
                            if (i1 < 9)
                            {
                                if (map[i1 + 1, j1 + k] == 0)
                                    map[i1 + 1, j1 + k] = 3;
                            }
                        }
                        if (i1 > 0)
                        {
                            for(int i=0; i<k; i++)
                            {
                                if (map[i1 - 1, j1+i] == 0)
                                    map[i1-1, j1 + i] = 3;
                            }
                        }
                        if (i1 < 9)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                if (map[i1 + 1, j1+i] == 0)
                                    map[i1+1, j1 + i] = 3;
                            }
                        }
                        k = 0;
                    }
                }
            }
        }
        private void GoodShipGeneration(int[,] mas)
        {
            mas[0, 0] = 41;
            mas[0, 1] = 41;
            mas[0, 2] = 41;
            mas[0, 3] = 41;
            mas[0, 5] = 33;
            mas[0, 6] = 33;
            mas[0, 7] = 33;
            mas[0, 9] = 31;
            mas[1, 9] = 31;
            mas[2, 9] = 31;
            mas[2, 0] = 25;
            mas[2, 1] = 25;
            mas[2, 3] = 23;
            mas[2, 4] = 23;
            mas[2, 6] = 21;
            mas[2, 7] = 21;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] == 0)
                        mas[i, j] = 3;
                }
            }
        }
    }
}