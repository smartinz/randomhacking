package it.devlab.samegame;

public class Grid {

	private Item grid[][];
	private int width;
	private int height;

	public Grid(Item[][] grid) {
		this.grid = grid;
		width = grid.length;
		height = grid[0].length;
	}

	public void select(int x, int y) {
		recursivelySelect(x, y);
		calculateMovements();
	}

	public void pop() {
		for (int x = width - 1; x >= 0; x--) {
			for (int y = height - 1; y >= 0; y--) {
				if (!isItemAvailable(x, y))
					break;
				else if (grid[x][y].isSelected())
					grid[x][y] = null;
				else {
					int newX = x + grid[x][y].getXMovement();
					int newY = y + grid[x][y].getYMovement();
					grid[newX][newY] = grid[x][y];
					grid[x][y] = null;
				}
			}
		}
	}

	private void recursivelySelect(int x, int y) {
		if (!isItemAvailable(x, y) || grid[x][y].isSelected())
			return;
		grid[x][y].setSelected(true);
		for (int[] coord : new int[][] { { x - 1, y }, { x + 1, y }, { x, y - 1 }, { x, y + 1 } }) {
			int xx = coord[0], yy = coord[1];
			if (isItemAvailable(xx, yy) && grid[xx][yy].getColor() == grid[x][y].getColor())
				recursivelySelect(xx, yy);
		}
	}

	public boolean isItemAvailable(int x, int y) {
		return (x >= 0 && x < width && y >= 0 && y < height && grid[x][y] != null);
	}

	public void unselect() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (isItemAvailable(x, y)) {
					grid[x][y].setSelected(false);
					grid[x][y].setXMovement(0);
					grid[x][y].setYMovement(0);
				}
			}
		}
	}

	public interface ForEachItemCallback {
		void callback(int x, int y, int color, Sprite sprite);
	}

	public void forEachItem(ForEachItemCallback callback) {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (isItemAvailable(x, y)) {
					callback.callback(x, y, grid[x][y].getColor(), grid[x][y].getSprite());
				}
			}
		}
	}

	private void calculateMovements() {
		int offsetX = 0;
		for (int x = width - 1; x >= 0; x--) {
			boolean columnHasItems = false;
			int offsetY = 0;
			for (int y = height - 1; y >= 0; y--) {
				if (!isItemAvailable(x, y) || grid[x][y].isSelected()) {
					offsetY++;
				} else {
					grid[x][y].setXMovement(offsetX);
					grid[x][y].setYMovement(offsetY);
					columnHasItems = true;
				}
			}
			if (!columnHasItems)
				offsetX++;
		}
	}

	public int getWidth() {
		return width;
	}

	public int getHeight() {
		return height;
	}
}
