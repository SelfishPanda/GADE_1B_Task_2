using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_1B_Task_1
{
    class GameEngine
    {
        public int gameRounds;
        unit[] arrUnits;
        public Map map ;
        public string OutputString, buildingOutput;
        Form1 form = new Form1();

        public GameEngine()
        {
            map = new Map(2,4);
           
            this.arrUnits = map.arrUnits;
                gameRounds = 0;
            
           
        }


        //Direction in wich to move
        public string Direction(unit Main, unit Enemy)
        {
            string ReturnVal;
            ReturnVal = " ";



            int xTotal, yTotal;
            string xDirection, yDirection;
            xTotal = 0;
            yTotal = 0;
            xDirection = "";
            yDirection = "";

            xTotal = Main.xPos - Enemy.xPos;
            yTotal = Main.yPos - Enemy.yPos;

            
            
                if (xTotal > 0)
                {
                    xDirection = "left";
                }
                else if (xTotal < 0)
                {
                    xDirection = "right";
                }
            
            
            
                if (yTotal < 0)
                {
                    yDirection = "down";
                }
                else if (yTotal > 0)
                {
                    yDirection = "up";
                }
            
                    xTotal = Math.Abs(Main.xPos - Enemy.xPos);
                    yTotal = Math.Abs(Main.yPos - Enemy.yPos);
                    
            if (xTotal >= yTotal && xTotal>0)
            {
                ReturnVal = xDirection;
                return xDirection;
                
            }
            else
            {
                ReturnVal = yDirection;
                return yDirection;
                
            }              	
        }





        //
        public void GameLogic(unit[] arrUnits)
        {
            
            gameRounds++;
            Random rnd = new Random();
            bool death;
            string direction;
            direction = " ";
            
            death = false;
            
            OutputString = "";
            for (int i = 0; i < arrUnits.Length; i++)
            {
               

               
                   

                    death = arrUnits[i].Death();
                    if (death == true)
                    { arrUnits[i].HP = 0; }
                    else
                    {

                        unit closestunit;
                        closestunit = arrUnits[i].ClosestUnit(arrUnits);
                        if (arrUnits[i] == closestunit)
                        { }
                        else
                        {

                            arrUnits[i].AttackRange(closestunit);
                            if (arrUnits[i].HP<= (arrUnits[i].maxHP*0.25))
                            {
                                string randomDirection;
                                int random;

                                random = rnd.Next(1, 5);

                                if (random == 1)
                                {
                                    randomDirection = "left";
                                }
                                else if (random == 2)
                                {
                                    randomDirection = "right";
                                }
                                else if (random == 3)
                                {
                                    randomDirection = "up";
                                }
                                else
                                {
                                    randomDirection = "down";
                                }

                                arrUnits[i].Move(randomDirection);

                            arrUnits[i].HP += 2;
                            }
                            else
                            {


                                if (arrUnits[i].isAttacking == true)
                                {
                                    arrUnits[i].Combat(closestunit);
                                }
                                else
                                {
                                    int oldX, oldY;
                                    oldX = arrUnits[i].xPos;
                                    oldY = arrUnits[i].yPos;
                                    direction = Direction(arrUnits[i], closestunit);
                                    arrUnits[i].Move(direction);
                                    map.MapUpdate(arrUnits[i], oldX,oldY);
                                    
                                }
                            }

                        }
                    }
                    OutputString += "\n" + arrUnits[i].ToString();
                
                

                OutputString += "\n";

            }

            buildingOutput = " ";

            for (int i = 0; i < map.arrBuildings.Length; i++)
            {
                string buildingType = map.arrBuildings[i].GetType().ToString();
                string[] buildingArr = buildingType.Split('.');
                buildingType = buildingArr[buildingArr.Length - 1];


                if (buildingType == "ResourceBuilding")
                {

                    ResourceBuilding building = (ResourceBuilding)map.arrBuildings[i];
                    if (building.Death() == true)
                    { }
                    else
                    {
                        building.ResourceManagement();
                    }
                   
                }
                else if (buildingType == "FactoryBuilding")
                {
                    FactoryBuilding building = (FactoryBuilding)map.arrBuildings[i];

                    if (building.Death() == true)
                    { }
                    else
                    {
                        if ((gameRounds % building.productionSpeed) == 0)
                        {

                            Array.Resize(ref arrUnits, arrUnits.Length + 1); ;
                            arrUnits[arrUnits.Length-1] = building.CreateUnit();
                        }

                    }
                    

                }
                buildingOutput += "\n" + map.arrBuildings[i].toString();
                buildingOutput += "\n";
            }
            

            
        }

    }
}
