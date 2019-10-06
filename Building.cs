using System;

public abstract class Building
{
    int xPos;
    int yPos;
    int HP;
    int maxHP;
    string team;
    char symbol;

    public  Building(int _xPos, int _yPos, int _HP, string _team, char _symbol)
	{
        xPos = _xPos;
        yPos = _yPos;
        HP = _HP;
        maxHP = HP;
        maxHP = _maxHP;
        team = _team;
        symbol = _symbol;

	}
    public abstract Death();
    public string toString();
}
