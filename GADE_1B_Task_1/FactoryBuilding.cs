using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_1B_Task_1
{
    class FactoryBuilding : Building
    {
        public int XPos { get { return base.xPos; } set { base.xPos = value; } }
        public int YPos { get { return base.yPos; } set { base.yPos = value; } }
        public int hP { get { return base.HP; } set { base.HP = value; } }
        public int MaxHP { get { return base.maxHP; } }
        public string Team { get { return base.team; } }
        public char Symbol { get { return base.symbol; } }

        public string unitToProduce { get;  }
        public int productionSpeed { get;}
        public int spawnYPos { get; }
        public int unitsProduced;

        public FactoryBuilding(int _xPos, int _yPos, int _HP, string _team, char _symbol, string _unitToProduce, int _productionSpeed, int _spawnYPos) : base(_xPos, _yPos, _HP, _team, _symbol)
        {
            unitToProduce = _unitToProduce;
            productionSpeed = _productionSpeed;
            spawnYPos = _spawnYPos;
            unitsProduced = 0;
        }


        public override bool Death()
        {
            bool death;
            death = false;

            if (HP<=0)
            {
                death = true;
            }

            return death;

        }
        public override string toString()
        {
            string output = "";
            output = "Factory Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos + "\n" + "Units Produced :" + this.unitsProduced + "\n" + "Units Being Produced :" + this.unitToProduce;
            return output;

        }

        public unit CreateUnit()
        {
            unitsProduced += 1;
            if (unitToProduce == "Ranged Unit")
            {
                RangedUnit unit = new RangedUnit("Archer", this.xPos, spawnYPos, 80, 1, 3, 1, this.team, 'O', false);
                return unit;
            }
            else
            {
                MeleeUnit unit = new MeleeUnit("Knight", this.xPos, spawnYPos, 100, 1, 5, 1, this.team, 'X', false);
                return unit; 
            }

           
        }
        

        
    }
}
