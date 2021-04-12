using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    public class GameBoard
    {
        public ITile[,] Data { get; private set; }
        private readonly Random rng;

        public GameBoard(int width, int height) 
        {
            // create board data
            Data = new ITile[width, height];
            rng = new Random();

            // fill board with floor
            for (int y = 0; y < Data.GetLength(1); y++) 
            {
                for (int x = 0; x < Data.GetLength(0); x++) 
                {
                    Data[x, y] = new Tiles.Floor(x, y);
                    if (x == 0 || x == Data.GetLength(0) - 1
                        || y == 0 || y == Data.GetLength(1) - 1)
                    {
                        Data[x, y].EntityOnTile = new Entities.Wall(this, x, y);
                    }
                    else if (x != 1 || y != 1)
                    {
                        if (rng.NextDouble() < 0.025) 
                        {
                            Data[x, y].EntityOnTile = new Entities.Treasure(this, x, y);
                        }
                        else if (rng.NextDouble() < 0.025)
                        {
                            Data[x, y].EntityOnTile = new Entities.Monster(this, x, y);
                        }
                    }
                }
            }
        }

        public void UpdateAll() 
        {
            for (int y = 0; y < Data.GetLength(1); y++)
            {
                for (int x = 0; x < Data.GetLength(0); x++)
                {
                    if (Data[x, y].EntityOnTile != null) 
                    {
                        Data[x, y].EntityOnTile.Update();
                    }
                }
            }
        }

        public bool IsOccupied(int x, int y) 
        {
            return Data[x, y].EntityOnTile != null;
        }

        public void Remove(int x, int y) 
        {
            Data[x, y].EntityOnTile = null;
        }

        public bool Place(IEntity entity, int x, int y) 
        {
            if (Data[x,y].EntityOnTile == null) 
            {
                Data[x, y].EntityOnTile = entity;
                return true;
            }
            return false;
        }

        public void Draw() 
        {
            for (int y = 0; y < Data.GetLength(1); y++)
            {
                for (int x = 0; x < Data.GetLength(0); x++)
                {
                    Data[x, y].Draw();
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(":");
                Console.ResetColor();
            }
        }

    }
}
