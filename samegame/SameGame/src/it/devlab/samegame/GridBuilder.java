package it.devlab.samegame;

import java.util.Random;

public class GridBuilder {

	private final SpriteFactory spriteFactory;

	public GridBuilder(SpriteFactory spriteFactory) {
		this.spriteFactory = spriteFactory;
	}

	public Grid build() {
		return build(10, 10, 4);
	}

	public Grid build(int width, int height, int numerOfColors) {
		Item[][] items = new Item[width][height];
		Random randomizer = new Random(System.currentTimeMillis());
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				int color = randomizer.nextInt(numerOfColors);
				items[x][y] = new Item(color, false, spriteFactory.create(color));
			}
		}
		return new Grid(items);
	}
}
