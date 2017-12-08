package algo.dynamicprogramming;

public class MaximalSquareSubmatrixConsistingOfOnes {
    public void test() {
        int[][] m1 = {
                {1, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 1, 1, 0},
                {1, 1, 1, 0, 0},
                {1, 1, 1, 0, 0},
                {1, 1, 1, 0, 0},
        };
        System.out.println(solve(m1));
    }

    public int solve(int[][] matrix) {
        int ny = matrix.length;
        int nx = matrix[0].length;
        int[][] dp = new int[ny+1][nx+1];
        int bestRank = 0;
        int bestX = -1;
        int bestY = -1;

        try {
        for(int y = -1; y < ny; y++)
            for(int x = -1; x < nx; x++){
                int rank = 0;
                if ((x == -1) || (y == -1))
                    rank = 0;
                else if ((x == 0) || (y == 0))
                    rank = matrix[y][x];
                else if (matrix[y][x] == 1)
                    rank = Math.min(Math.min(dp[y][x], dp[y][x+1]), dp[y+1][x]) + 1;


                if (rank > bestRank) {
                    bestRank = rank;
                    bestX = x;
                    bestY = y;
                    System.out.println("" + y + ":" + x + "=" + rank);
                }
                dp[y+1][x+1] = rank;
            }
        }catch (Exception e){
            System.out.println(e);
        }
        return bestRank;
    }


}
