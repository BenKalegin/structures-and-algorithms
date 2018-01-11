package algo.linkedlist;

import java.io.Console;

public class LinkedItem {
    public LinkedItem next;
    public String payload;
    public void dump() {
        System.out.print(payload);
        if (next != null) {
            System.out.print(" > ");
            next.dump();
        }
    }
}


