using IWshRuntimeLibrary;

using System.Runtime.CompilerServices;

namespace System.Windows.Shell
{
	public static class Shell
	{
		private const MethodImplOptions METHOD_IMPL_OPTS = MethodImplOptions.AggressiveInlining;

		[ThreadStatic]
		private static readonly WshShell _Instance;

		static Shell()
		{
#if NET5_0_OR_GREATER
			_Instance = new();
#else
			_Instance = new WshShell();
#endif
		}

		public static IWshEnvironment Environment
		{
			[MethodImpl(METHOD_IMPL_OPTS)]
			get => _Instance.Environment;
		}

		public static IWshCollection SpecialFolders
		{
			[MethodImpl(METHOD_IMPL_OPTS)]
			get => _Instance.SpecialFolders;
		}

		public static string CurrentDirectory
		{
			[MethodImpl(METHOD_IMPL_OPTS)]
			get => _Instance.CurrentDirectory;

			[MethodImpl(METHOD_IMPL_OPTS)]
			set => _Instance.CurrentDirectory = value;
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static int Run(string command, ref object windowStyle, ref object waitOnReturn)
		{
			return _Instance.Run(command, ref windowStyle, ref waitOnReturn);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static int Popup(string text, ref object secondsToWait, ref object title, ref object type)
		{
			return _Instance.Popup(text, ref secondsToWait, ref title, ref type);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static dynamic CreateShortcut(string pathLink)
		{
			return _Instance.CreateShortcut(pathLink);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static string ExpandEnvironmentStrings(string source)
		{
			return _Instance.ExpandEnvironmentStrings(source);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static dynamic RegRead(string name)
		{
			return _Instance.RegRead(name);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static void RegWrite(string name, ref object value, ref object type)
		{
			_Instance.RegWrite(name, ref value, ref type);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static void RegDelete(string name)
		{
			_Instance.RegDelete(name);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static bool LogEvent(ref object type, string message, string target = "")
		{
			return _Instance.LogEvent(ref type, message, target);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static bool AppActivate(ref object app, ref object wait)
		{
			return _Instance.AppActivate(ref app, ref wait);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static void SendKeys(string keys, ref object wait)
		{
			_Instance.SendKeys(keys, ref wait);
		}

		[MethodImpl(METHOD_IMPL_OPTS)]
		public static WshExec Exec(string command)
		{
			return _Instance.Exec(command);
		}
	}
}
