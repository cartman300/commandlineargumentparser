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
			// Raw command line without exe path
			Console.WriteLine("{0}\n", ArgumentParser.CommandLine);

			// Get exe path
			Console.WriteLine("Executable path = {0}", ArgumentParser.ExecutablePath);

			// Get non existing argument
			Guid Guid = ArgumentParser.GetSingle<Guid>("wate");
			Console.WriteLine("guid = {0}", Guid);

			// Get existing arguments
			string Str = ArgumentParser.GetSingle<string>();
			Console.WriteLine("string = {0}", Str);

			Player P = ArgumentParser.GetSingle<Player>();
			Console.WriteLine("player = {0}", P);

			float F = ArgumentParser.GetSingle<float>("float");
			Console.WriteLine("float = {0}", F);

			float[] F2 = ArgumentParser.Get<float>("float");
			Console.WriteLine("floats = {0}", string.Join("; ", F2));

			IPAddress IP = ArgumentParser.GetSingle<IPAddress>();
			Console.WriteLine("ipaddress = {0}", IP);
		}
	}
}
