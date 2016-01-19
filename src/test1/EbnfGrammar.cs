using System;
using Irony.Parsing;
//using Irony.Ast;

[Irony.Parsing.Language("ExpressionEvaluator", "1.0", "Multi-line expression evaluator")]
public class EbnfGrammar : Irony.Parsing.Grammar
{
	public EbnfGrammar()
	{
		// 1. Terminals
		var l_brace = ToTerm("{", "l_brace");
		var r_brace = ToTerm("}", "r_brace");
		var l_par = ToTerm("(", "l_par");
		var r_par = ToTerm(")", "r_par");
		var l_sqbr = ToTerm("[", "l_sqbr");
		var r_sqbr = ToTerm("]", "r_sqbr");
		var assignment = ToTerm(":=", "assignment");
		var assign = ToTerm("=", "assign");
		var comma = ToTerm(",", "comma");
		var question = ToTerm("?", "question");
		var semi = ToTerm(";", "semi");
		var Unknown = ToTerm(String.Empty);

		// 2. Non-terminals
		var letter = new Irony.Parsing.NonTerminal("letter");
		var digit = new Irony.Parsing.NonTerminal("digit");
		var symbol = new Irony.Parsing.NonTerminal("symbol");
		var character = new Irony.Parsing.NonTerminal("character");
		var identifier = new Irony.Parsing.NonTerminal("identifier");
		var terminal = new Irony.Parsing.NonTerminal("terminal");
		var lhs = new Irony.Parsing.NonTerminal("lhs");
		var rhs = new Irony.Parsing.NonTerminal("rhs");
		var rule = new Irony.Parsing.NonTerminal("rule");
		var grammar = new Irony.Parsing.NonTerminal("grammar");

		// 3. rules
		letter.Rule = ToTerm("A") | ToTerm("B") | ToTerm("C") | ToTerm("D") | ToTerm("E")
			| ToTerm("F") | ToTerm("G") | ToTerm("H") | ToTerm("I") | ToTerm("J") | ToTerm("K")
			| ToTerm("L") | ToTerm("M") | ToTerm("N") | ToTerm("O") | ToTerm("P") | ToTerm("Q")
			| ToTerm("R") | ToTerm("S") | ToTerm("T") | ToTerm("U") | ToTerm("V") | ToTerm("W")
			| ToTerm("X") | ToTerm("Y") | ToTerm("Z")
			| ToTerm("a") | ToTerm("b") | ToTerm("c") | ToTerm("d") | ToTerm("e")
			| ToTerm("f") | ToTerm("g") | ToTerm("h") | ToTerm("i") | ToTerm("j") | ToTerm("k")
			| ToTerm("l") | ToTerm("m") | ToTerm("n") | ToTerm("o") | ToTerm("p") | ToTerm("q")
			| ToTerm("r") | ToTerm("s") | ToTerm("t") | ToTerm("u") | ToTerm("v") | ToTerm("w")
			| ToTerm("x") | ToTerm("y") | ToTerm("z")
			;
		digit.Rule = ToTerm ("0") | ToTerm ("1") | ToTerm ("2") | ToTerm ("3") | ToTerm ("4")
			| ToTerm ("5") | ToTerm ("6") | ToTerm ("7") | ToTerm ("8") | ToTerm ("9")
			;
		symbol.Rule = ToTerm("[") | ToTerm("]") | ToTerm("{") | ToTerm("}") | ToTerm("(") | ToTerm(")") | ToTerm("<") | ToTerm(">")
			| ToTerm("'") | ToTerm("\"") | ToTerm("=") | ToTerm("|") | ToTerm(".") | ToTerm(",") | ToTerm(";")
			;
		character.Rule = letter | digit | symbol | ToTerm("_") ;

		var identifier0 = letter | digit | ToTerm("_");
		var identifier1 = MakeStarRule (identifier, identifier0);
		identifier.Rule = letter + identifier1 ;

		var terminal0 = MakeStarRule (terminal, character);
		terminal.Rule = ( ToTerm("'") + character + terminal0 + ToTerm("'") )
			| ( ToTerm("\"") + character + terminal0 + ToTerm("\"") );

		lhs.Rule = identifier;
		rhs.Rule = identifier
			| terminal
			| (ToTerm("[") + rhs + ToTerm("]"))
			| (ToTerm("{") + rhs + ToTerm("}"))
			| (ToTerm("(") + rhs + ToTerm(")"))
			| (rhs + ToTerm("|") + rhs)
			| rhs + ToTerm(",") + rhs
			;

		rule.Rule = lhs + ToTerm("=") + rhs + ToTerm(";") ;

		grammar.Rule = MakeStarRule(grammar, rule);

		this.Root = grammar;    // Set grammar root

		// 4. Operators precedence

		// 5. Punctuation and transient terms

		//automatically add NewLine before EOF so that our BNF rules work correctly when there's no final line break in source
		this.LanguageFlags = Irony.Parsing.LanguageFlags.CreateAst 
			| Irony.Parsing.LanguageFlags.NewLineBeforeEOF;
	}
}
