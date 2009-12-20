using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AssemblaTimeTracker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			notifyIcon.Icon = Icon;
		}

		private void LoadSpaces()
		{
			IDictionary<string, string> spaces = BuildRepository().GetSpaces();
			spaceComboBox.DataSource = spaces.Select(s => new{
				Id = s.Key,
				Description = s.Value
			}).OrderBy(x => x.Description).ToList();
		}

		private AssemblaRepository BuildRepository()
		{
			return new AssemblaRepository(new HttpXml(usernameTextBox.Text, passwordTextBox.Text));
		}

		private void LoadTickets()
		{
			var spaceId = spaceComboBox.SelectedValue as string;
			if(spaceId != null)
			{
				IDictionary<string, string> tickets = BuildRepository().GetActiveTickets(spaceId);
				ticketComboBox.DataSource = tickets.Select(s => new{
					Id = s.Key,
					Description = string.Format("{0} - {1}", s.Key, s.Value)
				}).OrderBy(x => x.Description).ToList();
			}
		}

		private void spaceComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			LoadTickets();
		}

		private void loadButton_Click(object sender, EventArgs e)
		{
			try
			{
				LoadSpaces();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			StartTimer();
			notifyIcon.Visible = true;
			Hide();
		}

		private void StartTimer()
		{
			timer.Enabled = false;
			timer.Interval = Convert.ToInt32(double.Parse(timerTextBox.Text, CultureInfo.InvariantCulture)*60*60*1000);
			timer.Enabled = true;
		}

		private void PauseTimer()
		{
			timer.Enabled = false;
		}

		private void ResumeTimer()
		{
			timer.Enabled = true;
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			PauseTimer();
			notifyIcon.Visible = false;
			Show();
		}
	}
}