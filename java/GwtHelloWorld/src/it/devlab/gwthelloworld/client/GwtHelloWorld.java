package it.devlab.gwthelloworld.client;

import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.user.client.ui.RootLayoutPanel;

public class GwtHelloWorld implements EntryPoint {
	public void onModuleLoad() {
		RootLayoutPanel.get().add(new MainComposite());
	}
}
