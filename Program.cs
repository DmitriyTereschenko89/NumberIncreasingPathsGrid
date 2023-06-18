namespace NumberIncreasingPathsGrid
{
	internal class Program
	{
		public class NumberIncreasingPathsGrid
		{
			private int modulo = 1000000007;
			private int[] deltaR = new int[] { 0, -1, 0, 1 };
			private int[] deltaC = new int[] { -1, 0, 1, 0 };

			private int DFS(int[,] dp, int[][] grid, int r, int c, int rows, int cols)
			{
				if (dp[r, c] != 0)
				{
					return dp[r, c];
				}

				int countPaths = 1;
				for (int i = 0; i < deltaR.Length; ++i)
				{
					int newR = r + deltaR[i];
					int newC = c + deltaC[i];
					if (newR >= 0 && newR < rows && newC >= 0 && newC < cols && grid[newR][newC] > grid[r][c])
					{
						countPaths += DFS(dp, grid, newR, newC, rows, cols);
						countPaths %= modulo;
					}
				}
				dp[r, c] = countPaths;
				return countPaths;
			}
			public int CountPaths(int[][] grid)
			{
				int rows = grid.Length;
				int cols = grid[0].Length;
				int[,] dp = new int[rows, cols];
				int countPaths = 0;
				for (int r = 0; r < rows; ++r)
				{
					for (int c = 0; c < cols; ++c)
					{
						countPaths += DFS(dp, grid, r, c, rows, cols);
						countPaths %= modulo;
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