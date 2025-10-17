using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab002
{
    internal abstract class Enemy : LevelElement
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public Dice Attack { get; set; }

        public Dice Defence { get; set; }

        public Combat Combat { get; } = new();

        public abstract void Update(LevelData level);
    }
}
