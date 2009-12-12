package it.devlab.samegame.tests;

import it.devlab.samegame.Grid;
import it.devlab.samegame.Item;
import junit.framework.TestCase;

public class GridTest extends TestCase {

	Item[][] gridItems;
	Grid target;

	private static int countSelected(Item[][] gridItems) {
		int count = 0;
		for (int i = 0; i < gridItems.length; i++)
			for (int j = 0; j < gridItems[0].length; j++)
				if (gridItems[i][j] != null && gridItems[i][j].isSelected())
					count++;
		return count;
	}

	public void setUp() {
		gridItems = new Item[][] { { new Item(), new Item(), new Item() }, { new Item(), new Item(), new Item() }, { new Item(), new Item(), new Item() } };
		target = new Grid(gridItems);
	}

	public void test_when_selecting_an_item_without_similar_items_around_should_select_just_that_item() {
		gridItems[1][1].setColor(1);
		target.select(1, 1);
		assertTrue(gridItems[1][1].isSelected());
		assertEquals(1, countSelected(gridItems));
	}

	public void test_when_selecting_an_item_with_similar_items_around_should_select_all_items() {
		gridItems[1][0].setColor(1);
		gridItems[2][0].setColor(1);
		gridItems[1][1].setColor(1);
		gridItems[0][2].setColor(1);
		gridItems[1][2].setColor(1);
		target.select(2, 0);
		assertTrue(gridItems[1][0].isSelected());
		assertTrue(gridItems[2][0].isSelected());
		assertTrue(gridItems[1][1].isSelected());
		assertTrue(gridItems[0][2].isSelected());
		assertTrue(gridItems[1][2].isSelected());
		assertEquals(5, countSelected(gridItems));
	}

	public void test_similar_diagonal_items_sould_not_be_considered_when_propagating_selection() {
		gridItems[2][0].setColor(1);
		gridItems[1][1].setColor(1);
		gridItems[0][2].setColor(1);
		target.select(1, 1);
		assertTrue(gridItems[1][1].isSelected());
		assertEquals(1, countSelected(gridItems));
	}

	public void test_when_unselecting_should_make_all_grid_uselected() {
		gridItems[2][0].setSelected(true);
		gridItems[1][1].setSelected(true);
		gridItems[0][2].setSelected(true);
		target.unselect();
		assertEquals(0, countSelected(gridItems));
	}

	public void test_after_a_selection_unselected_items_should_have_position_updated() {
		gridItems[0][2].setColor(1);
		gridItems[1][2].setColor(1);
		gridItems[1][1].setColor(1);
		gridItems[2][0].setColor(1);
		gridItems[2][1].setColor(1);
		gridItems[2][2].setColor(1);
		target.select(1, 1);
		assertEquals(1, gridItems[0][0].getXMovement());
		assertEquals(1, gridItems[0][0].getYMovement());
		assertEquals(1, gridItems[0][1].getXMovement());
		assertEquals(1, gridItems[0][1].getYMovement());
		assertEquals(1, gridItems[1][0].getXMovement());
		assertEquals(2, gridItems[1][0].getYMovement());
	}

	public void test_null_items_should_not_be_considered() {
		gridItems[0][0] = null;
		gridItems[1][0] = null;
		gridItems[2][0] = null;
		gridItems[0][1] = null;
		gridItems[0][2] = null;
		gridItems[1][1].setColor(1);
		gridItems[1][2].setColor(1);
		target.select(1, 2);
		assertEquals(2, countSelected(gridItems));
		target.unselect();
		assertEquals(0, countSelected(gridItems));
	}

	public void test_when_pop_updates_the_grid() {
		Item item00 = gridItems[0][0];
		Item item10 = gridItems[1][0];
		Item item01 = gridItems[0][1];
		gridItems[0][2].setColor(1);
		gridItems[1][2].setColor(1);
		gridItems[1][1].setColor(1);
		gridItems[2][0].setColor(1);
		gridItems[2][1].setColor(1);
		gridItems[2][2].setColor(1);

		target.select(1, 1);
		target.pop();

		assertEquals(item10, gridItems[2][2]);
		assertEquals(item00, gridItems[1][1]);
		assertEquals(item01, gridItems[1][2]);
		assertNull(gridItems[0][0]);
		assertNull(gridItems[0][1]);
		assertNull(gridItems[0][2]);
		assertNull(gridItems[1][0]);
		assertNull(gridItems[2][0]);
		assertNull(gridItems[2][1]);
	}
}
