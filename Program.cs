using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

class Weapon
{
    public  Random Rand = new Random();
    int atk { get; set; }
    string name { get; set; }
    string[] strings = { "Cocherga deada", "Oreshnik", "Spidoznaya igolka", "Otcislenie" };
    public Weapon()
    {
        name = strings[Rand.Next(0,4)];
        atk = Convert.ToInt32(Rand.Next(3, 75));
    }
}
class equipment
{
    public Random Rand = new Random();
    int def { get; set; }
    string name { get; set; }
    string[] strings = { "Trusi deada", "Lapti", "Futbolka 'lubluy emo'", "Kstum s pohoron" };
    public equipment()
    {
        name = strings[Rand.Next(0, 4)];
        def = Convert.ToInt32(Rand.Next(3, 75));
    }
}

public class Player
{
    public int hp;
    public bool debuff = false;
    public int def;
    public int atk;
    Weapon Weapon { get; set; }
    equipment equipment { get; set; }
    public Player(int hp, int def, int atk)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
    }
    public Random Rand = new Random();
    public virtual void attack(Enemy enemy)
    {
        int udar = Convert.ToInt32(Rand.Next(3, atk));
        enemy.hp -= udar;
    }
}
/* подо мной м5 асфальт 8 у нее биркин цвета осень она закурит но я бросил*/

public class Enemy
{
    public int hp;
    public int atk;
    public int def;
    public Enemy(int hp, int def, int atk)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
    }
    public Random Rand = new Random();
    public virtual void attack(Player player)
    {
        int udar = Convert.ToInt32(Rand.Next(3, atk));
        player.hp -= udar;
    }
}

public class Goblin : Enemy
{
    //имеет шанс нанести критический урон
    public Goblin(int hp, int def, int atk) :base(hp, def, atk)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
    }

    double critChance = 0.2;
    public override void attack(Player player)
    {
        bool isCrit = Rand.NextDouble() < critChance;
        int damage = Convert.ToInt32(Rand.Next(3, atk));

        if (isCrit)
        {
            damage = (int)(damage * 1.5);
            Console.WriteLine("Crit hit!");
        }

        player.hp -= damage;
    }

}

public class Skelet : Enemy
{
    //игнорирует защиту игрока.
    public Skelet(int hp, int def, int atk) : base(hp, def, atk)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
    }

}

public class Mag : Enemy
{
    //имеет шанс наложить «заморозку» (игрок пропускает следующий ход).
    public Mag(int hp, int def, int atk) : base(hp, def, atk)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
    }
}

//public class Items
//{
//    public void take() { }

//    public void tossaway() { }

//    public void chest()
//    {

//    }
//}

public class gaym
{
    int hod;
    public  Player player = new Player(100, 1, 5);
    public void start() {
        do
        {

        } while (player.hp <= 0); 
    }
}
