using System;
using System.Collections.Generic;

namespace Prototype
{

   
    /*
    
    This design pattern can be used to generate some prototypes 
    Eg:- Like excel we type string and it automatically converts to it type and that creatred type has its own characteristics  

     
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<IBlock> grid = new List<IBlock>()
            {
                BlockFactory.Create("Hello World!"),
                BlockFactory.Create("45"),
                BlockFactory.Create("2020-10-10"),
            };

            grid.Dump();
        }
    }

    public class BlockFactory 
    {
        public static IBlock Create(string content) 
        {
            if (DateTime.TryParse(content, out var dt)) 
            {
                return new DateTimeBlock { Format = "dd/MM/yyyy", DateTime = dt };
            }

            if (int.TryParse(content, out var n)) return new NumberBlock() { Number = n };

            return new TextBlock() { Content = content };
        }

    }

    public interface IBlock 
    {
        string Render { get; }
        IBlock Clone();
    }

    public class TextBlock : IBlock
    {
        public string Content { get; set; }
        public string Render => Content;

        public IBlock Clone() => new TextBlock { Content = Content };
        
    }

    public class NumberBlock : IBlock
    {
        public int Number { get; set; }
        public string Render => Number.ToString();
        public IBlock Clone() => new NumberBlock { Number = Number };
    }

    public class DateTimeBlock : IBlock
    {
        public DateTime DateTime { get; set; }

        public string Format { get; set; }
        public string Render => DateTime.ToString(Format);
        public IBlock Clone() => new DateTimeBlock { DateTime = DateTime,Format = Format };
    }
}
