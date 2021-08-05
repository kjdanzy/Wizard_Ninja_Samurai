using System;

namespace Wizard_Ninja_Samurai
{
    public class Human
{
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int health;
     
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
     
    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        health = 100;
    }
     
    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        health = hp;
    }
     
    // Build Attack method
    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.health;
    }

}

    public class Wizard : Human
    {
        public void Heal(Human target){
            target.Intelligence = target.Intelligence * 10;
        }
        public override int Attack(Human target)
        {
            int damage = Intelligence * 5;
            target.Intelligence -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            Intelligence += damage;
            Console.WriteLine($"You, the Wizard, gained {damage} Intelligence points!");
            return target.Intelligence;
        }

        public Wizard (string name, int str, int dex, int intel = 25, int hp = 50) : base(name, str, dex, intel, hp){

        }

}

    public class Ninja : Human
    {
        public Ninja(string name, int str, int intel, int hp, int dex = 175) : base (name, str, intel, hp, dex){
        }

        public override int Attack(Human target)
        {
            int damage = base.Dexterity * 5;
            
            if (base.Strength > (base.Health * .02)){
                damage += 10;
                target.Dexterity -= (damage);
                Console.WriteLine($"{base.Name} attacked {target.Name} while 'charged up!' for {damage} and an extra 10pts!");
            }
            else{
                target.Dexterity -= damage;
                Console.WriteLine($"{base.Name} attacked {target.Name} for {damage} damage!");
            }
            
            Console.WriteLine($"You, the Ninja, gained {damage} Dexterity points!");
            
            return target.Dexterity;
        }

        public void Steal(Human target){
            int damage = 5;

            target.Health -= damage;
            base.Health += damage;
        }

}

    public class Samurai : Human
    {
        public void Meditate(){
            base.Health = 100;
        }
        public Samurai(string name, int str, int intel, int dex, int hp = 200) : base(name, str, intel, dex, hp){
            
        }
        public override int Attack(Human target)
        {
            int damage = base.Attack(target);
            if (target.Health < 50){
                target.Strength = 0;
                Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage and has now their Strength is 0!");
            }

            return target.Strength;
        }

}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Samurai newSamuri = new Samurai("Samurai", 5, 5, 5);
            Ninja newNinja = new Ninja("Ninja", 5, 5, 5);
            Wizard newWizard = new Wizard("Wizard", 5, 5, 5);

            newSamuri.Attack(newNinja);
            newWizard.Attack(newSamuri);
            newNinja.Attack(newWizard);


        }
    }
}
