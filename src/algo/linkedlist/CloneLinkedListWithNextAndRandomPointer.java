package algo.linkedlist;

import java.util.HashMap;

public class CloneLinkedListWithNextAndRandomPointer {
    public void test() {

        LinkedNodeWithRandom node1 = new LinkedNodeWithRandom();
        LinkedNodeWithRandom node2 = new LinkedNodeWithRandom();
        LinkedNodeWithRandom node3 = new LinkedNodeWithRandom();
        LinkedNodeWithRandom node4 = new LinkedNodeWithRandom();

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;

        node1.random = node4;
        node3.random = node3;

        LinkedNodeWithRandom cloned = clone(node1);




    }

    private LinkedNodeWithRandom clone(LinkedNodeWithRandom root) {
        HashMap<LinkedNodeWithRandom, LinkedNodeWithRandom> clonedNext = new HashMap<>();

        LinkedNodeWithRandom node = root;

        // first pass make clones
        while (node != null) {
            LinkedNodeWithRandom value = new LinkedNodeWithRandom();
            clonedNext.put(root, value);
            node = node.next;
        }


        // second pass assign ref
        node = root;
        LinkedNodeWithRandom newRoot = clonedNext.get(root);
        LinkedNodeWithRandom newNode = newRoot;
        while (node != null) {
            newNode.next = clonedNext.get(node.next);
            newNode.random = clonedNext.get(node.random);
            node = node.next;
            newNode = newNode.next;
        }
        return newRoot;
    }

}
