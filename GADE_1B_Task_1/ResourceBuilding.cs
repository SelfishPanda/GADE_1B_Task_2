using System;

class ResourceBuilding : Building
{
    public int XPos { get { return base.xPos; } set { base.xPos = value; } }
    public int YPos { get { return base.yPos; } set { base.yPos = value; } }
    public int hP { get { return base.HP; } set { base.HP = value; } }
    public int MaxHP { get { return base.maxHP; } }
    public string Team { get { return base.team; } }
    public char Symbol { get { return base.symbol; } }

    public string resourceType { get; }
    public int resourcesGenerated { get; set; }
    public int resourcesGeneratedPerRound { get;}
    public int resourcePool { get; set; }


    public ResourceBuilding(int _xPos, int _yPos, int _HP, string _team, char _symbol, string _resourceType, int _resourcesGenerated, int _resourcesGeneratedPerRound, int _resourcePool): base(_xPos,_yPos,_HP,_team,_symbol)
    {
        resourceType = _resourceType;
        resourcesGenerated = _resourcesGenerated;
        resourcesGeneratedPerRound = _resourcesGeneratedPerRound;
        resourcePool = _resourcePool;
    }

    public override bool Death()
    {
        bool death;
        death = false;

        if (HP <= 0)
        {
            death = true;
        }

        return death;
        
    }
    public override string toString()
    {
        string output = "";
        output = "Resource Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos + "\n"+ "Resources Generated :"+this.resourcesGenerated + "\n"+"Resources Left in Pool :"+ this.resourcePool;
        return output;
    }

    public void ResourceManagement()
    {
        resourcePool -= resourcesGeneratedPerRound;
        resourcesGenerated += resourcesGeneratedPerRound;
    }
}
