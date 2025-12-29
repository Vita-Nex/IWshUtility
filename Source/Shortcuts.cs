using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Windows.Shell
{
	public static class Shortcuts
	{
		public static void CreateShortcut(string location, string path, string target, string args, string name, string desc)
		{
			_ = Directory.CreateDirectory(location);

			location = Path.Combine(location, $"{name}.lnk");

			if (File.Exists(location))
			{
				File.Delete(location);
			}

			var shortcut = Shell.CreateShortcut(location);

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
		}

		public static Task CreateShortcutAsync(string location, string path, string target, string args, string name, string desc, CancellationToken token = default)
		{
			return Task.Run(() => CreateShortcut(location, path, target, args, name, desc), token);
		}
	}
}
