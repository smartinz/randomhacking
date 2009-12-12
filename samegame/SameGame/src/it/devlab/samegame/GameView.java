package it.devlab.samegame;

import android.content.Context;
import android.graphics.Canvas;
import android.util.AttributeSet;
import android.view.SurfaceHolder;
import android.view.SurfaceView;

public abstract class GameView extends SurfaceView implements SurfaceHolder.Callback, Runnable {

	private final Thread mainLoopThread;
	private boolean mainLoopRunning;

	private final SurfaceHolder surfaceHolder;

	public GameView(Context context, AttributeSet attrs) {
		super(context, attrs);

		surfaceHolder = getHolder();
		surfaceHolder.addCallback(this);

		mainLoopThread = new Thread(this);
		mainLoopRunning = false;

		setFocusable(true);
	}

	@Override
	public void surfaceChanged(SurfaceHolder holder, int format, int width, int height) {
	}

	@Override
	public void surfaceCreated(SurfaceHolder holder) {
		mainLoopRunning = true;
		mainLoopThread.start();
	}

	@Override
	public void surfaceDestroyed(SurfaceHolder holder) {
		mainLoopRunning = false;
		boolean retry = true;
		while (retry) {
			try {
				mainLoopThread.join();
				retry = false;
			} catch (InterruptedException e) {
			}
		}
	}

	@Override
	public void run() {
		while (mainLoopRunning) {
			Canvas canvas = null;
			try {
				canvas = surfaceHolder.lockCanvas(null);
				synchronized (surfaceHolder) {
					gameLoop(canvas);
				}
			} finally {
				if (canvas != null) {
					surfaceHolder.unlockCanvasAndPost(canvas);
				}
			}
		}
	}

	public abstract void gameLoop(Canvas canvas);

}
