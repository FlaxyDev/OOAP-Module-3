using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    interface ICostume
    {
        void WearCostume();
    }
    class Costume : ICostume
    {
        private readonly string _type;

        public Costume(string type)
        {
            _type = type;
        }

        public void WearCostume()
        {
            Console.WriteLine($"Wearing {_type} costume");
        }
    }
    class CostumeFactory
    {
        private readonly Dictionary<string, ICostume> _costumes = new Dictionary<string, ICostume>();

        public ICostume GetCostume(string type)
        {
            if (!_costumes.ContainsKey(type))
            {
                _costumes[type] = new Costume(type);
            }
            return _costumes[type];
        }
    }

    class Actor
    {
        private ICostume _costume;

        public Actor(ICostume costume)
        {
            _costume = costume;
        }

        public ICostume Costume 
        {
            set => _costume = value;
        }

        public void PerformScene()
        {
            _costume.WearCostume();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CostumeFactory costumeFactory = new CostumeFactory();

            Actor Actor1 = new Actor(costumeFactory.GetCostume("Street"));
            Actor Actor2 = new Actor(costumeFactory.GetCostume("Street"));
            Actor Actor3 = new Actor(costumeFactory.GetCostume("Street"));
            Actor1.PerformScene();
            Actor2.PerformScene();
            Actor3.PerformScene();

            Actor1.Costume = costumeFactory.GetCostume("Medieval Knight");
            Actor2.Costume = costumeFactory.GetCostume("Medieval Knight");
            Actor3.Costume = costumeFactory.GetCostume("Medieval Knight");
            Actor1.PerformScene();
            Actor2.PerformScene();
            Actor3.PerformScene();
        }
    }
}
