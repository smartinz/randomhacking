using System;
using GalaSoft.MvvmLight.Messaging;

namespace SpikeWpf
{
	public class OpenWorkspaceModal : MessageBase
	{
		public IWorkspace Workspace { get; set; }
		public Action<IWorkspace> Callback { get; set; }

		public OpenWorkspaceModal(IWorkspace content, Action<IWorkspace> callback)
		{
			Workspace = content;
			Callback = callback;
		}

		public void NotifyDone()
		{
			Callback(Workspace);
		}
	}
}