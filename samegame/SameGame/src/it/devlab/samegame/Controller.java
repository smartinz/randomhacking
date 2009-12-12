package it.devlab.samegame;

import java.util.ArrayList;
import java.util.List;

public class Controller {

	private final GridBuilder gridBuilder;
	private Grid grid;

	public Controller(GridBuilder gridBuilder) {
		this.gridBuilder = gridBuilder;
	}

	public void newGame() {
		grid = gridBuilder.build();
	}

	public List<Sprite> getScene(int canvasWidth, int canvasHeight) {
		int spriteWidth = canvasWidth / grid.getWidth();
		int spriteHeight = canvasHeight / grid.getHeight();
		final int spriteSize = Math.min(spriteWidth, spriteHeight);
		
		final List<Sprite> sprites = new ArrayList<Sprite>();
		grid.forEachItem(new Grid.ForEachItemCallback() {
			@Override
			public void callback(int x, int y, int color, Sprite sprite) {
				sprite.setPosition(x * spriteSize + spriteSize / 2, y * spriteSize + spriteSize / 2);
				sprite.setSize(spriteSize, spriteSize);
				sprites.add(sprite);
			}
		});
		return sprites;
	}
}
