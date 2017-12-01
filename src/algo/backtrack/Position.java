package algo.backtrack;

public class Position {
    public final int x;
    public final int y;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Position position = (Position) o;

        if (x != position.x) return false;
        return y == position.y;
    }

    @Override
    public int hashCode() {
        return 1000 * x + y;
    }

    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
