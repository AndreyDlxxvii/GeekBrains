using UnityEngine;
using UnityEngine.Tilemaps;

namespace GBPlatformer
{
    public class GeneratorController : IOnController, IOnStart
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidth;
        private int _mapHeight;
        private bool _borders;

        private int _fillProcent;
        private int _smoothFactor;

        private int[,] _map;
        private int _countWall = 4;

        public GeneratorController(GeneratorLevelView levelView)
        {
            _tilemap = levelView.Tilemap;
            _groundTile = levelView.GroundTile;
            _mapWidth = levelView.MapWidth;
            _mapHeight = levelView.MapHeight;
            _borders = levelView.Borders;
            _fillProcent = levelView.FillProcent;
            _smoothFactor = levelView.SmoothFactor;
            
            _map = new int[_mapWidth, _mapHeight];
        }

        public void OnStart()
        {
            RandomFillMap();

            for (int i = 0; i < _smoothFactor; i++)
            {
                SmoothMap();
            }
            
            DrawTiles();
        }

        private void RandomFillMap()
        {
            float rand = Random.Range(0.00f, 0.05f);
            for (int x = 0; x < _mapHeight; x++)
            {
                for (int y = 0; y < _mapWidth; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = (Random.Range(0, 100) < _fillProcent) ? 1 : 0;
                    }
                }   
            }
        }

        private void SmoothMap()
        {
            for (int x = 0; x < _mapHeight; x++)
            {
                for (int y = 0; y < _mapWidth; y++)
                {
                    int neighborWall = GetWallCount(x,y);

                    if (neighborWall >  _countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighborWall < _countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetWallCount(int x, int y)
        {
            int wallCount = 0;
            for (int gridX = x - 1; gridX <= x+1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            wallCount += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }
            
            
            
            return wallCount;
        }

        private void DrawTiles()
        {
            if (_map == null)
                return;
            for (int x = 0; x < _mapHeight; x++)
            {
                for (int y = 0; y < _mapWidth; y++)
                {
                    Vector3Int positionTile = new Vector3Int(-_mapWidth/2+x, -_mapHeight/2+y, 0);
                    if (_map[x,y] == 1)
                    {
                        _tilemap.SetTile(positionTile, _groundTile);
                    }
                }
            }
        }
    }
}