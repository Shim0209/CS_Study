using static System.Console;

/**
 * static은 메소드나 필드가 클래스의 인스턴스가 아닌 클래스 자체에
 * 소속되도록 지정하는 한정자이다.
 * 한 프로그램안에 인스턴스는 여러개 존재할 수 있으나 클래스는 단 하나만
 * 존재한다. 즉 프로그램 전체에 유일하게 존재하는 것을 의미.
 * 프로그램 전체에 걸쳐 공유해야 하는 변수가 있다면 정적 필드를 이용하면된다.
 * 
 * 정적메소드 역시 인스턴스가 아닌 클래스 자체에 소속된다.
 * 즉, 인스턴스를 생성하지 않아도 호출이 가능한 메소드라는 점이다.
 * 보통 객체 내부의 데이터를 이용해야 하는 경우에는 인스턴스 메소드를 선언,
 * 내부 데이터를 이용할 일이 없는 경우에는 정적 메소드를 선언한다.
 */
class Global
{
    public static int Count = 0;

    public static void Static()
    {
        WriteLine("Static Method 실행됨...");
    }
}

class ClassA
{
    public ClassA() 
    {
        Global.Count++;
    }
}

class ClassB
{
    public ClassB()
    {
        Global.Count++;
    }
}

class MainApp
{
    static void Main()
    {
        WriteLine($"Global.Count : {Global.Count}");

        new ClassA();
        new ClassA();
        new ClassB();
        new ClassB();

        WriteLine($"Global.Count : {Global.Count}");

        Global.Static();
    }
}

