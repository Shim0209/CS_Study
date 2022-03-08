using static System.Console;

/**
 * 메소드를 오버라이딩 하기 위해서는 한 가지 조건이 필요하다.
 * 그 조건은 오버라이딩을 할 메소드가 virtual 키워드로 한정되어 
 * 있어야 한다는 것이다.
 */
namespace Overriding
{
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            WriteLine("Armored");
        }
    }

    class Ironman : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Repusor Rays Armed");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Double-Barrel Cannons Armed");
            WriteLine("Micro-Rocket Launcher Armed");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            WriteLine("[ArmorSuite]");
            ArmorSuite armorSuite = new ArmorSuite();
            armorSuite.Initialize();

            WriteLine("[IronMan]");
            Ironman ironman = new Ironman();
            ironman.Initialize();

            WriteLine("[WarMachine]");
            WarMachine warMachine = new WarMachine();   
            warMachine.Initialize();
        }
    }
}

