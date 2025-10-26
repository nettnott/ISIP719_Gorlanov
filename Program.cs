using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

public class Weapon
{
    public  Random Rand = new Random();
    public int atk { get; set; }
    public string name { get; set; }
    string[] strings = { "Cocherga deada", "Oreshnik", "Spidoznaya igolka", "Otcislenie" };
    public Weapon()
    {
        name = strings[Rand.Next(0,4)];
        atk = Convert.ToInt32(Rand.Next(3, 75));
    }
    public override string ToString()
    {
        return $"{name} (АТК: {atk})";
    }
}
public class Equipment
{
    public Random Rand = new Random();
    public int def { get; set; }
    public string name { get; set; }
    string[] strings = { "Trusi deada", "Lapti", "Futbolka 'lubluy emo'", "Kstum s pohoron" };
    public Equipment()
    {
        name = strings[Rand.Next(0, 4)];
        def = Convert.ToInt32(Rand.Next(3, 75));
    }
    public override string ToString()
    {
        return $"{name} (DEF: {def})";
    }
}

public class Player
{
    public int hp;
    public int maxHp;
    public bool debuff = false;
    public int def;
    public int atk;
    public Weapon Weapon { get; set; }
    public Equipment Equipment { get; set; }
    public bool IsDefending { get; set; }
    public Player(int hp, int def, int atk)
    {
        this.maxHp = hp;
        this.hp = hp;
        this.def = def;
        this.atk = atk;
        Weapon = new Weapon();
        Equipment = new Equipment();
        UpdateStats();
    }
    public Random Rand = new Random();
    public virtual void Attack(Enemy enemy)
    {
        int udar = Convert.ToInt32(Rand.Next(3, atk));
        enemy.hp -= udar;
        Console.WriteLine($"woah! u have dealt {udar} damage!");
    }
    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine("u`ve got ready to defend!");
    }
    public void Heal()
    {
        hp = maxHp;
        Console.WriteLine("fully healed!");
    }

    public void UpdateStats()
    {
        atk = Weapon.atk;
        def = Equipment.def;
    }
    public void TakeDamage(int damage)
    {
        if (IsDefending)
        {
            if (Rand.NextDouble() < 0.4)
            {
                Console.WriteLine("Ыгссуыыагддн вуаутвув!");
                IsDefending = false;
                return;
            }

            double blockPercent = 0.7 + (Rand.NextDouble() * 0.3);
            damage = (int)(damage * (1 - blockPercent));
            Console.WriteLine($"u`ve dodged that punch! Now damage is {damage}.");
            IsDefending = false;
        }

        hp -= damage;
        if (hp < 0) hp = 0;
    }

    public string GetStatus()
    {
        return $"HP: {hp}/{maxHp} | Weapon: {Weapon} | Equipment: {Equipment}";
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

        player.hp -= damage-player.def;
        player.def -= damage;
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
    public override void attack(Player player)
    {
        int damage = Convert.ToInt32(Rand.Next(3, atk));
        player.hp -= damage;
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

    double freezeChance = 0.2;
    public override void attack(Player player)
    {
        bool isFrozen = Rand.NextDouble() < freezeChance;
        int damage = Convert.ToInt32(Rand.Next(3, atk));

        if (isFrozen)
        {
            player.debuff = true;
            Console.WriteLine("Zamorojeno!");
        }

        player.hp -= damage - player.def;
        player.def -= damage;
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

        } while (player.hp >= 0); 
    }
}
