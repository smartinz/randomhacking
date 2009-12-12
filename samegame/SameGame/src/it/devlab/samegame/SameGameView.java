package it.devlab.samegame;

import java.util.List;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.util.AttributeSet;

public class SameGameView extends GameView {

	private final Controller controller;

	public SameGameView(Context context, AttributeSet attrs) {
		super(context, attrs);

		Bitmap bitmap = BitmapFactory.decodeResource(context.getResources(), R.drawable.carrots);
		Bitmap[] bitmaps = new Bitmap[4];
		for (int i = 0; i < 4; i++) {
			int y = (bitmap.getHeight() / 4) * i;
			bitmaps[i] = Bitmap.createBitmap(bitmap, 0, y, bitmap.getWidth(), bitmap.getHeight() / 4);
		}

		SpriteFactory spriteFactory = new SpriteFactory(bitmaps);
		GridBuilder gridBuilder = new GridBuilder(spriteFactory);
		controller = new Controller(gridBuilder);
		controller.newGame();
	}

	@Override
	public void gameLoop(Canvas canvas) {
		canvas.drawARGB(255, 0, 0, 0);

		List<Sprite> sprites = controller.getScene(canvas.getWidth(), canvas.getHeight());
		for (Sprite sprite : sprites) {
			sprite.draw(canvas);
		}
	}

}
