using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Console_3d
{
	public static class ConsoleHelper
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		private static extern bool WriteConsoleOutputCharacter(IntPtr hConsoleOutput, char[] lpCharacter, uint nLength,
			Point16 dwWriteCoord, out uint lpNumberOfCharsWritten);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleScreenBufferSize(IntPtr hConsoleOutput, Point16 dwSize);

		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleWindowInfo(
			IntPtr hConsoleOutput,
			bool bAbsolute,
			ref SmallRect lpConsoleWindow
		);

		private const int STD_OUTPUT_HANDLE = -11;
		private const int STD_INPUT_HANDLE = -10;
		private const int STD_ERROR_HANDLE = -12;
		private static readonly IntPtr _stdOut = GetStdHandle(STD_OUTPUT_HANDLE);

		[StructLayout(LayoutKind.Sequential)]
		private struct Point16
		{
			public short X;
			public short Y;

			public Point16(short x, short y)
				=> (X, Y) = (x, y);
		};

		public static void WriteToBufferAt(char[] text, int x, int y)
		{
			WriteConsoleOutputCharacter(_stdOut, text, (uint) text.Length, new Point16((short) x, (short) y),
				out uint _);
		}

		private struct SmallRect
		{
			public short Left;
			public short Top;
			public short Right;
			public short Bottom;
		}

		public static void SetWindow(short width, short height)
		{
			Point16 coord = new Point16 {X = width, Y = height};
			SmallRect rect = new SmallRect
				{Top = 0, Left = 0, Bottom = (short) (height - 1), Right = (short) (width - 1)};
			IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);
			SetConsoleScreenBufferSize(handle, coord);
			SetConsoleWindowInfo(handle, true, ref rect);
		}
	}
}