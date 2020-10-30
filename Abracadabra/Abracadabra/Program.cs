using System;

namespace Abracadabra
{
    class Pizzazz
    {
        public int Zippo;

        public void Bamboo(int eek)
        {
            Zippo += eek;
        }
    }

    class Abracadabra
    {
        public int Vavavoom;

        public bool Lala(int floq)
        {
            if (floq < Vavavoom)
            {
                Vavavoom += floq;            
                return true;
            }        
            return false;
        }
    }
    class Program
    {    
        public static void Main(string[] args)    
        {        
            Pizzazz foxtrot = new Pizzazz() { Zippo = 2 };
            foxtrot.Bamboo(foxtrot.Zippo);        
            Pizzazz november = new Pizzazz() { Zippo = 3 };        
            Abracadabra tango = new Abracadabra() { Vavavoom = 4 };
            while (tango.Lala(november.Zippo))
            {
                november.Zippo *= -1;            
                november.Bamboo(tango.Vavavoom);            
                foxtrot.Bamboo(november.Zippo);            
                tango.Vavavoom -= foxtrot.Zippo;
            }        
            Console.WriteLine("november.Zippo = " + november.Zippo);        
            Console.WriteLine("foxtrot.Zippo = " + foxtrot.Zippo);        
            Console.WriteLine("tango.Vavavoom = " + tango.Vavavoom);    
            
            for (double d = 10; double.IsFinite(d); d *= d){    Console.WriteLine("This is d {0}",d);}
            for (float f = 10; float.IsFinite(f); f *= f){    Console.WriteLine("This is f {0}", f);}
        }
        
    }
}