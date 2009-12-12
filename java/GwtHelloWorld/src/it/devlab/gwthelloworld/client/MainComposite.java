package it.devlab.gwthelloworld.client;

import com.google.gwt.core.client.GWT;
import com.google.gwt.uibinder.client.UiBinder;
import com.google.gwt.uibinder.client.UiField;
import com.google.gwt.user.client.Command;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.Composite;
import com.google.gwt.user.client.ui.DockLayoutPanel;
import com.google.gwt.user.client.ui.MenuItem;

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
	}
}
