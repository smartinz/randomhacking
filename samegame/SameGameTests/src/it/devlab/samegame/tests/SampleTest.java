package it.devlab.samegame.tests;

import junit.framework.TestCase;

// Per eseguire i tests:
// Installare il pacchetto sull'emulatore
// Eseguire da riga di comando:
// android-sdk-linux_x86-1.0_r2/tools/adb shell am instrument -w it.devlab.samegame.tests/android.test.InstrumentationTestRunner
// Per debuggare aggiungi l'opzione "-e debug true"
public class SampleTest extends TestCase {
	public void testSuccess() {
		assertTrue(true);
	}
	
}
