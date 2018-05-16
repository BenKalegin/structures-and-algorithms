package algo.linkedlist;

public class LinkedNodeWithRandom extends LinkedItem {
    public LinkedNodeWithRandom random;
    public LinkedNodeWithRandom next;
    public String payload;
    public void dump() {
        System.out.print(payload);
        if (next != null) {
            System.out.print(" > ");
            next.dump();
        }
    }
}
