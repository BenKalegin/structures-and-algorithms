package algo.dynamicprogramming;

import java.io.Console;
import java.util.*;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;

public class MatrixChainMultiplication {

    // Matrix Ai has dimension p[i-1] x p[i]
    // for i = 1..n
    static int MatrixChainOrder(int[] dims, int left, int right) {
        if (left == right)
            return 0;

        // i position we multiply at. that is, first  = 1 when we multiply first matrix to all others
        var bestIndex = Integer.MIN_VALUE;
        var bestCost = Integer.MAX_VALUE;
        for (int i = left+1; i <= right; i++) {
            var cost = MatrixChainOrder(dims, left, i) + MatrixChainOrder(dims, i, right) + dims[i-1] * dims[i];
            if (cost < bestCost) {
                bestCost = cost;
                bestIndex = i;
            }
        }

        return bestCost;
    }

    static int MatrixChainOrder(int[] dims) {
        return MatrixChainOrder(dims, 1, dims.length);
    }

    public void test() {
        Set<Integer> s = new TreeSet<Integer>();
        List<Integer> v = new Vector<Integer>();
        Set<Integer> hs = new HashSet<>();
        Optional<Integer> any = hs.stream().findAny();
        if (any.isPresent())
            System.out.println(any.get());
        BlockingQueue<Integer> bq = new ArrayBlockingQueue<Integer>();
        java.util.concurrent.CompletionException


    }
}
