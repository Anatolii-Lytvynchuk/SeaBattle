using SeaBattle.Kod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class Form1 : Form
    {
        private const int mapSize = 10;
        private int[,] myMap = new int[mapSize, mapSize];
        private int[,] enemyMap = new int[mapSize, mapSize];
        private Button[,] myButtonMap;
        private Button[,] enemyButtonMap;
        private CheckForVictiryAndDefeat check;
       private NormalBot1 easuBot;

        public Form1()
        {
            InitializeComponent();
            CreateMaps();
            CreateButtonMaps();
            PrintMyMap();
        }

        private void PrintMyMap()
        {
            for(int i = 0; i < mapSize; i++)
            {
                for(int j = 0; j < mapSize; j++)
                {
                    if (myMap[i, j] == 0)
                        myButtonMap[i, j].BackColor = Color.Blue;
                    else
                        myButtonMap[i, j].BackColor = Color.Orange;
                }
            }
        }

        private void CreateMaps()
        {
            GenerationMaps generationMaps = new GenerationMaps();
            generationMaps.FillingWithShipsSeparatety(myMap, mapSize);
            generationMaps.FillingWithShipsSeparatety(enemyMap, mapSize);
            check = new CheckForVictiryAndDefeat(myMap, enemyMap,mapSize);
            easuBot = new NormalBot1(myMap, mapSize);
        }

        private void CreateButtonMaps()
        {
            myButtonMap = new Button[mapSize, mapSize]{{button1,button2,button3,button4,button5,button6,button7,button8,button9,button10},
                {button11,button12,button13,button14,button15,button16,button17,button18,button19,button20},
                {button21,button22,button23,button24,button25,button26,button27,button28,button29,button30 },
                {button31,button32,button33,button34,button35,button36,button37,button38,button39,button40 },
                {button41,button42,button43,button44,button45,button46,button47,button48,button49,button50 },
                {button51,button52,button53,button54,button55,button56,button57,button58,button59,button60 },
                {button61,button62,button63,button64,button65,button66,button67,button68,button69,button70 },
                {button71,button72,button73,button74,button75,button76,button77,button78,button79,button80 },
                {button81,button82,button83,button84,button85,button86,button87,button88,button89,button90 },
                {button91,button92,button93,button94,button95,button96,button97,button98,button99,button100 }
            };
            enemyButtonMap = new Button[mapSize, mapSize] {{ button200, button199, button198, button197, button196, button195, button194, button193, button192, button191 },
            { button190, button189, button188, button187, button186, button185, button184, button183, button182, button181},
            { button180, button179, button178, button177, button176, button175, button174, button173, button172, button171},
            { button170, button169, button168, button167, button166, button165, button164, button163, button162, button161},
            { button160, button159, button158, button157, button156, button155, button154, button153, button152, button151},
            { button150, button149, button148, button147, button146, button145, button144, button143, button142, button141},
            { button140, button139, button138, button137, button136, button135, button134, button133, button132, button131},
            { button130, button129, button128, button127, button126, button125, button124, button123, button122, button121},
            { button120, button119, button118, button117, button116, button115, button114, button113, button112, button111},
            { button110, button109, button108, button107, button106, button105, button104, button103, button102, button101}
            };

        }
      


        private void SearchButton(int i,int j){
            if (enemyButtonMap[i, j].BackColor != Color.White)
            {
                return;
            }
            else if (enemyMap[i, j] == 0)
            {
                enemyButtonMap[i, j].BackColor = Color.Blue;
            }
            else
            {
                enemyButtonMap[i, j].BackColor = Color.DarkRed;
                enemyMap[i, j]++;
                SearchForDestroyShipsHorizontal(enemyMap,enemyButtonMap);
                SearchForDestroyShipsVertical(enemyMap,enemyButtonMap);
            }
            Check();
            logicBot();
        }

        private void logicBot()
        {
           easuBot.Logic();
            for(int i = 0; i < mapSize; i++)
            {
                for(int j=0;j< mapSize; j++)
                {
                    if(myMap[i,j] == 1)
                    {
                        myButtonMap[i, j].BackColor = Color.BlueViolet ;
                    }
                    else if (myMap[i,j]!=0 && myMap[i, j] % 2 == 0)
                    {
                        myButtonMap[i,j].BackColor=Color.DarkRed;
                    }
                }
            }
           if(SearchForDestroyShipsHorizontal(myMap,myButtonMap)|| SearchForDestroyShipsVertical(myMap, myButtonMap))
            {
                easuBot.Clear();
                Check();
            }
        }

        private bool SearchForDestroyShipsHorizontal(int[,]map, Button[,] buttons)
        {
            int quantity = 0, a, b = 0;//indexI,IndexY;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i,j]!=0 && map[i,j] % 2 == 0)
                    {
                        a = map[i, j];
                        if (quantity == 0)
                        {
                            b = a;
                            quantity++;
                        }
                        else if (a == b)
                        {
                            quantity++;
                        }
                        else
                        {
                            b = a;
                            quantity = 1;
                        }
                    }
                    if (quantity>0 && quantity == b / 10)
                    {
                        DestroyShips(b,map,buttons);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SearchForDestroyShipsVertical(int[,] map, Button[,]buttons)
        {
            int quantity = 0, a, b = 0;//indexI,IndexY;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[j, i] != 0 && map[j, i] % 2 == 0)
                    {
                        a = map[j, i];
                        if (quantity == 0)
                        {
                            b = a;
                            quantity++;
                        }
                        else if (a == b)
                        {
                            quantity++;
                        }
                        else
                        {
                            b = a;
                            quantity = 1;
                        }
                    }
                    if (quantity>0 && quantity == b / 10)
                    {
                        DestroyShips(b, map,buttons);
                        return true;
                    }
                }
            }
            return false;

        }

        private void DestroyShips(int b, int[,]map,Button[,]buttons)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == b)
                    {
                        map[i, j] = 0;
                        buttons[i, j].BackColor = Color.Black;
                    }
                }
            }
        }

        private void Check()
        {
            if (check.CheckForVictory())
            {
                WinPlayerVsBot win = new WinPlayerVsBot();
                Hide();
                win.ShowDialog();
                Close();
            }
            else if (check.CheckForDefeat())
            {
                LosPlayerVsBot los = new LosPlayerVsBot();
                Hide();
                los.ShowDialog();
                Close();
            }
        }

        private void button200_Click(object sender, EventArgs e)
        {
            SearchButton(0,0);
        }

        private void button199_Click(object sender, EventArgs e)
        {
            SearchButton(0,1);
        }

        private void button198_Click(object sender, EventArgs e)
        {
            SearchButton(0,2);
        }

        private void button197_Click(object sender, EventArgs e)
        {
            SearchButton(0,3);
        }

        private void button196_Click(object sender, EventArgs e)
        {
            SearchButton(0,4);
        }

        private void button195_Click(object sender, EventArgs e)
        {
            SearchButton(0,5);
        }

        private void button194_Click(object sender, EventArgs e)
        {
            SearchButton(0,6);
        }

        private void button193_Click(object sender, EventArgs e)
        {
            SearchButton(0,7);
        }

        private void button192_Click(object sender, EventArgs e)
        {
            SearchButton(0,8);
        }

        private void button191_Click(object sender, EventArgs e)
        {
            SearchButton(0,9);
        }

        private void button190_Click(object sender, EventArgs e)
        {
            SearchButton(1,0);
        }

        private void button189_Click(object sender, EventArgs e)
        {
            SearchButton(1,1);
        }

        private void button188_Click(object sender, EventArgs e)
        {
            SearchButton(1,2);
        }

        private void button187_Click(object sender, EventArgs e)
        {
            SearchButton(1,3);
        }

        private void button186_Click(object sender, EventArgs e)
        {
            SearchButton(1,4);
        }

        private void button185_Click(object sender, EventArgs e)
        {
            SearchButton(1,5);
        }

        private void button184_Click(object sender, EventArgs e)
        {
            SearchButton(1,6);
        }

        private void button183_Click(object sender, EventArgs e)
        {
            SearchButton(1,7);
        }

        private void button182_Click(object sender, EventArgs e)
        {
            SearchButton(1,8);
        }

        private void button181_Click(object sender, EventArgs e)
        {
            SearchButton(1,9);
        }

        private void button180_Click(object sender, EventArgs e)
        {
            SearchButton(2,0);
        }

        private void button179_Click(object sender, EventArgs e)
        {
            SearchButton(2,1);
        }

        private void button178_Click(object sender, EventArgs e)
        {
            SearchButton(2,2);
        }

        private void button177_Click(object sender, EventArgs e)
        {
            SearchButton(2,3);
        }

        private void button176_Click(object sender, EventArgs e)
        {
            SearchButton(2,4);
        }

        private void button175_Click(object sender, EventArgs e)
        {
            SearchButton(2,5);
        }

        private void button174_Click(object sender, EventArgs e)
        {
            SearchButton(2,6);
        }

        private void button173_Click(object sender, EventArgs e)
        {
            SearchButton(2,7);
        }

        private void button172_Click(object sender, EventArgs e)
        {
            SearchButton(2,8);
        }

        private void button171_Click(object sender, EventArgs e)
        {
            SearchButton(2,9);
        }

        private void button170_Click(object sender, EventArgs e)
        {
            SearchButton(3,0);
        }

        private void button169_Click(object sender, EventArgs e)
        {
            SearchButton(3,1);
        }

        private void button168_Click(object sender, EventArgs e)
        {
            SearchButton(3,2);
        }

        private void button167_Click(object sender, EventArgs e)
        {
            SearchButton(3,3);
        }

        private void button166_Click(object sender, EventArgs e)
        {
            SearchButton(3,4);
        }

        private void button165_Click(object sender, EventArgs e)
        {
            SearchButton(3,5);
        }

        private void button164_Click(object sender, EventArgs e)
        {
            SearchButton(3,6);
        }

        private void button163_Click(object sender, EventArgs e)
        {
            SearchButton(3,7);
        }

        private void button162_Click(object sender, EventArgs e)
        {
            SearchButton(3,8);
        }

        private void button161_Click(object sender, EventArgs e)
        {
            SearchButton(3,9);
        }

        private void button160_Click(object sender, EventArgs e)
        {
            SearchButton(4,0);
        }

        private void button159_Click(object sender, EventArgs e)
        {
            SearchButton(4,1);
        }

        private void button158_Click(object sender, EventArgs e)
        {
            SearchButton(4,2);
        }

        private void button157_Click(object sender, EventArgs e)
        {
            SearchButton(4,3);
        }

        private void button156_Click(object sender, EventArgs e)
        {
            SearchButton(4,4);
        }

        private void button155_Click(object sender, EventArgs e)
        {
            SearchButton(4,5);
        }

        private void button154_Click(object sender, EventArgs e)
        {
            SearchButton(4,6);
        }

        private void button153_Click(object sender, EventArgs e)
        {
            SearchButton(4,7);
        }

        private void button152_Click(object sender, EventArgs e)
        {
            SearchButton(4,8);
        }

        private void button151_Click(object sender, EventArgs e)
        {
            SearchButton(4,9);
        }

        private void button150_Click(object sender, EventArgs e)
        {
            SearchButton(5,0);
        }

        private void button149_Click(object sender, EventArgs e)
        {
            SearchButton(5,1);
        }

        private void button148_Click(object sender, EventArgs e)
        {
            SearchButton(5,2);
        }

        private void button147_Click(object sender, EventArgs e)
        {
            SearchButton(5,3);
        }

        private void button146_Click(object sender, EventArgs e)
        {
            SearchButton(5,4);
        }

        private void button145_Click(object sender, EventArgs e)
        {
            SearchButton(5,5);
        }

        private void button144_Click(object sender, EventArgs e)
        {
            SearchButton(5,6);
        }

        private void button143_Click(object sender, EventArgs e)
        {
            SearchButton(5,7);
        }

        private void button142_Click(object sender, EventArgs e)
        {
            SearchButton(5,8);
        }

        private void button141_Click(object sender, EventArgs e)
        {
            SearchButton(5,9);
        }

        private void button140_Click(object sender, EventArgs e)
        {
            SearchButton(6,0);
        }

        private void button139_Click(object sender, EventArgs e)
        {
            SearchButton(6,1);
        }

        private void button138_Click(object sender, EventArgs e)
        {
            SearchButton(6,2);
        }

        private void button137_Click(object sender, EventArgs e)
        {
            SearchButton(6,3);
        }

        private void button136_Click(object sender, EventArgs e)
        {
            SearchButton(6,4);
        }

        private void button135_Click(object sender, EventArgs e)
        {
            SearchButton(6,5);
        }

        private void button134_Click(object sender, EventArgs e)
        {
            SearchButton(6,6);
        }

        private void button133_Click(object sender, EventArgs e)
        {
            SearchButton(6,7);
        }

        private void button132_Click(object sender, EventArgs e)
        {
            SearchButton(6,8);
        }

        private void button131_Click(object sender, EventArgs e)
        {
            SearchButton(6,9);
        }

        private void button130_Click(object sender, EventArgs e)
        {
            SearchButton(7,0);
        }

        private void button129_Click(object sender, EventArgs e)
        {
            SearchButton(7,1);
        }

        private void button128_Click(object sender, EventArgs e)
        {
            SearchButton(7,2);
        }

        private void button127_Click(object sender, EventArgs e)
        {
            SearchButton(7,3);
        }

        private void button126_Click(object sender, EventArgs e)
        {
            SearchButton(7,4);
        }

        private void button125_Click(object sender, EventArgs e)
        {
            SearchButton(7,5);
        }

        private void button124_Click(object sender, EventArgs e)
        {
            SearchButton(7,6);
        }

        private void button123_Click(object sender, EventArgs e)
        {
            SearchButton(7,7);
        }

        private void button122_Click(object sender, EventArgs e)
        {
            SearchButton(7,8);
        }

        private void button121_Click(object sender, EventArgs e)
        {
            SearchButton(7,9);
        }

        private void button120_Click(object sender, EventArgs e)
        {
            SearchButton(8,0);
        }

        private void button119_Click(object sender, EventArgs e)
        {
            SearchButton(8,1);
        }

        private void button118_Click(object sender, EventArgs e)
        {
            SearchButton(8,2);
        }

        private void button117_Click(object sender, EventArgs e)
        {
            SearchButton(8,3);
        }

        private void button116_Click(object sender, EventArgs e)
        {
            SearchButton(8,4);
        }

        private void button115_Click(object sender, EventArgs e)
        {
            SearchButton(8,5);
        }

        private void button114_Click(object sender, EventArgs e)
        {
            SearchButton(8,6);
        }

        private void button113_Click(object sender, EventArgs e)
        {
            SearchButton(8,7);
        }

        private void button112_Click(object sender, EventArgs e)
        {
            SearchButton(8,8);
        }

        private void button111_Click(object sender, EventArgs e)
        {
            SearchButton(8,9);
        }

        private void button110_Click(object sender, EventArgs e)
        {
            SearchButton(9,0);
        }

        private void button109_Click(object sender, EventArgs e)
        {
            SearchButton(9,1);
        }

        private void button108_Click(object sender, EventArgs e)
        {
            SearchButton(9,2);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            SearchButton(9,3);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            SearchButton(9,4);
        }

        private void button105_Click(object sender, EventArgs e)
        {
            SearchButton(9,5);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            SearchButton(9,6);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            SearchButton(9,7);
        }

        private void button102_Click(object sender, EventArgs e)
        {
            SearchButton(9,8);
        }

        private void button101_Click(object sender, EventArgs e)
        {
            SearchButton(9,9);
        }
    }
}