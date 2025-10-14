using System;

public class gaymer
{
    public int hp = 100;
    public bool debuff = false;
    public int def = 0;
    public int atk = 5;
    public EquipTypes equip;
    public WeaponTypes weapon;

    public enum WeaponTypes { palka, ak, oreshnik};
    if (weapon == WeaponTypes.palka) 
        { 
            atk += 10;
        }
    else if (weapon == WeaponTypes.ak)
        { 
            atk += 30;
        }
    else if (weapon == WeaponTypes.oreshnik)
        { 
            atk += 40;
        }

public enum EquipTypes { perchatki, podkraduli, bdsmcostume };
if (equip == EquipTypes.perchatki)
{
    def += 10;
}
else if (equip == EquipTypes.podkraduli)
{
    def += 30;
}
else if (equip == EquipTypes.bdsmcostume)
{
    def += 40;
}

}

public class enemy
{
    public int hp = 100;
    public int atk;
    public int def = 100;
}

public class goblin : enemy
{
    //имеет шанс нанести критический урон

}

public class skelet : enemy
{
    //игнорирует защиту игрока.
}

public class mag : enemy
{
    //имеет шанс наложить «заморозку» (игрок пропускает следующий ход).
}

public class items
{
    public enum { zelie, weapon, dospeh };

    public void take() { };

    public void tossaway() { };

    public void chest()
    {

    }
}

public class gaym
{
    public void battle() 
    { 
    
    };

}
