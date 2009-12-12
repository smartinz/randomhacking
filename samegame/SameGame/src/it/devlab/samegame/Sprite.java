package it.devlab.samegame;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Point;
import android.graphics.Rect;

public class Sprite {
	private final Bitmap bitmap;
	private final int frameNumber;
	private final Point position;
	private final Point size;
	private int rotationDegrees;
	private int frameIndex;

	public Sprite(Bitmap bitmap) {
		this(bitmap, 1);
	}

	public Sprite(Bitmap bitmap, int frameNumber) {
		this.bitmap = bitmap;
		this.frameNumber = frameNumber;
		position = new Point(0, 0);
		size = new Point(bitmap.getWidth() / frameNumber, bitmap.getHeight());
		rotationDegrees = 0;
		frameIndex = 0;
	}

	public void setPosition(int x, int y) {
		position.x = x;
		position.y = y;
	}

	public void setSize(int x, int y){
		size.x = x;
		size.y = y;
	}

	public void setRotation(int degrees) {
		rotationDegrees = degrees;
	}
	
	public void setFrameIndex(int index){
		frameIndex = index % frameNumber;
	}

	public void draw(Canvas canvas) {
		canvas.save();
		canvas.rotate(rotationDegrees, position.x, position.y);
		try {
			int frameWidth = bitmap.getWidth() / frameNumber;
			Rect sourceRect = new Rect(frameWidth * frameIndex, 0, frameWidth * (frameIndex + 1), bitmap.getHeight());
			Rect destinationRect = new Rect(position.x - size.x / 2, position.y - size.y / 2, position.x + size.x / 2, position.y + size.y / 2);
			canvas.drawBitmap(bitmap, sourceRect, destinationRect, null);
		} finally {
			canvas.restore();
		}
	}
	
	public int getBitmapWidth(){
		return bitmap.getWidth();
	}

	public int getBitmapHeight(){
		return bitmap.getHeight();
	}
}
