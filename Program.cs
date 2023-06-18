namespace NumberIncreasingPathsGrid
{
	internal class Program
	{
		public class NumberIncreasingPathsGrid
		{
			private int modulo = 1000000007;

			private List<int[]> GetNeighbors(int[][] grid, int r, int c)
			{
				int[] deltaR = new int[] { 0, -1, 0, 1 };
				int[] deltaC = new int[] { -1, 0, 1, 0 };
				List<int[]> neighbors = new();
				for (int i = 0; i < deltaR.Length; ++i)
				{
					int newR = r + deltaR[i];
					int newC = c + deltaC[i];
					if (newR >= 0 && newR < grid.Length && newC >= 0 && newC < grid[newR].Length && grid[newR][newC] > grid[r][c])
					{
						neighbors.Add(new int[] { newR, newC });
					}
				}
				return neighbors;
			}

			private void BFS(int[][] dp, int[][] grid, int r, int c)
			{
				Queue<int[]> queue = new();
				bool[,] visited = new bool[grid.Length, grid[0].Length];
				queue.Enqueue(new int[] { r, c });
				while(queue.Count > 0)
				{
					int[] cell = queue.Dequeue();
					List<int[]> neighbors = GetNeighbors(grid, cell[0], cell[1]);
					foreach (int[] neighbor in neighbors)
					{
						if (!visited[neighbor[0], neighbor[1]])
						{
							visited[neighbor[0], neighbor[1]] = true;
							dp[neighbor[0]][neighbor[1]] = (dp[neighbor[0]][neighbor[1]] + 1) % modulo;
							queue.Enqueue(new int[] { neighbor[0], neighbor[1] });
						}
					}
				}
			}
			public int CountPaths(int[][] grid)
			{
				int n = grid.Length;
				int m = grid[0].Length;
				int[][] dp = new int[n][];
				for (int r = 0; r < n; ++r)
				{
					dp[r] = new int[m];
					Array.Fill(dp[r], 1);
				}
				for (int r = 0; r < n; ++r)
				{
					for (int c = 0; c < m; ++c)
					{
						BFS(dp, grid, r, c);
					}
				}
				int countPaths = 0;
				for (int r = 0; r < n; ++r)
				{
					for (int c = 0; c < m; ++c)
					{
						countPaths = (countPaths + dp[r][c]) % modulo;
					}
				}
				return countPaths;
			}
		}

		static void Main(string[] args)
		{
			NumberIncreasingPathsGrid numberIncreasingPathsGrid = new();
            Console.WriteLine(numberIncreasingPathsGrid.CountPaths(new int[][]
			{
				new int[] { 1, 1 },
				new int[] { 3, 4 }
			}));
            Console.WriteLine(numberIncreasingPathsGrid.CountPaths(new int[][]
			{
				new int[] { 1, 2 }
			}));
        }
	}
}