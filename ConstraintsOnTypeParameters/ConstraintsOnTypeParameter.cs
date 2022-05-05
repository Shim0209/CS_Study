using System;

/// 형식 매개변수 제약시키기
/// - 특정 조건을 갖춘 형식에만 대응하는 형식 매개변수가 필요할 때 사용 (형식 매개변수의 조건에 제약을 걸어서..)
/// 
/// 형식
/// - where 형식매개변수 : 제약조건
/// 
/// 종류
/// - where T : struct              (T는 값 형식이어야 한다)
/// - where T : class               (T는 참조 형식이어야 한다)
/// - where T : new()               (T는 반드시 매개변수가 없는 생성자가 있어야 한다)
/// - where T : 기반_클래스_이름     (T는 명시한 기반 클래스의 파생 클래스여야 한다)
/// - where T : 인터페이스_이름      (T는 명시한 인터페이스를 반드시 구현해야 한다. 인터페이스_이름에는 여러 개의 인터페이스를 명시할 수도 있다)
/// - where T : U                   (T는 또 다른 형식 매개변수 U로부터 상속받은 클래스여야 한다)
/// 

namespace ConstraintsOnTypeParameters
{
    // 값 형식
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }
    // 참조 형식
    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }
    // 상속
    class Base : ICloneable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
    class Derived : Base {}
    class BaseArray<T> where T : Base
    {
        public T[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new T[size];
        }
        // 또 다른 형식 매개변수 상속
        public void CopyArray<U>(U[] Source) where U : T
        {
            Source.CopyTo(Array, 0);
        }
    }

    // 인터페이스
    class Hi : ICloneable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
    class HiArray<T> where T : ICloneable
    {
        public T[] Array { get; set; }
        public HiArray(int size)
        {
            Array = new T[size];
        }
    }

    class MainApp
    {
        // 기본 생성자를 가진 어떤 클래스의 객체라도 생성해주는 메소드
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }
        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(20);
            b.Array[2] = new StructArray<double>(100);
            b.Array[0].Array[0] = 0.1;
            b.Array[0].Array[1] = 0.2;

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            //d.Array[0] = new Base();
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyArray<Derived>(d.Array); // d.Array를 e.Array로 복사

            HiArray<ICloneable> f = new HiArray<ICloneable>(3); // ICloneable을 구현한 클래스는 모두 받을 수 있다.
            f.Array[0] = new Hi();
            f.Array[1] = CreateInstance<Hi>();
            f.Array[2] = new Base();
        }
    }
}

