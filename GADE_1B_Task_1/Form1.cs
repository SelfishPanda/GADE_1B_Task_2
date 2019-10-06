using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GADE_1B_Task_1
{
    public partial class Form1 : Form
    {
        public bool load;
        GameEngine gameEngine;
        public Form1()
        {
            
            InitializeComponent();
            




        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            int timer;
            gameEngine.GameLogic(gameEngine.map.arrUnits);
            lblMap.Text = gameEngine.map.MapDisplay();     
            timer = (gameEngine.gameRounds);
            rtxtInfo.Text = gameEngine.OutputString;
            rtxtBuildingInfo.Text = gameEngine.buildingOutput;
            lblTimer.Text = Convert.ToString(timer);
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameEngine = new GameEngine();
            load = false;
            gameEngine.map.RandomBattlefield();
            lblMap.Text = gameEngine.map.MapDisplay();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveString;

           


            saveString = "";

            Directory.CreateDirectory("Saves");
            Directory.CreateDirectory("Saves/Units");
            Directory.CreateDirectory("Saves/Buildings");

            FileStream ufs = new FileStream("Saves/Units/units", FileMode.Create, FileAccess.Write);
            FileStream bfs = new FileStream("Saves/Buildings/buildings", FileMode.Create, FileAccess.Write);

            StreamWriter uwriter = new StreamWriter(ufs);
            for (int i = 0; i < gameEngine.map.arrUnits.Length; i++)
            {
                saveString = (gameEngine.map.arrUnits[i].symbol+","+ gameEngine.map.arrUnits[i].xPos+","+ gameEngine.map.arrUnits[i].yPos+","+ gameEngine.map.arrUnits[i].maxHP+","+ gameEngine.map.arrUnits[i].HP+","+ gameEngine.map.arrUnits[i].unitName+","+ gameEngine.map.arrUnits[i].team+","+ gameEngine.map.arrUnits[i].speed+","+ gameEngine.map.arrUnits[i].isAttacking+","+ gameEngine.map.arrUnits[i].attack+","+ gameEngine.map.arrUnits[i].attackRange);
                uwriter.WriteLine(saveString);
            }
            uwriter.Close();
            

            saveString = "";

            StreamWriter bwriter = new StreamWriter(bfs);
            for (int i = 0; i < gameEngine.map.arrBuildings.Length; i++)
            {
                string buildingType = gameEngine.map.arrBuildings[i].GetType().ToString();
                string[] buildingArr = buildingType.Split('.');
                buildingType = buildingArr[buildingArr.Length - 1];

                if (buildingType == "ResourceBuilding")
                {
                    ResourceBuilding bld = (ResourceBuilding)gameEngine.map.arrBuildings[i];
                    saveString = (bld.Symbol+","+bld.XPos+","+bld.YPos+","+bld.Team+","+bld.MaxHP+","+bld.hP+","+bld.resourceType+","+bld.resourcesGeneratedPerRound+","+bld.resourcesGenerated+","+bld.resourcePool);
                }
                else
                {
                    FactoryBuilding bld = (FactoryBuilding)gameEngine.map.arrBuildings[i];
                    saveString = (bld.Symbol + "," + bld.XPos + "," + bld.YPos + "," + bld.Team + "," + bld.MaxHP + "," + bld.hP + "," + bld.productionSpeed+","+bld.spawnYPos+","+bld.unitToProduce+","+bld.unitsProduced);
                }
                bwriter.WriteLine(saveString);
            }
            bwriter.Close();

            ufs.Close();
            bfs.Close();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load = true;
            int count;

            FileStream ufs = new FileStream("Saves/Units/units", FileMode.Open, FileAccess.Read);
            FileStream bfs = new FileStream("Saves/Buildings/buildings", FileMode.Open, FileAccess.Read);

            StreamReader usr = new StreamReader(ufs);
            StreamReader bsr = new StreamReader(bfs);

            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    gameEngine.map.arrMap[i, k] = ',';

                }

            }

            count = File.ReadAllLines("Saves/Units/units").Length;
            gameEngine.map.arrUnits = new unit[count];
            for (int i = 0; i < count; i++)
            {
                string line = usr.ReadLine();
               

                

                string[] arrline = line.Split(',');  
                
                    char uSymbol = Convert.ToChar(arrline[0]);
                    int x = Convert.ToInt32(arrline[1]);
                    int y = Convert.ToInt32(arrline[2]);
                    int Maxhp = Convert.ToInt32(arrline[3]);
                    int HP = Convert.ToInt32(arrline[4]);
                    string Name = (arrline[5]);
                    string Team = (arrline[6]);
                    int Speed = Convert.ToInt32(arrline[7]);
                    bool IsAttacking = Convert.ToBoolean(arrline[8]);
                    int Attack = Convert.ToInt32(arrline[9]);
                    int AttackRange = Convert.ToInt32(arrline[10]);
                

                if (uSymbol == 'x' || uSymbol == 'X')
                {
                    MeleeUnit un = new MeleeUnit(Name, x, y, HP, Speed, Attack, AttackRange, Team, uSymbol, IsAttacking);
                    gameEngine.map.arrUnits[i] = un;
                    gameEngine.map.arrMap[un.xPos, un.yPos] = un.symbol;
                }
                else
                {
                    RangedUnit un = new RangedUnit(Name, x, y, HP, Speed, Attack, AttackRange, Team, uSymbol, IsAttacking);
                    gameEngine.map.arrUnits[i] = un;
                    gameEngine.map.arrMap[un.xPos, un.yPos] = un.symbol;
                }
            }

            ufs.Close();
            usr.Close();

            count = File.ReadAllLines("Saves/Buildings/buildings").Length;
            gameEngine.map.arrBuildings = new Building[count];
            for (int i = 0; i < count; i++)
            {
                string line = bsr.ReadLine();
               



                string[] arrline = line.Split(',');

                char bSymbol = Convert.ToChar(arrline[0]);
                int x = Convert.ToInt32(arrline[1]);
                int y = Convert.ToInt32(arrline[2]);
                string team = (arrline[3]);
                int maxHP = Convert.ToInt32(arrline[4]);
                int HP = Convert.ToInt32(arrline[5]);
               

                if (bSymbol == 'F')
                {
                    int Production = Convert.ToInt32(arrline[6]);
                    int Yspawn = Convert.ToInt32(arrline[7]);
                    string UnitProduction = (arrline[8]);
                    int unitsProduced = Convert.ToInt32(arrline[9]);

                    FactoryBuilding bld = new FactoryBuilding(x, y, HP, team, bSymbol, UnitProduction, Production, Yspawn);
                    gameEngine.map.arrBuildings[i] = bld;
                    gameEngine.map.arrMap[bld.XPos, bld.YPos] = bld.Symbol;
                }
                else
                {
                    string Resource = (arrline[6]);
                    int GatheringRate = Convert.ToInt32(arrline[7]);
                    int Gathered = Convert.ToInt32(arrline[8]);
                    int ResourcePool = Convert.ToInt32(arrline[9]);

                    ResourceBuilding bld = new ResourceBuilding(x, y, HP, team, bSymbol,Resource,Gathered,GatheringRate,ResourcePool);
                    gameEngine.map.arrBuildings[i] = bld;
                    gameEngine.map.arrMap[bld.XPos, bld.YPos] = bld.Symbol;
                }

                
            }
            bfs.Close();
            bsr.Close();
            lblMap.Text = gameEngine.map.MapDisplay();
            timer1.Start();
        }
    }
}
