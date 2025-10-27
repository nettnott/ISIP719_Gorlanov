using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Xml.Linq;
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
    public int maxHp;
    public int atk;
    public int def;
    public string name { get; set; }
    public bool isDefending = false;
    public Enemy(int hp, int def, int atk, string name)
    {
        this.maxHp = hp;
        this.hp = hp;
        this.def = def;
        this.atk = atk;
        this.name = name;
    }
    public Random Rand = new Random();
    public virtual void Attack(Player player)
    {
        int damage = Rand.Next(3, atk);
        player.TakeDamage(damage);
    }

    public virtual string GetInfo()
    {
        return $"{name} (HP: {hp}/{maxHp}, АТК: {atk}, DEF: {def})";
    }
}

public class Goblin : Enemy
{
    //имеет шанс нанести критический урон
    public Goblin(int hp, int def, int atk, string name) :base(hp, def, atk, name)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
        this.name = name;
    }

    double critChance = 0.2;
    public override void Attack(Player player)
    {
        bool isCrit = Rand.NextDouble() < critChance;
        int damage = Convert.ToInt32(Rand.Next(3, atk));

        if (isCrit)
        {
            damage = (int)(damage * 1.5);
            Console.WriteLine("Crit hit!");
        }

        Console.WriteLine($"{name} is attacking!");
        player.TakeDamage(damage);
    }
}

public class Skelet : Enemy
{
    //игнорирует защиту игрока.
    public Skelet(int hp, int def, int atk, string name) : base(hp, def, atk, name)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
        this.name = name;
    }
    public override void Attack(Player player)
    {
        int damage = Rand.Next(3, atk);
        Console.WriteLine($"{name} is aattacking and he don`t give a damn abt ur def!");
        player.hp -= damage;
        if (player.hp < 0) player.hp = 0;
    }
}

public class Mag : Enemy
{
    //имеет шанс наложить «заморозку» (игрок пропускает следующий ход).
    public Mag(int hp, int def, int atk, string name) : base(hp, def, atk, name)
    {
        this.hp = hp;
        this.def = def;
        this.atk = atk;
        this.name = name;
    }

    double freezeChance = 0.2;
    public override void Attack(Player player)
    {
        bool isFrozen = Rand.NextDouble() < freezeChance;
        int damage = Convert.ToInt32(Rand.Next(3, atk));
        Console.WriteLine($"{name} is attacking!");
        player.TakeDamage(damage);

        if (isFrozen)
        {
            player.debuff = true;
            Console.WriteLine("Zamorojeno!");
        }

    }
}

public class VVG: Goblin 
{
    public VVG(int hp, int def, int atk, string name) : base(hp, def, atk, name)
    {
        this.hp = hp * 2;
        this.def = Convert.ToInt32(def * 1.2);
        this.atk = atk;
        this.name = name;
    }

    double critChance = 0.3;
    public override void Attack(Player player)
    {
        bool isCrit = Rand.NextDouble() < critChance;
        int damage = Convert.ToInt32(Rand.Next(3, atk) * 1.5);

        if (isCrit)
        {
            damage = (int)(damage * 1.5);
            Console.WriteLine("Crit hit!");
        }

        Console.WriteLine($"{name} is attacking!");
        player.TakeDamage(damage);
    }
}

public class Kovalski : Skelet
{
    public Kovalski(int hp, int def, int atk, string name) : base(hp, def, atk, name)
    {
        this.hp = Convert.ToInt32(hp * 2.5);
        this.def = Convert.ToInt32(def * 1.4);
        this.atk = atk;
        this.name = name;
    }

    public override void Attack(Player player)
    {
        int damage = Convert.ToInt32(Rand.Next(3, atk) * 1.3);
        Console.WriteLine($"{name} is aattacking and he don`t give a damn abt ur def!");
        player.hp -= damage;
        if (player.hp < 0) player.hp = 0;
    }
}

public class ArkhimagCplusplus : Mag
{
    public ArkhimagCplusplus(int hp, int def, int atk, string name) : base(hp, def, atk, name)
    {
        this.hp = Convert.ToInt32(hp * 1.8);
        this.def = Convert.ToInt32(def * 1.1);
        this.atk = atk;
        this.name = name;
    }

