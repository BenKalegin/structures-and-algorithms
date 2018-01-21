package algo.LinkedLists;

public class Reverse {
    static class Node {
        Node next;
        String payload;
    }

    private Node reverse(Node head) {
        Node prior = null;
        Node current = head;
        Node next = current.next;

        current.next = prior;
        while(next != null) {
            prior = current;
            current = next;
            next = current.next;
            current.next = prior;
        }

        return current;
    }

    private Node recursiveReverse(Node head) {
        // A -> BCDEF
        Node next = head.next; // B
        Node tail = next.next; // CDEF
        next.next = head;      // B->A
        Node result = recursiveReverse(tail); // C < D < E < F
        result.next = next;
        return result;
      }

    public void test() {
        Node n1 = new Node();
        n1.payload = "A";
        Node n2 = new Node();
        n2.payload = "B";
        Node n3 = new Node();
        n3.payload = "C";
        Node n4 = new Node();
        n4.payload = "D";

        n1.next = n2;
        n2.next = n3;
        n3.next = n4;
        n4.next = null;

        Node head = n1;

        Node reversed = reverse(head);
        while (reversed != null) {
            System.out.println(reversed.payload);
            reversed = reversed.next;
        }
    }
}
