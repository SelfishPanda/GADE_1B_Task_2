using System;

namespace GADE_1B_Task_1
{
    class MeleeUnit : unit
    {




        //CLASS CONSTRUCTORS
        public MeleeUnit(string _unitName,int _xPos, int _yPos, int _HP, int _speed, int _attack, int _attackRange, string _team, char _symbol, bool _isAttacking) : base(_unitName, _xPos, _yPos, _HP, _speed, _attack, _attackRange, _team, _symbol, _isAttacking)
        {

        }

        
        
        public override string ToString()
        { 
            string output = "";
            output = "Melee Unit (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos;
            return output;
        }
    }


    
}
