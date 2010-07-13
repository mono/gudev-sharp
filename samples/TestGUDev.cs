using System;

using GLib;

using GUdev;

public class GUDevTest
{
 	public static void Main(string[] args)
	{
		GLib.GType.Init ();
		GLib.Thread.Init ();

		Client client = new Client (new string[] {null});
		client.Uevent += HandleClientUevent;
		
		Console.WriteLine ("Created client {0}", client.ToString());
		
		foreach (string sub in client.Subsystems) {
//			if (string.IsNullOrEmpty (sub))
//			   continue;
			
			Console.WriteLine ("Looking at subsystem: {0}", sub);
			foreach (Device device in client.QueryBySubsystem (sub)) {
				Console.WriteLine ("Looking at:\n\t {0} ({1})\n\t{2}", string.IsNullOrEmpty (device.Name) ? "nameless device" : device.Name,
					device.Number, device.DeviceFile);
			}
		}
		GLib.MainLoop loop = new GLib.MainLoop ();
		loop.Run ();
	}
	
	protected static void HandleClientUevent (object o, UeventArgs args)
	{
		Console.WriteLine ("Received a {0} signal on {1}", args.Action, 
			(args.Device.HasProperty ("ID_VENDOR") ? args.Device.GetProperty ("ID_VENDOR") : "nameless device"));
	}
}
