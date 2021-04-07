﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    public class GameBoard
    {
        private ITile[,] _data;
        private Random rng;

        public GameBoard(int width, int height) 
        {
            // create board data
            _data = new ITile[width, height];
            rng = new Random();

            // fill board with floor
            for (int y = 0; y < _data.GetLength(1); y++) 
            {
                for (int x = 0; x < _data.GetLength(0); x++) 
                {
                    _data[x, y] = new Tiles.Floor(x, y);
                    if (x == 0 || x == _data.GetLength(0) - 1
                        || y == 0 || y == _data.GetLength(1) - 1)
                    {
                        _data[x, y].EntityOnTile = new Entities.Wall(this, x, y);
                    }
                    else if(rng.NextDouble() < 0.025)
                    {
                        _data[x, y].EntityOnTile = new Entities.Treasure(this, x, y);
                    }
                }
            }
        }

        public void Draw() 
        {
            for (int y = 0; y < _data.GetLength(1); y++)
            {
                for (int x = 0; x < _data.GetLength(0); x++)
                {
                    _data[x, y].Draw();
                }
                Console.WriteLine();
            }
        }

    }
}
