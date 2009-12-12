package it.devlab.samegame.tests;

import it.devlab.samegame.GameView;
import it.devlab.samegame.Item;
import it.devlab.samegame.Selector;
import it.devlab.samegame.Sprite;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.PointF;
import android.util.AttributeSet;
import android.view.MotionEvent;


public class TestView extends GameView {

	private Sprite landerSprite;
	private Sprite earthSprite;
	private Sprite marsSprite;
	private Selector selector;
	private PointF lastTouchPoint;
	private boolean selectionIsChanged;

	public TestView(Context context, AttributeSet attrs) {
		super(context, attrs);

		landerSprite = new Sprite(BitmapFactory.decodeResource(context.getResources(), R.drawable.lander_plain));
		Bitmap bitmap = BitmapFactory.decodeResource(context.getResources(), R.drawable.planets);
		Bitmap[] bitmaps = new Bitmap[4];
		for (int i = 0; i < 4; i++) {
			int y = (bitmap.getHeight() / 4) * i;
			bitmaps[i] = Bitmap.createBitmap(bitmap, 0, y, bitmap.getWidth(), bitmap.getHeight() / 4);
		}
		
		earthSprite = new Sprite(bitmaps[0], 16);
		marsSprite = new Sprite(bitmaps[1], 16);

		
		Bitmap selectorBitmap = BitmapFactory.decodeResource(context.getResources(), R.drawable.selector);
		selector = new Selector(selectorBitmap);		

		lastTouchPoint = new PointF();
		selectionIsChanged = false;
	}

	private int degrees = 0;

	@Override
	public void gameLoop(Canvas canvas) {
		canvas.drawARGB(255, 0, 0, 0);
		
		landerSprite.setPosition(canvas.getWidth() / 2, canvas.getHeight() / 2);
		landerSprite.setRotation(degrees);
		landerSprite.draw(canvas);

		earthSprite.setPosition(100, 100);
		earthSprite.setFrameIndex(degrees / 5);
		earthSprite.draw(canvas);

		marsSprite.setPosition(50, 300);
		marsSprite.setFrameIndex(degrees / 5);
		marsSprite.draw(canvas);

		// draw a fucking debug grid
		Paint linePaint = new Paint(); 
		linePaint.setColor(Color.WHITE); 
		linePaint.setStyle(Paint.Style.STROKE);
		for (int i = 0; i < 8; i++) {
			canvas.drawLine(40*i, 0, 40*i, 300, linePaint);
			canvas.drawLine(0, 40*i, 300, 40*i, linePaint);
		}

		// selector management
		if (selectionIsChanged) {
			Item[] selectedItems = getSelectedItems(lastTouchPoint);
			selector.Rebuild(selectedItems);
			selectionIsChanged = false;
		}
		selector.Draw(canvas);
		

		Paint paint = new Paint();
		paint.setAntiAlias(true);
		paint.setARGB(255, 0, 255, 0);

		degrees++;
	}
	
	private Item[] getSelectedItems(PointF lastTouchPoint) {
		Item[] selected = new Item[3];
		return selected;
	}
	
	@Override
	public boolean onTouchEvent(MotionEvent event) {        
        switch (event.getAction()) {
            case MotionEvent.ACTION_DOWN:
                break;
            case MotionEvent.ACTION_MOVE:
                break;
            case MotionEvent.ACTION_UP:
        		lastTouchPoint.x = event.getX();
        		lastTouchPoint.y = event.getY();
        		selectionIsChanged = true;
                break;
        }
        return true;
	}
}
