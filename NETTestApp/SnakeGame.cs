using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    public class SnakeRunner
    {
        public static void Run()
        {
            int[][] food = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 }, new int[] { 2, 1 }, new int[] { 2, 0 }, new int[] { 1, 0 } };
            SnakeGame snakeGame = new SnakeGame(3, 3, food);

            int ret = snakeGame.Move("R"); // return 0
            ret = snakeGame.Move("R");
            ret = snakeGame.Move("D");
            ret = snakeGame.Move("D");
            ret = snakeGame.Move("L");
            ret = snakeGame.Move("L");
            ret = snakeGame.Move("U");
            ret = snakeGame.Move("U");
            ret = snakeGame.Move("R");
            ret = snakeGame.Move("R");
            ret = snakeGame.Move("D");
            ret = snakeGame.Move("D");
            ret = snakeGame.Move("L");
            ret = snakeGame.Move("L");
            ret = snakeGame.Move("U");
            ret = snakeGame.Move("R");

            ret = snakeGame.Move("U");
            ret = snakeGame.Move("L");
            ret = snakeGame.Move("D");
            Console.WriteLine("SnakeGame score = {0}", ret);
        }
    }
    public class SnakeGame
    {

        private List<Tuple<int, int>> snake = new List<Tuple<int, int>>();
        private readonly int _width, _height;
        private int _score = 0;
        private readonly int[][] _food; // [r,c] = [1,2] .. [0,1]
        int[] _foodIter;
        int nextFoodIndex = 0;
        bool foodConsumed = false;
        public SnakeGame(int width, int height, int[][] food)
        {
            _width = width;
            _height = height;
            _food = food;

            _foodIter = _food[nextFoodIndex];
            _score = 0;
            snake.Add(Tuple.Create(0, 0));
        }

        private bool InBounds(int r, int c)
        {
            return (snake[0].Item1 == r && snake[0].Item2 == c) || // head can take the current tail cell since the snake will move by 1 cell
                !snake.Contains(Tuple.Create(r,c))
                && (r >= 0) && (c >= 0) && (r < _height) && (c < _width);
        }

        public int Move(string direction)
        {
            Tuple<int, int> sHead = snake.Last();
            //int newR = 0, newC = 0;
            switch (direction)
            {
                case "R":
                 /*   newR = curr.Item1;
                    newC = curr.Item2 + 1;
                    if (!InBounds(newR, newC))
                        return -1; */
                    return MoveHelper(sHead.Item1, sHead.Item2+1);
                case "L":
                    /*  newR = curr.Item1;
                      newC = curr.Item2 - 1;
                      if (!InBounds(newR, newC))
                          return -1; */
                    return MoveHelper(sHead.Item1, sHead.Item2 - 1);
                case "U":
                   /* newR = curr.Item1 - 1;
                    newC = curr.Item2;
                    if (!InBounds(newR, newC))
                        return -1; */
                    return MoveHelper(sHead.Item1 - 1, sHead.Item2 );
                case "D":
                   /* newR = curr.Item1 + 1;
                    newC = curr.Item2;
                    if (!InBounds(newR, newC))
                        return -1; */
                    return MoveHelper(sHead.Item1 +1 , sHead.Item2 );
            }

            return -1;
        }

        private int MoveHelper(int newR, int newC)
        {
            if (!foodConsumed && _foodIter[0] == newR && _foodIter[1] == newC)
            {
                _score++;
                if (nextFoodIndex < _food.Length)
                {
                    if(_food.Length == nextFoodIndex + 1)
                        foodConsumed = true;
                    else
                        _foodIter = _food[++nextFoodIndex];
                }
            }
            else
            {
                snake.RemoveAt(0);
            }
            snake.Add(Tuple.Create(newR, newC));
            return _score;
        }
    }

    /**
     * Your SnakeGame object will be instantiated and called as such:
     * SnakeGame obj = new SnakeGame(width, height, food);
     * int param_1 = obj.Move(direction);
     */
}
