package algo.dynamicprogramming;

import java.util.stream.IntStream;

public class EggDroppingPuzzle {
    private int solveRecursive(int eggsCount, int floorsCount, int[][] dp) {
        // min number rof trials
        // dp[f,e] = min(max(dp[f-1, e-1], dp[floorsCount - f, e]))
        System.out.println(eggsCount + ":" + floorsCount);

        if (floorsCount == 0 || floorsCount == 1)
            return floorsCount;

        if (eggsCount == 1)
            return floorsCount;

        if (dp[eggsCount][floorsCount] > 0)
            return dp[eggsCount][floorsCount];

        int result  = IntStream.range(1, floorsCount)
                .map(floor -> Math.max(
                        solveRecursive(eggsCount - 1, floorsCount - 1, dp),
                        solveRecursive(eggsCount, floorsCount - floor, dp)))
                .min().getAsInt() + 1;

        dp[eggsCount][floorsCount] = result;
        return result;
    }

    private int solveDown(int eggsCount, int floorsCount) {
        int dp[][] = new int[eggsCount+1][floorsCount+1];
        return solveRecursive(eggsCount, floorsCount, dp);
    }

    private int solve(int eggsCount, int floorsCount) {
        int[][] dp = new int[eggsCount+1][floorsCount+1];

        // 0 when no eggs
        for (int i = 0; i < floorsCount; i++)
            dp[0][i] = 0;

        // n when 1 egg
        for (int i = 0; i < floorsCount; i++)
            dp[1][i] = i;

        // 0 when ground, 1 when first
        for (int i = 0; i < eggsCount; i++) {
            dp[i][0] = 0;
            dp[i][1] = 1;
        }

        // recurrent
        for (int e = 2; e <= eggsCount; e++) {
            for (int f = 2; f <= floorsCount; f++) {
                dp[e][f] = Integer.MAX_VALUE;
                for (int ff = 1; ff <= f; ff++)
                    dp[e][f] = Math.min(dp[e][f], 1 + Math.max(dp[e-1][ff-1], dp[e][f-ff]));
            }
        }

        return dp[eggsCount][floorsCount];
    }

    public void test() {
        System.out.println("2,10: " + solve(2, 10));
        System.out.println("2,36: " + solve(2, 36));
    }
}