    double freezeChance = 0.3;
    public override void Attack(Player player)
    {
        bool isFrozen = Rand.NextDouble() < freezeChance;
        int damage = Convert.ToInt32(Rand.Next(3, atk) * 1.6);
        Console.WriteLine($"{name} is attacking!");
        player.TakeDamage(damage);

        if (isFrozen)
        {
            player.debuff = true;
            Console.WriteLine("Zamorojeno!");
        }

    }
}

    public class PestovCminusminus : Skelet
    {
        public PestovCminusminus(int hp, int def, int atk, string name) : base(hp, def, atk, name)
        {
            this.hp = Convert.ToInt32(hp * 1.3);
            this.def = Convert.ToInt32(def * 0.6);
            this.atk = atk;
            this.name = name;
        }
        double freezeChance = 0.35;
        public override void Attack(Player player)
        {
            bool isFrozen = Rand.NextDouble() < freezeChance;
            int damage = Convert.ToInt32(Rand.Next(3, atk) * 1.8);
            Console.WriteLine($"{name} is aattacking and he don`t give a damn abt ur def!");
            player.hp -= damage;
            if (player.hp < 0) player.hp = 0;
            if (isFrozen)
            {
                player.debuff = true;
                Console.WriteLine("Zamorojeno!");
            }
        }
    }

public class Game
{
    int hod = 0;
    public Player player;
    private Random random;

    public Game()
    {
        random = new Random();
        player = new Player(100, 1, 5);
    }

    public void Start()
    {
        Console.WriteLine("Vremia dodepa!");
        Console.WriteLine("To attack press 1, to defend press 2");

        while (player.hp > 0)
        {
            hod++;
            Console.WriteLine($"Hod {hod}");
            Console.WriteLine(player.GetStatus());

            if (player.debuff)
            {
                Console.WriteLine("Youe frozen and are unable to sdelat hod");
                player.debuff = false;
                ContinueGame();
                continue;
            }
            if (random.Next(2) == 0)
            {
                OpenChest();
            }
            else
            {
                Enemy enemy = CreateEnemy();
                Combat(enemy);
            }

            if (player.hp <= 0)
            {
                Console.WriteLine("GG BB");
                Console.WriteLine($"Vi projerjalis {hod} hodov.");
                break;
            }

            ContinueGame();
        }
    }

    private Enemy CreateEnemy()
    {
        if (hod % 10 == 0)
        {
            int bossType = random.Next(4);
            return bossType switch
            {
                0 => new VVG(),
                1 => new Kovalski(),
                2 => new ArkhimagCplusplus(),
                3 => new PestovCminusminus()
            };
        }

        int enemyType = random.Next(3);
        return enemyType switch
        {
            0 => new Goblin(),
            1 => new Skelet(),
            2 => new Mag()
        };
    }

    private void OpenChest()
    {
        Console.WriteLine("Chest!");
        if (random.NextDouble() < 0.3)
        {
            Console.WriteLine("Healing potion!");
            player.Heal();
        }
        else
        {
            if (random.Next(2) == 0)
            {
                Weapon newWeapon = new Weapon();
                Console.WriteLine($"Tere is a weapon: {newWeapon}");
                Console.WriteLine($"Ur current weapon: {player.Weapon}");
                Console.Write("Take new? (y/n): ");

                if (Console.ReadLine().ToLower() == "y")
                {
                    player.Weapon = newWeapon;
                    player.UpdateStats();
                    Console.WriteLine($"U`ve equiped: {newWeapon.name}");
                }
            }
            else
            {
                Equipment newArmor = new Equipment();
                Console.WriteLine($"There is an armor: {newArmor}");
                Console.WriteLine($"Ur current armor: {player.Equipment}");
                Console.Write("Equip nw? (y/n): ");

                if (Console.ReadLine().ToLower() == "y")
                {
                    player.Equipment = newArmor;
                    player.UpdateStats();
                    Console.WriteLine($"U`ve equiped: {newArmor.name}");
                }
            }
        }
    }

    private void Combat(Enemy enemy)
    {
        Console.WriteLine($"U met: {enemy.GetInfo()}");

        while (enemy.hp > 0 && player.hp > 0)
        {
            PlayerTurn(enemy);
            if (enemy.hp <= 0) break;

            EnemyTurn(enemy);
        }

        if (enemy.hp <= 0)
        {
            Console.WriteLine($"U won {enemy.name}!");
        }
    }

    private void PlayerTurn(Enemy enemy)
    {
        Console.WriteLine("What do u want to do:");
        Console.WriteLine("1 - attack");
        Console.WriteLine("2 - defend");
        Console.Write("ur choice: ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                player.Attack(enemy);
                break;
            case "2":
                player.Defend();
                break;
            default:
                Console.WriteLine("Theres no other option, youve missed that turn.");
                break;
        }
    }

    private void EnemyTurn(Enemy enemy)
    {
        enemy.Attack(player);

        if (player.hp <= 0)
        {
            Console.WriteLine("uve lost lelele...");
        }
    }

    private void ContinueGame()
    {
        Console.WriteLine("press any key");
        Console.ReadKey();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Game game = new Game();
            game.Start();

            Console.Write("\nХотите сыграть еще раз? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y" && choice != "д")
            {
                break;
            }
        }

        Console.WriteLine("Спасибо за игру!");
    }
}