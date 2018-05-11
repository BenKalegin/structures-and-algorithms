package algo.general;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collector;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Find3Sum {
    public void test() {
        //int[] array = new int[] {-1, 0, 1, 2, -1, -4};
        int[] array = new int[] {-2,0,0,2,2};

        List<List<Integer>> result = find(array);

        result.forEach(a -> {
            System.out.println(a.stream().map(i -> "" + i).collect(Collectors.joining(",")));
        });
    }

    private List<List<Integer>> find(int[] array) {
        List<List<Integer>> result = new ArrayList<>();

        Arrays.sort(array);

        HashSet<Integer> visited = new HashSet<>();

        for (int i = 0; i <= array.length-2; i++) {
            if (visited.contains(array[i]))
                continue;
            visited.add(array[i]);
            result.addAll(find2Sum(array, i));
        }
        return result;
    }

    private List<List<Integer>> find2Sum(int[] array, int i) {
        int firstValue = array[i];
        int left = i+1;
        int right = array.length-1;

        List<List<Integer>> result = new ArrayList<>();

        while (left < right) {
            int delta = array[left] + array[right] + firstValue;
            if (delta == 0) {
                result.add(Arrays.asList(firstValue, array[left], array[right]));
                left++;
                while(left < right && array[left] == array[left-1])
                    left++;
                right--;
                while (left < right && array[right] == array[right+1])
                    right--;
            }else if (delta > 0)
                right--;
            else
                left++;
            // -5 -3 3 4
        }
        return result;
    }

}
