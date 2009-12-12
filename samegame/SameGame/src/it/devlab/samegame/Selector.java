package it.devlab.samegame;

import android.graphics.Bitmap;
import android.graphics.Canvas;

public class Selector {
	
	private Sprite selectorSprite;
	private int x;
	private int y;
		
	public Selector(Bitmap bitmap)
	{
		selectorSprite = new Sprite(bitmap, 6);
		
		x=0;
		y=0;
	}
	public void Rebuild(Item[] selectedItems){
		//TODO: ricostruisce la struttura interna di tratteggi necessari per contornare gli item selezionati
		x+=10;
		y+=10;
	}
	public void Draw(Canvas canvas){
		//TODO: disegna il tratteggio costruito sulla precedente selezione
		DrawPart(canvas, x,    y,    0);
		DrawPart(canvas, x+40, y,    3);
		DrawPart(canvas, x+40, y+40, 1);
		DrawPart(canvas, x+80, y+40, 3);
		DrawPart(canvas, x+80, y+80, 2);
		DrawPart(canvas, x+40, y+80, 5);
		DrawPart(canvas, x,    y+80, 1);
		DrawPart(canvas, x,    y+40, 4);
	}
	
	private void DrawPart(Canvas canvas, int x, int y, int frame) {
		selectorSprite.setPosition(x, y);
		selectorSprite.setFrameIndex(frame);
		selectorSprite.draw(canvas);
	}

}
