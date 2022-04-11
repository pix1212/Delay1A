using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delay1
{
    class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        Random _random = new Random();

        Board _board;

        public void Initialize(int posX, int posY, Board board)
        {
            PosX = posX;
            PosY = posY;

            _board = board;

            AStar();

        }

        

        void AStar()
        {
            // 점수 매기기
            // F = G + H
            // F = 최종 점수
            // G = 시잠점에서 좌표까지 비용
            // H = 목적지에서 가까운 정도

            // (x, y)이미 방문했는지 여부 (방문 = closed 상태)
            bool[,] closed = new bool[_board.Size, _board.Size];

            // (x, y) 가는 길을 한번이라도 발견했는지
            // 발견ㄴㄴ => MaxValue
            // 발견ㅇㅇ => F = G + H

            int[,] open = new int[_board.Size, _board.Size];
            for (int y = 0; y < _board.Size; y++)
                for (int x = 0; x < _board.Size; x++)
                    open[y, x] = Int32.MaxValue;

            

            //시작점 발견
            open[PosY, PosX] = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);

        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                // 0.1초마다 실행될 로직
                int randValue = _random.Next(0, 5);
                switch (randValue)
                {
                    case 0: //상
                        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        break;

                    case 1: //하
                        if (PosY + 1 < _board.Size  &&  _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;

                    case 2: //좌
                        if (PosX - 1 >= 0 &&  _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;

                    case 3: //우
                        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        break;


                }
            }
        }
    }
}
