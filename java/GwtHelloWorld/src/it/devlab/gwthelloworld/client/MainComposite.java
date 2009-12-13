package it.devlab.gwthelloworld.client;

import com.google.gwt.core.client.GWT;
import com.google.gwt.uibinder.client.UiBinder;
import com.google.gwt.uibinder.client.UiField;
import com.google.gwt.user.client.Command;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.CheckBox;
import com.google.gwt.user.client.ui.Composite;
import com.google.gwt.user.client.ui.DockLayoutPanel;
import com.google.gwt.user.client.ui.MenuItem;
import com.google.gwt.user.client.ui.PushButton;
import com.google.gwt.user.client.ui.Tree;
import com.google.gwt.user.client.ui.TreeItem;

public class MainComposite extends Composite {
	interface MainUiBinder extends UiBinder<DockLayoutPanel, MainComposite> {
	}

	private static MainUiBinder uiBinder = GWT.create(MainUiBinder.class);

	@UiField
	MenuItem menuItem11;

	@UiField
	MenuItem menuItem121;

	@UiField
	MenuItem menuItem122;

	@UiField
	Tree tree;

	@UiField
	DockLayoutPanel dock;

	public MainComposite() {
		initWidget(uiBinder.createAndBindUi(this));
		Command cmd = new Command() {
			public void execute() {
				Window.alert("You selected a menu item!");
			}
		};
		menuItem11.setCommand(cmd);
		menuItem121.setCommand(cmd);
		menuItem122.setCommand(cmd);

		TreeItem root = new TreeItem("root");
		root.addItem("item0");
		root.addItem("item1");
		root.addItem("item2");

		// Add a CheckBox to the tree
		TreeItem item = new TreeItem(new CheckBox("item3"));
		root.addItem(item);

		tree.addItem(root);
		
		new PushButton().setWidth(width)
//		dock.setSize("7em", "2em");
		
	}
}
