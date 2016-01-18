using System;
using Irony.Parsing;
using Irony.Ast;
using System.Diagnostics;

namespace test1
{
	class MainClass
	{
		public static readonly string text_to_compile = @"
			letter = ""A"" | ""B"" | ""C"" | ""D"" | ""E"" | ""F"" | ""G""
			| ""H"" | ""I"" | ""J"" | ""K"" | ""L"" | ""M"" | ""N""
			| ""O"" | ""P"" | ""Q"" | ""R"" | ""S"" | ""T"" | ""U""
			| ""V"" | ""W"" | ""X"" | ""Y"" | ""Z"" | ""a"" | ""b""
			| ""c"" | ""d"" | ""e"" | ""f"" | ""g"" | ""h"" | ""i""
			| ""j"" | ""k"" | ""l"" | ""m"" | ""n"" | ""o"" | ""p""
			| ""q"" | ""r"" | ""s"" | ""t"" | ""u"" | ""v"" | ""w""
			| ""x"" | ""y"" | ""z"" ;
			digit = ""0"" | ""1"" | ""2"" | ""3"" | ""4"" | ""5"" | ""6"" | ""7"" | ""8"" | ""9"" ;
			symbol = ""["" | ""]"" | ""{"" | ""}"" | ""("" | "")"" | ""<"" | "">""
			| ""'"" | '""' | ""="" | ""|"" | ""."" | "","" | "";"" ;
			character = letter | digit | symbol | ""_"" ;

			identifier = letter , { letter | digit | ""_"" } ;
			terminal = ""'"" , character , { character } , ""'"" 
			| '""' , character , { character } , '""' ;

			lhs = identifier ;
			rhs = identifier
			| terminal
			| ""["" , rhs , ""]""
			| ""{"" , rhs , ""}""
			| ""("" , rhs , "")""
			| rhs , ""|"" , rhs
			| rhs , "","" , rhs ;

			rule = lhs , ""="" , rhs , "";"" ;
			grammar = { rule } ;
			";
		public static void Main (string[] args)
		{
			var grammar = new EbnfGrammar();
			var parser = new Parser(grammar);
			/*var errors = parser.Language.Errors;
			if (errors.Count > 0)
			{
				var msg = string.Format ("Unexpected grammar contains error(s): {0}" + Environment.NewLine, errors);
				throw new Exception(msg);
			}*/
			/*ParseTree*/ var tree = parser.Parse (text_to_compile);
			Debug.Assert (tree != null); // to suppress warning and for expression evaluator
			Debug.Assert (tree.Status == ParseTreeStatus.Parsed);
		}
	}
}
