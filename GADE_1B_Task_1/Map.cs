using System;

namespace GADE_1B_Task_1
{
    class Map
    {
        //CLASS VARIABLES
        public char[,] arrMap = new char[20, 20];
        public unit[] arrUnits;
        public Building[] arrBuildings;

        int sumUnits;
        int sumBuildings;

        //CLASS CONSTRUCTORS
        public Map(int _sumUnits, int _sumBuildings)
        {
            sumUnits = _sumUnits;
            sumBuildings = _sumBuildings;
        }

        //CLASS METHODS
        public void RandomBattlefield()
        {
            int randomX, randomY;
            int random;
            randomX = 1;
            randomY = 1;

            arrUnits = new unit[sumUnits];
            arrBuildings = new Building[sumBuildings];
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    arrMap[i, k] = ',';

                }

            }

            for (int i = 0; i < sumUnits; i++)
            {


                randomX = rnd.Next(0, 20);
                randomY = rnd.Next(0, 20);

                
                random = rnd.Next(1, 5);

                while (arrMap[randomX, randomY] == 'x' || arrMap[randomX, randomY] == 'X' || arrMap[randomX, randomY] == 'o' || arrMap[randomX, randomY] == 'O')
                {

                    randomX = rnd.Next(0, 20);
                    randomY = rnd.Next(0, 20);

                }

                if (random == 1)
                {


                    MeleeUnit unit = new MeleeUnit("Knight", randomX, randomY, 100, 1, 5, 1, "Team1", 'X', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;

                }
                else if (random == 2)
                {
                    MeleeUnit unit = new MeleeUnit("Knight", randomX, randomY, 100, 1, 5, 1, "Team2", 'x', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else if (random == 3)
                {
                    RangedUnit unit = new RangedUnit("Archer", randomX, randomY, 80, 1, 3, 3, "Team1", 'O', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else
                {
                    RangedUnit unit = new RangedUnit("Archer", randomX, randomY, 80, 1, 3, 3, "Team2", 'o', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
            }

            for (int k = 0; k < sumBuildings; k++)
            {

                randomX = rnd.Next(0, 20);
                randomY = rnd.Next(0, 20);

                while (arrMap[randomX, randomY] == 'x' || arrMap[randomX, randomY] == 'X' || arrMap[randomX, randomY] == 'o' || arrMap[randomX, randomY] == 'O')
                {

                    randomX = rnd.Next(0, 20);
                    randomY = rnd.Next(0, 20);

                }

                random = rnd.Next(1, 7);

                int spawnYPos;
                spawnYPos = 0;

                if (randomY == 19)
                {
                    spawnYPos = 18;
                }
                else if (randomY == 0)
                {
                    spawnYPos = 1;
                }
                else
                {
                    spawnYPos = randomY - 1;
                }

                if (random == 1)
                {


                    ResourceBuilding building = new ResourceBuilding(randomX, randomY, 200, "Team1", 'R', "Tiberuim", 0, 5, 2000);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;

                }
                else if (random == 2)
                {
                    ResourceBuilding building = new ResourceBuilding(randomX, randomY, 200, "Team2", 'R', "Tiberuim", 0, 5, 2000);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else if (random == 3)
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team1", 'F', "Melee Unit", 10, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else if (random == 4)
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team1", 'F', "Ranged Unit", 10, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else if (random == 5)
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team2", 'F', "Melee Unit", 10, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team2", 'F', "Ranged  Unit", 10, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
               
            }
        }

        public string MapDisplay()
        {
            string mapString;
            mapString = " ";

            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    mapString = mapString + arrMap[i, k];
                }
                mapString += "\n";

            }



            return mapString;

        }

        public void MapUpdate(unit unitMove, int xOld, int yOld)
        {

            arrMap[xOld, yOld] = ',';

            arrMap[unitMove.xPos, unitMove.yPos] = unitMove.symbol;


        }





    }
}
