package algo.linkedlist;

public class ReverseList {
    private LinkedItem solve(LinkedItem head) {
        // 1, 2: 1->2   2 -> 3 -> 4
        // 2, 3: 2 -> 1 3 -> 4
        // 3, 4: 3 -> 2 -> 1  4 -> 5 ->
        // 4, 5: 4 -> 3...  5 -> 6

        if (head == null)
            return null;

        LinkedItem oldHead = head.next;
        LinkedItem newHead = head;

        if (newHead == null)
            return oldHead;


        while (oldHead != null) {

//            newHead.dump();
//            System.out.print(" ");
//            oldHead.dump();
//            System.out.println(" ");


            LinkedItem saveNewHead = newHead;
            newHead = oldHead;
            oldHead = oldHead.next;
            newHead.next = saveNewHead;
        }

        head.next = null;
        return newHead;
    }

    public void test() {
        LinkedItem item1 = new LinkedItem();
        item1.payload = "1";
        LinkedItem item2 = new LinkedItem();
        item2.payload = "2";
        item1.next = item2;
        LinkedItem item3 = new LinkedItem();
        item3.payload = "3";
        item2.next = item3;
        LinkedItem item4 = new LinkedItem();
        item4.payload = "4";
        item3.next = item4;

        solve(item1).dump();
        System.out.println("");
    }
}
