namespace IWshUtility
{
	public class Shortcuts
	{
		public static bool CreateShortcut(string location, string path, string target, string args, string name, string desc)
		{
			if (String.IsNullOrWhiteSpace(location) || String.IsNullOrWhiteSpace(target))
			{
				return false;
			}

			try
			{
				_ = Directory.CreateDirectory(location);

				location = Path.Combine(location, $"{name}.lnk");

				if (File.Exists(location))
				{
					File.Delete(location);
				}

				var shell = new IWshRuntimeLibrary.WshShell();
				var shortcut = shell.CreateShortcut(location);

				if (!String.IsNullOrWhiteSpace(args))
				{
					shortcut.Arguments = args;
				}

				if (!String.IsNullOrWhiteSpace(desc))
				{
					shortcut.Description = desc;
				}

				shortcut.WorkingDirectory = path;

				shortcut.TargetPath = Path.Combine(path, target);

				shortcut.Save();

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
