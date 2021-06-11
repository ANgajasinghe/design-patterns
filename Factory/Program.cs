using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            new NavigationBar();
            new DropdownMenu();

            new AB_NavigationBar(new Apple());
            new AB_DropdownMenu(new Apple());
        }
    }


// Factory
    public class NavigationBar{
        public NavigationBar()=> ButtonFactory.CreateButton();
    }

    public class DropdownMenu{
        public DropdownMenu() => ButtonFactory.CreateButton();
    }

    public class ButtonFactory{
        public static Button CreateButton(){
            return new Button {Type = "Default Button".Dump()};
        }
    }

    public class Button{
        public string Type { get; set; }
    }

// Abstract Factory
// Inversion of Control (IoC) 
 public class AB_NavigationBar{
        public AB_NavigationBar(IUIFactory factory)=> factory.CreateButton();
    }

    public class AB_DropdownMenu{
        public AB_DropdownMenu(IUIFactory factory)=> factory.CreateButton();
    }


    public interface  IUIFactory{
        public Button CreateButton();
    }

    public class Apple : IUIFactory
    {

        // dependency inversion
        public Button CreateButton()
        {
            return new Button{Type = "Ios button factory".Dump()};
        }
    }

     public class Android : IUIFactory
    {
        public Button CreateButton()
        {
            return new Button {Type = "Android button factory".Dump()};
        }
    }



// Factory Methods
// Here we use inheritance this will increse the structure of the program

    public abstract class Element{
    protected abstract Button CreateButton();

    public Element()=> CreateButton();
}

    public class FM_NavigationBar : Element
    {
        protected override Button CreateButton()
        {
           return new Button {Type = "Default Button".Dump()};
        }
    }

    public class FM_DropdownMenu : Element
    {
        protected override Button CreateButton()
        {
            return new Button {Type = "Default Button".Dump()};
        }
    }


}
