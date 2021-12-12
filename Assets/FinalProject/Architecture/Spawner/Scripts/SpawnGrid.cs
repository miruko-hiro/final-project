using System.Collections.Generic;
using UnityEngine;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class SpawnGrid
    {
        private readonly List<Vector2> _grid;

        public SpawnGrid()
        {
            _grid = new List<Vector2>();
            GridGeneration();
        }

        private void GridGeneration()
        {
            float x = -7f;
            for (int i = 0; i < 8; i++)
            {
                _grid.Add(new Vector2(x, 1f));
                x += 2f;
            }

            x = -7f;
            for (int i = 0; i < 8; i++)
            {
                _grid.Add(new Vector2(x, -1f));
                x += 2f;
            }

            x = -7f;
            for (int i = 0; i < 8; i++)
            {
                _grid.Add(new Vector2(x, -3f));
                x += 2f;
            }
        }

        public List<Vector2> GetGrid(Vector2 offset)
        {
            if (offset == Vector2.zero) return _grid;

            var newGrid = new List<Vector2>(_grid);
            for (var i = 0; i < newGrid.Count; i++)
                newGrid[i] += offset;
            return newGrid;
        }
    }
}