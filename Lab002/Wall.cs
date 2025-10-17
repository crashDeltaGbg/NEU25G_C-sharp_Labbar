using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab002
{
    internal class Wall : LevelElement
    {
        public Wall() {
            Symbol = '#';
            Color = ConsoleColor.Gray;
        }
    }
}
