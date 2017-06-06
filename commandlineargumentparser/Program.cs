using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CARP {
	class Program {
		static void Main(string[] args) {
			args = new string[] { };

			foreach (var Switch in ArgumentParser.All)
				Console.WriteLine("{0} = `{1}´", Switch.Key, string.Join(", ", Switch.Value));
			Console.WriteLine();

			if (ArgumentParser.Defined("print"))
				Console.WriteLine("print(\"{0}\")", string.Join(" ", ArgumentParser.Get("print")));

			if (ArgumentParser.Defined("int"))
				Console.WriteLine("int = {0}", ArgumentParser.GetSingle<int>("int"));

			if (ArgumentParser.Defined("float"))
				Console.WriteLine("float = {0}", ArgumentParser.GetSingle<float>("float"));

			if (ArgumentParser.Defined("D"))
				Console.WriteLine("directories\n> {0}", string.Join("\n> ", string.Join(";", ArgumentParser.Get("D")).Split(';')));

		}
	}
}
