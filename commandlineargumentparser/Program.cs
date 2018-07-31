using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

namespace CARP {
	class Player {
		string PlayerName;

		public Player(string Name) {
			PlayerName = Name;
		}

		public override string ToString() {
			return string.Format("Player named `{0}´", PlayerName);
		}
	}

	class Program {
		static void Main(string[] Args) {
			Console.WriteLine(ArgumentParser.CommandLine);

			foreach (var Arg in ArgumentParser.All)
				Console.WriteLine("{0} = {1}", Arg.Key, string.Join(", ", Arg.Value));

			Console.ForegroundColor = ConsoleColor.Green;

			foreach (var Arg in ArgumentParser.Suffix)
				Console.WriteLine(Arg);

			Console.WriteLine(ArgumentParser.SuffixString);

			Console.ReadLine();
		}
	}
}
