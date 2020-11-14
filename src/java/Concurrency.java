package java;

import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class Concurrency {
    public static void test() {
        var reentrant = new ReentrantReadWriteLock();
    }
}
