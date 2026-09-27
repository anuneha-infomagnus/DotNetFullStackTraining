using System;

class A
{
    public virtual void Fun()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public virtual void Fun()
    {
        Console.WriteLine("B");
    }
}

class C : B
{
    public virtual void Fun()
    {
        Console.WriteLine("C");
    }
}
// =========================
// CASE 2
// =========================

class A2
{
    public virtual void Fun()
    {
        Console.WriteLine("A2");
    }
}

class B2 : A2
{
    public virtual void Fun()
    {
        Console.WriteLine("B2");
    }
}

class C2 : B2
{
    public override void Fun()
    {
        
        Console.WriteLine("C2");
    }
}
class A3
{
    public virtual void Fun()
    {
        Console.WriteLine("A3");
    }
}

class B3 : A3
{
    public override void Fun()
    {
        Console.WriteLine("B3");
    }
}

class C3 : B3
{
    public virtual void Fun()
    {
        Console.WriteLine("C3");
    }
}
class A4
{
    public virtual void Fun()
    {
        Console.WriteLine("A4");
    }
}

class B4 : A4
{
    public override void Fun()
    {
        Console.WriteLine("B4");
    }
}

class C4 : B4
{
    public override void Fun()
    {
        Console.WriteLine("C4");
    }
}

class A5
{
    public override void Fun()
    {
        Console.WriteLine("A");
    }
}

class B5 : A5
{
    public virtual void Fun()
    {
        Console.WriteLine("B");
    }
}

class C5 : B5
{
    public virtual void Fun()
    {
        Console.WriteLine("C");
    }
}
class A6
{
    public override void Fun()
    {
        Console.WriteLine("A");
    }
}

class B6 : A6
{
    public virtual void Fun()
    {
        Console.WriteLine("B");
    }
}

class C6 : B6
{
    public override void Fun()
    {
        Console.WriteLine("C");
    }
}


class A7
{
    public override void Fun()
    {
        Console.WriteLine("A");
    }
}

class B7 : A7
{
    public override void Fun()
    {
        Console.WriteLine("B");
    }
}

class C7 : B7
{
    public virtual void Fun()
    {
        Console.WriteLine("C");
    }
}
class A8
{
    public override void Fun()
    {
        Console.WriteLine("A");
    }
}

class B8 : A8
{
    public override void Fun()
    {
        Console.WriteLine("B");
    }
}

class C8 : B8
{
    public override void Fun()
    {
        Console.WriteLine("C");
    }
}



class Program
{
    static void Main()
    {
        A obj1 = new C();

        B obj2 = new C();

        C obj3 = new C();

        obj1.Fun();

        obj2.Fun();

        obj3.Fun();
        // Case 2
        Console.WriteLine("\nCASE 2");

        A2 obj4 = new C2();
        B2 obj5 = new C2();
        C2 obj6 = new C2();

        obj4.Fun();
        obj5.Fun();
        obj6.Fun();

        Console.WriteLine("CASE 3");

        A3 obj7 = new C3();
        B3 obj8 = new C3();
        C3 obj9 = new C3();

        obj7.Fun();
        obj8.Fun();
        obj9.Fun();

        Console.WriteLine("CASE 4");

        A4 obj10 = new C4();
        B4 obj11 = new C4();
        C4 obj12 = new C4();

        obj10.Fun();
        obj11.Fun();
        obj12.Fun();

        Console.WriteLine("CASE 5");
        A5 obj13 = new C5();
        B5 obj14 = new C5();
        C5 obj15 = new C5();

        obj13.Fun();
        obj14.Fun();
        obj15.Fun();

        Console.WriteLine("CASE 6");
        A6 obj16 = new C6();
        B6 obj17 = new C6();
        C6 obj18 = new C6();

        obj16.Fun();
        obj17.Fun();
        obj18.Fun();

        Console.WriteLine("CASE 7");
        A7 obj19 = new C7();
        B7 obj20= new C7();
        C7 obj21 = new C7();

        obj19.Fun();
        obj20.Fun();
        obj21.Fun();

        Console.WriteLine("CASE 8");
        A8 obj22 = new C8();
        B8 obj23 = new C8();
        C8 obj24 = new C8();

        obj22.Fun();
        obj23.Fun();
        obj24.Fun();

    }
}