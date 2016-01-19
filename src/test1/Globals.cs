using System;
using Irony.Parsing;
using Irony.Ast;
using System.Diagnostics;
using System.Text;

partial class Globals
{
	public static void Main (string[] args)
	{
		var fileContent = LoadFromResource(nameof(test1), "Resources", "ebnf-grammar-2.ebnf");
		ParseWithEtoParse (fileContent, fileContent);
#if false
		// test1.Resources.ebnf-grammar-1.ebnf
		string text_to_compile = LoadFromResource (nameof(test1), "Resources", "ebnf-grammar-1.ebnf");
		ParseWithIrony (text_to_compile);
#endif
	}
	public static void ParseWithEtoParse (string grammar_text, string text_to_compile)
	{

		var style = (Eto.Parse.Grammars.EbnfStyle)(
			(uint)Eto.Parse.Grammars.EbnfStyle.Iso14977 
			& ~( (uint) Eto.Parse.Grammars.EbnfStyle.WhitespaceSeparator )
			| (uint) Eto.Parse.Grammars.EbnfStyle.EscapeTerminalStrings);

		Eto.Parse.Grammars.EbnfGrammar grammar;
		Eto.Parse.Grammar parser;
		try
		{
			grammar = new Eto.Parse.Grammars.EbnfGrammar(style);
			parser = grammar.Build(grammar_text, "grammar");
		}
		catch (Exception ex)
		{
			Trace.WriteLine (ex.ToString ());
			/*
	System.ArgumentException: the topParser specified is not found in this ebnf
	  at Eto.Parse.Grammars.EbnfGrammar.Build (System.String bnf, System.String startParserName) [0x00048] in <filename unknown>:0 
	  at Globals.Main (System.String[] args) [0x0002b] in /var/calculate/remote/distfiles/egit-src/SqlParser-on-EtoParse.git/test1/Program.cs:20 
	*/
			throw;
		}

		var match = parser.Match(text_to_compile);
		if (match.Success == false) {
			Console.Out.WriteLine ("No luck!");
		}
		else {
	//		DumpAllMatches (match, nameOfTheStartingRule);
		}
	}
/*public static void DumpAllMatches(Match m, string name)
{
	for (int pos = 0; pos < m.Matches.Count; pos++)
	{
		Match nm = m.Matches [pos];
		var full_name = nm.Name + " <- " + name;

		bool low = IsTooLow (nm.Name);
		if (nm.Text != m.Text) {
			string fmt = "\"{0}\"" + Environment.NewLine + "\t" + "{1}";
			Console.WriteLine (fmt, nm.Text, full_name);
		}
		if (!low) {
			DumpAllMatches (nm, full_name);
		}
	}
}
static bool IsTooLow(string rule)
{
	if (rule == "identifier") return true;
	if (rule == "character_string_literal") return true;
	return false;
}*/
	public static void ParseWithIrony (/*string grammar_text,*/ string text_to_compile)
	{
		var grammar = new EbnfGrammar();
		var parser = new Irony.Parsing.Parser(grammar);
		var errors = parser.Language.Errors;
		if (errors.Count > 0)
		{
			var msg = new StringBuilder("Unexpected grammar contains error(s):" + Environment.NewLine);
			foreach (var e in errors) {
				msg.AppendFormat ("{0}" + Environment.NewLine, e.ToString ());
			}
			Console.WriteLine (msg.ToString ());
			throw new Exception(msg.ToString());
		}
		var tree = parser.Parse (text_to_compile);
		Debug.Assert (tree != null); // to suppress warning and for expression evaluator
		Debug.Assert (tree.Status == ParseTreeStatus.Parsed);
	}
}
