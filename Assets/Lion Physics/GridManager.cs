using System.Collections.Generic;
using UnityEngine;

namespace Lion.Physics
{
    [DefaultExecutionOrder(-999)]
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance { get; private set; }

        public int gridWidth;
        public int gridHeight;
        public float cellSize;
        private List<Circle>[,] grid;

        void Awake()
        {
            Instance = this;
            InitializeGrid();
        }

        public static int calcCount;

        private void Update()
        {
            calcCount = 0;
        }

        private void LateUpdate()
        {
            Debug.Log(calcCount);
        }

        void InitializeGrid()
        {
            int numCellsX = Mathf.CeilToInt(gridWidth / cellSize);
            int numCellsY = Mathf.CeilToInt(gridHeight / cellSize);
            grid = new List<Circle>[numCellsX, numCellsY];

            for (int x = 0; x < numCellsX; x++)
            {
                for (int y = 0; y < numCellsY; y++)
                {
                    grid[x, y] = new List<Circle>();
                }
            }
        }

        public void AddCircle(Circle circle, Vector3 position)
        {
            Vector2Int gridPosition = GetGridPosition(position);
            grid[gridPosition.x, gridPosition.y].Add(circle);
        }

        public void RemoveCircle(Circle circle, Vector3 position)
        {
            Vector2Int gridPosition = GetGridPosition(position);
            grid[gridPosition.x, gridPosition.y].Remove(circle);
        }

        public void MoveObject(Circle circle, Vector3 newPos, Vector3 oldPos)
        {
            RemoveCircle(circle, oldPos);
            AddCircle(circle, newPos);
        }

        public Vector2Int GetGridPosition(Vector2 position)
        {
            int x = Mathf.FloorToInt(position.x / cellSize);
            int y = Mathf.FloorToInt(position.y / cellSize);
            return new Vector2Int(x, y);
        }

        public void RetrieveNeighbors(Circle circle, ref List<Circle> neighbors)
        {
            neighbors.Clear();
            Vector2Int gridPos = GetGridPosition(circle.transform.position);

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int checkX = gridPos.x + x;
                    int checkY = gridPos.y + y;
                    if (checkX >= 0 && checkX < grid.GetLength(0) && checkY >= 0 && checkY < grid.GetLength(1))
                    {
                        neighbors.AddRange(grid[checkX, checkY]);
                    }
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 47f / 51f, 0.0156862754f, 0.5f); ; // ƒMƒYƒ‚‚ÌF‚ðÝ’è
            if (cellSize == 0) return;

            for (float x = 0; x <= gridWidth; x += cellSize)
            {
                // cü‚ð•`‰æ
                Gizmos.DrawLine(new Vector3(x, 0, 0), new Vector3(x, gridHeight, 0));
            }
            for (float y = 0; y <= gridHeight; y += cellSize)
            {
                // ‰¡ü‚ð•`‰æ
                Gizmos.DrawLine(new Vector3(0, y, 0), new Vector3(gridWidth, y, 0));
            }
        }
    }
}