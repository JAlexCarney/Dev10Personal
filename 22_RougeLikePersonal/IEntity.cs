using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    public interface IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsActive { get; set; }
        char DisplayChar { get; set; }
        ConsoleColor Color { get; set; }
        GameBoard ParentBoard { get; set; }

    }
}
