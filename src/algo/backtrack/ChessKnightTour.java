package algo.backtrack;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;

public class ChessKnightTour{

    private static final int NotVisited = Integer.MAX_VALUE;
    private int boardWidth;
    private Map<Position, Integer> cellVisits;

    public ChessKnightTour(int boardWidth) {

        this.boardWidth = boardWidth;
        cellVisits = new HashMap<>();
    }

    private Iterable<Position> possibleMoveFrom(Position position) {
        LinkedList<Position> result = new LinkedList<>();

        if (position.x > 1) {
            if (position.y < boardWidth-1)
                result.add(new Position(position.x-2, position.y+1));
            if (position.y > 0)
                result.add(new Position(position.x-2, position.y-1));
        }
        if (position.x < boardWidth-2) {
            if (position.y < boardWidth-1)
                result.add(new Position(position.x+2, position.y+1));
            if (position.y > 0)
                result.add(new Position(position.x+2, position.y-1));
        }
        if (position.y > 1) {
            if (position.x < boardWidth-1)
                result.add(new Position(position.x+1, position.y-2));
            if (position.x > 0)
                result.add(new Position(position.x-1, position.y-2));
        }
        if (position.y < boardWidth-2) {
            if (position.x < boardWidth-1)
                result.add(new Position(position.x+1, position.y+2));
            if (position.x > 0)
                result.add(new Position(position.x-1, position.y+2));
        }
        return result;
    }

    private static int found = 0;

    private int tryMovesFrom(Position position, int generation) {
        int result = 0;
        for(Position movedTo: possibleMoveFrom(position)) {
            if (cellVisits.getOrDefault(movedTo, NotVisited) > generation) {
                cellVisits.put(movedTo, generation);
                if (generation == boardWidth * boardWidth) {
                    for(int y = 0; y < boardWidth; y++) {
                        for(int x = 0; x < boardWidth; x++)
                            System.out.printf("|%2d", cellVisits.get(new Position(x, y)));
                        System.out.println("|");
                    }
                    System.out.println("");
                    result++;
                }
                else
                    result += tryMovesFrom(movedTo, generation + 1);
                cellVisits.put(movedTo, NotVisited);
            }
        }
        return result;
    }

    public void findPossiblePaths() {

        Position initialPosition = new Position(0, 0);
        int generation = 1;
        cellVisits.put(initialPosition, generation);
        int totalPaths = tryMovesFrom(initialPosition, generation+1);
        System.out.println("Number of open paths: " + totalPaths);
    }
}
