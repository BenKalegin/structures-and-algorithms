package algo.general;


/*
    In a file there are 1 million words . Find 10 most frequent words in that file.
 */

import java.util.*;

public class TenMostFrequentWords {
    public void test() {
        String[] words = new String[]{"not", "what", "not", "but", "put", "not", "but"};
        List<String> result = findMostPopular(words, 2);
        result.stream().forEach(s -> System.out.print(s));
    }

    private List<String> findMostPopular(String[] words, int kMost ) {

        Map<String, Integer> frequencies = new HashMap<>();

        // update word frequency map
        for( String word: words) {
            frequencies.put(word, frequencies.getOrDefault(word, 0) + 1);
        }

        List<String>[] buckets = new List[words.length+1];
        // pivot freqs to buckets
        for( String word : frequencies.keySet()) {
            Integer freq = frequencies.get(word);
            if (buckets[freq] == null)
                buckets[freq] = new LinkedList<>();
            buckets[freq].add(word);
        }

        List<String> result = new ArrayList<>(kMost);
        int k = kMost;
        for(int i = buckets.length-1; i > 0 && k > 0; i--) {
            if (buckets[i] != null)
                for(int j = 0; j < buckets[i].size() && k > 0; j++) {
                    result.add(buckets[i].get(j));
                    k--;
                }
        }

        return result;
    }
}
