using System;
namespace GADE_1B_Task_1
{
    abstract class unit
    {
        //CLASS VARIABLES
        

        public int xPos { get; set; }
        public int yPos { get; set;}
        public int HP { get; set; }
        public int maxHP { get; }
        public int speed { get; }
        public int attack { get; }
        public int attackRange { get; }
        public string team { get; }
        public char symbol { get; }
        public bool isAttacking { get; set; }
        public string unitName { get; set; }


        //CLASS CONSTRUCTORS
        public  unit(string _unitName, int _xPos, int _yPos, int _HP, int _speed, int _attack, int _attackRange, string _team, char _symbol, bool _isAttacking)
        {           
            xPos = _xPos;
            yPos = _yPos;
            HP = _HP;
            maxHP = HP;
            speed = _speed;
            attack = _attack;
            attackRange = _attackRange;
            team = _team;
            symbol = _symbol;
            isAttacking = _isAttacking;
            unitName = _unitName;
        }


        //CLASS METHODS
        public virtual void Move(string direction)
        {

            if (direction == "up")
            {
                if (this.yPos > 0)
                {
                    this.yPos = this.yPos - 1;
                }

            }
            if (direction == "down")
            {
                if (this.yPos < 19)
                {
                    this.yPos = this.yPos + 1;
                }

            }
            if (direction == "left")
            {
                if (this.xPos > 0)
                {
                    this.xPos = this.xPos - 1;
                }

            }
            if (direction == "right")
            {
                if (this.xPos < 19)
                {
                    this.xPos = this.xPos + 1;
                }

            }
        }


        //
        public virtual void Combat(unit Enemy)
        {
            if (Enemy.Death())
            {

            }
            else if (isAttacking == true)
            {
              

                    Enemy.HP = Enemy.HP - this.attack;
               
            }
        }


        //
        public virtual void AttackRange(unit Enemy)
        {
            int totalDist;


                totalDist = Math.Abs(this.xPos - Enemy.xPos) + Math.Abs(this.yPos - Enemy.yPos);
                if (totalDist <= this.attackRange)
                {
                    this.isAttacking = true;
                }
                else
                {
                    this.isAttacking = false;
                }     
        }



        //
        public virtual unit ClosestUnit(unit[] units)
        {
            int xDist, yDist, totalDist, closestDist, checkValue;
            unit closestUnit, thisUnit;
            closestDist = 999;
            closestUnit = units[1];
            checkValue = 69;
            thisUnit = units[1];

            for (int i = 0; i < units.Length; i++)
            {

                if (!units[i].Death())
                {
                    if (this.team == units[i].team)
                    {


                    }
                    else if (this.xPos == units[i].xPos && this.yPos == units[i].yPos)
                    {

                        thisUnit = units[i];

                    }
                    else
                    {
                        xDist = Math.Abs(this.xPos - units[i].xPos);
                        yDist = Math.Abs(this.yPos - units[i].yPos);
                        totalDist = xDist + yDist;

                        if (totalDist < closestDist)
                        {
                            closestDist = totalDist;
                            closestUnit = units[i];
                            checkValue = 42;
                        }
                    }
                }

            }

            if (checkValue == 69)
            {
                return thisUnit;
            }
            else
            {
                return closestUnit;
            }
        
            
        
        }


        //
        public virtual  bool Death()
        {
            bool dead;

            if (this.HP <= 0)
            {
                dead = true;
            }
            else
            {
                dead = false;
            }

            return dead;
        }
        //
        public abstract string ToString();
        
           
    }


}

