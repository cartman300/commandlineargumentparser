using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CARP {
	public static class ArgumentParser {
		static bool Parsed = false;
		static string CmdLine;
		static string ExecutablePath;
		static Dictionary<string, List<string>> Switches;
		static string CurrentSwitch;

		public static IEnumerable<KeyValuePair<string, string[]>> All {
			get {
				Parse();

				foreach (var V in Switches)
					yield return new KeyValuePair<string, string[]>(V.Key, V.Value.ToArray());
			}
		}

		static void Parse() {
			if (Parsed)
				return;
			Parsed = true;
			CmdLine = Environment.CommandLine;
			Switches = new Dictionary<string, List<string>>();

			bool InQuote = false;
			StringBuilder CurTok = new StringBuilder();

			/*Console.WriteLine(CmdLine);
			Console.WriteLine();*/

			for (int i = 0; i < CmdLine.Length; i++) {
				char C = CmdLine[i];
				char PC = i > 0 ? CmdLine[i - 1] : (char)0;
				char PPC = i > 1 ? CmdLine[i - 2] : (char)0;

				if (C == '\"') {
					if (!InQuote) {
						InQuote = true;
						if (CurTok.Length > 0)
							EmitToken(CurTok.ToString());
						CurTok.Clear();
						//CurTok.Append(C);
					} else if (PC != '\\' || (PC == '\\' && PPC == '\\')) {
						InQuote = false;
						//CurTok.Append(C);
						EmitToken(CurTok.ToString());
						CurTok.Clear();
					} else
						CurTok.Append(C);
					continue;
				}

				if (!InQuote && char.IsWhiteSpace(C) && CurTok.Length > 0) {
					EmitToken(CurTok.ToString());
					CurTok.Clear();
				} else if (!char.IsWhiteSpace(C) || InQuote)
					CurTok.Append(C);
			}

			if (CurTok.Length > 0)
				EmitToken(CurTok.ToString());
		}

		static void EmitToken(string Tok) {
			Tok = Tok.Replace("\\\\", "\\").Replace("\\\"", "\"");

			if (Tok.StartsWith("--")) {
				EmitSwitch(Tok.Substring(2));
				return;
			} else if (Tok.StartsWith("-")) {
				EmitSwitch(Tok.Substring(1, 1));
				if (Tok.Length > 2)
					EmitToken(Tok.Substring(2));
				return;
			}

			if (CurrentSwitch == null)
				ExecutablePath = Tok;
			else
				Switches[CurrentSwitch].Add(Tok);
		}

		static void EmitSwitch(string S) {
			CurrentSwitch = S;
			if (!Switches.ContainsKey(CurrentSwitch))
				Switches.Add(CurrentSwitch, new List<string>());
		}

		public static string GetExecutablePath() {
			Parse();
			return ExecutablePath;
		}

		public static string[] Get(string Name) {
			Parse();

			if (Switches.ContainsKey(Name))
				return Switches[Name].ToArray();
			return null;
		}

		public static string GetSingle(string Name) {
			string[] Values = Get(Name);
			if (Values != null)
				return Values[Values.Length - 1];
			return null;
		}

		public static T GetSingle<T>(string Name) {
			if (typeof(T) == typeof(string))
				return (T)(object)GetSingle(Name);
			else if (typeof(T) == typeof(int))
				return (T)(object)int.Parse(GetSingle(Name));
			else if (typeof(T) == typeof(float))
				return (T)(object)float.Parse(GetSingle(Name), CultureInfo.InvariantCulture);
			else if (typeof(T) == typeof(bool))
				return (T)(object)Defined(Name);
			else
				throw new NotImplementedException();
		}

		public static bool Defined(string Name) {
			return Get(Name) != null;
		}
	}
}
