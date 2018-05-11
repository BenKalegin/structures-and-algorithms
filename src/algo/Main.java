package algo;

import algo.LinkedLists.Reverse;
import algo.backtrack.ChessKnightTour;
import algo.dynamicprogramming.*;
import algo.general.Find3Sum;
import algo.general.RemoveAlternateDuplicateChars;
import algo.general.TenMostFrequentWords;

public class Main {

    public static void main(String[] args) {
        new Find3Sum().test();
        //new TenMostFrequentWords().test();
        //new Reverse().test();
        // new EggDroppingPuzzle().test();
        // new UglyNumbers().test();
        //new LongestRepeatedSubsequence().test();
        //new LargestSumContiguousSubarray().test();
        //new MinimumStepsToOne().test();
        //new LongestIncreasingSubsequence().test();

        //new MaximalSquareSubmatrixConsistingOfOnes().test();
        //testLongestCommonSubsequence();

        if (false)
	        new ChessKnightTour(5).findPossiblePaths();
    }

    private static void testLongestCommonSubsequence() {

        String s1 = "ABCDE";
        String s2 = "CE";
        System.out.println(s1 + " " + s2 + " = " + new LongestCommonSubsequence().find(s1, s2));
    }
}

