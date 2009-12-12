package it.devlab.samegame;

public class Item {
	private final Sprite sprite;
	
	private boolean selected;

	private int color;

	private int xMovement;
	private int yMovement;

	public Item() {
		this(0, false, null);
	}

	public Item(int color, boolean selected, Sprite sprite) {
		this.color = color;
		this.selected = selected;
		this.sprite = sprite;
	}

	public boolean isSelected() {
		return selected;
	}

	public void setSelected(boolean selected) {
		this.selected = selected;
	}

	public void setColor(int color) {
		this.color = color;
	}

	public int getColor() {
		return color;
	}

	public void setXMovement(int xMovement) {
		this.xMovement = xMovement;
	}

	public int getXMovement() {
		return xMovement;
	}

	public void setYMovement(int yMovement) {
		this.yMovement = yMovement;
	}

	public int getYMovement() {
		return yMovement;
	}

	public Sprite getSprite() {
		return sprite;
	}

}
