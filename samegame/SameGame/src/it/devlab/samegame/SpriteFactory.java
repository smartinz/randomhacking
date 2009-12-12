package it.devlab.samegame;

import android.graphics.Bitmap;

public class SpriteFactory {

	private final Bitmap[] bitmaps;

	public SpriteFactory(Bitmap[] bitmaps) {
		this.bitmaps = bitmaps;
	}

	public Sprite create(int color) {
		return new Sprite(bitmaps[color], 16);
	}
}
