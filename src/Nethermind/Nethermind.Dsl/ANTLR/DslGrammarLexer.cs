//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from DslGrammar.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class DslGrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		BOOLEAN_OPERATOR=1, ARITHMETIC_SYMBOL=2, SOURCE=3, WATCH=4, WHERE=5, PUBLISH=6, 
		AND=7, OR=8, CONTAINS=9, IS=10, NOT=11, PUBLISH_VALUE=12, WEBSOCKETS=13, 
		TELEGRAM=14, WORD=15, BYTECODE=16, DIGIT=17, ADDRESS=18, WS=19;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"BOOLEAN_OPERATOR", "ARITHMETIC_SYMBOL", "SOURCE", "WATCH", "WHERE", "PUBLISH", 
		"AND", "OR", "CONTAINS", "IS", "NOT", "PUBLISH_VALUE", "WEBSOCKETS", "TELEGRAM", 
		"WORD", "BYTECODE", "DIGIT", "ADDRESS", "WS"
	};


	public DslGrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public DslGrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, "'SOURCE'", "'WATCH'", "'WHERE'", "'PUBLISH'", "'AND'", 
		"'OR'", "'CONTAINS'", "'IS'", "'NOT'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "BOOLEAN_OPERATOR", "ARITHMETIC_SYMBOL", "SOURCE", "WATCH", "WHERE", 
		"PUBLISH", "AND", "OR", "CONTAINS", "IS", "NOT", "PUBLISH_VALUE", "WEBSOCKETS", 
		"TELEGRAM", "WORD", "BYTECODE", "DIGIT", "ADDRESS", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "DslGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static DslGrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x15', '\xC1', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x3', '\x2', '\x3', '\x2', '\x5', 
		'\x2', ',', '\n', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x5', '\x3', '\x39', '\n', '\x3', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x5', '\r', 'o', 
		'\n', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x5', '\xE', '\x8F', '\n', '\xE', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x5', '\xF', 
		'\xA1', '\n', '\xF', '\x3', '\x10', '\x6', '\x10', '\xA4', '\n', '\x10', 
		'\r', '\x10', '\xE', '\x10', '\xA5', '\x3', '\x11', '\x6', '\x11', '\xA9', 
		'\n', '\x11', '\r', '\x11', '\xE', '\x11', '\xAA', '\x3', '\x12', '\x6', 
		'\x12', '\xAE', '\n', '\x12', '\r', '\x12', '\xE', '\x12', '\xAF', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\a', '\x13', '\xB6', 
		'\n', '\x13', '\f', '\x13', '\xE', '\x13', '\xB9', '\v', '\x13', '\x3', 
		'\x14', '\x6', '\x14', '\xBC', '\n', '\x14', '\r', '\x14', '\xE', '\x14', 
		'\xBD', '\x3', '\x14', '\x3', '\x14', '\x2', '\x2', '\x15', '\x3', '\x3', 
		'\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', 
		'\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', 
		'\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', 
		'\x13', '%', '\x14', '\'', '\x15', '\x3', '\x2', '\a', '\x4', '\x2', '>', 
		'>', '@', '@', '\x4', '\x2', '\x43', '\\', '\x63', '|', '\x5', '\x2', 
		'\x32', ';', '\x43', 'H', '\x63', 'h', '\x3', '\x2', '\x32', ';', '\x5', 
		'\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x2', '\xD0', '\x2', '\x3', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x3', '+', '\x3', 
		'\x2', '\x2', '\x2', '\x5', '\x38', '\x3', '\x2', '\x2', '\x2', '\a', 
		':', '\x3', '\x2', '\x2', '\x2', '\t', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\v', 'G', '\x3', '\x2', '\x2', '\x2', '\r', 'M', '\x3', '\x2', '\x2', 
		'\x2', '\xF', 'U', '\x3', '\x2', '\x2', '\x2', '\x11', 'Y', '\x3', '\x2', 
		'\x2', '\x2', '\x13', '\\', '\x3', '\x2', '\x2', '\x2', '\x15', '\x65', 
		'\x3', '\x2', '\x2', '\x2', '\x17', 'h', '\x3', '\x2', '\x2', '\x2', '\x19', 
		'n', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x8E', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', '\xA0', '\x3', '\x2', '\x2', '\x2', '\x1F', '\xA3', '\x3', 
		'\x2', '\x2', '\x2', '!', '\xA8', '\x3', '\x2', '\x2', '\x2', '#', '\xAD', 
		'\x3', '\x2', '\x2', '\x2', '%', '\xB1', '\x3', '\x2', '\x2', '\x2', '\'', 
		'\xBB', '\x3', '\x2', '\x2', '\x2', ')', ',', '\x5', '\x5', '\x3', '\x2', 
		'*', ',', '\x5', '\x13', '\n', '\x2', '+', ')', '\x3', '\x2', '\x2', '\x2', 
		'+', '*', '\x3', '\x2', '\x2', '\x2', ',', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '-', '.', '\a', '?', '\x2', '\x2', '.', '\x39', '\a', '?', '\x2', 
		'\x2', '/', '\x30', '\a', '#', '\x2', '\x2', '\x30', '\x39', '\a', '?', 
		'\x2', '\x2', '\x31', '\x39', '\t', '\x2', '\x2', '\x2', '\x32', '\x33', 
		'\a', '>', '\x2', '\x2', '\x33', '\x39', '\a', '?', '\x2', '\x2', '\x34', 
		'\x35', '\a', '@', '\x2', '\x2', '\x35', '\x39', '\a', '?', '\x2', '\x2', 
		'\x36', '\x39', '\x5', '\x15', '\v', '\x2', '\x37', '\x39', '\x5', '\x17', 
		'\f', '\x2', '\x38', '-', '\x3', '\x2', '\x2', '\x2', '\x38', '/', '\x3', 
		'\x2', '\x2', '\x2', '\x38', '\x31', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x32', '\x3', '\x2', '\x2', '\x2', '\x38', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', '\x37', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\x6', '\x3', '\x2', '\x2', '\x2', ':', ';', 
		'\a', 'U', '\x2', '\x2', ';', '<', '\a', 'Q', '\x2', '\x2', '<', '=', 
		'\a', 'W', '\x2', '\x2', '=', '>', '\a', 'T', '\x2', '\x2', '>', '?', 
		'\a', '\x45', '\x2', '\x2', '?', '@', '\a', 'G', '\x2', '\x2', '@', '\b', 
		'\x3', '\x2', '\x2', '\x2', '\x41', '\x42', '\a', 'Y', '\x2', '\x2', '\x42', 
		'\x43', '\a', '\x43', '\x2', '\x2', '\x43', '\x44', '\a', 'V', '\x2', 
		'\x2', '\x44', '\x45', '\a', '\x45', '\x2', '\x2', '\x45', '\x46', '\a', 
		'J', '\x2', '\x2', '\x46', '\n', '\x3', '\x2', '\x2', '\x2', 'G', 'H', 
		'\a', 'Y', '\x2', '\x2', 'H', 'I', '\a', 'J', '\x2', '\x2', 'I', 'J', 
		'\a', 'G', '\x2', '\x2', 'J', 'K', '\a', 'T', '\x2', '\x2', 'K', 'L', 
		'\a', 'G', '\x2', '\x2', 'L', '\f', '\x3', '\x2', '\x2', '\x2', 'M', 'N', 
		'\a', 'R', '\x2', '\x2', 'N', 'O', '\a', 'W', '\x2', '\x2', 'O', 'P', 
		'\a', '\x44', '\x2', '\x2', 'P', 'Q', '\a', 'N', '\x2', '\x2', 'Q', 'R', 
		'\a', 'K', '\x2', '\x2', 'R', 'S', '\a', 'U', '\x2', '\x2', 'S', 'T', 
		'\a', 'J', '\x2', '\x2', 'T', '\xE', '\x3', '\x2', '\x2', '\x2', 'U', 
		'V', '\a', '\x43', '\x2', '\x2', 'V', 'W', '\a', 'P', '\x2', '\x2', 'W', 
		'X', '\a', '\x46', '\x2', '\x2', 'X', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'Y', 'Z', '\a', 'Q', '\x2', '\x2', 'Z', '[', '\a', 'T', '\x2', '\x2', 
		'[', '\x12', '\x3', '\x2', '\x2', '\x2', '\\', ']', '\a', '\x45', '\x2', 
		'\x2', ']', '^', '\a', 'Q', '\x2', '\x2', '^', '_', '\a', 'P', '\x2', 
		'\x2', '_', '`', '\a', 'V', '\x2', '\x2', '`', '\x61', '\a', '\x43', '\x2', 
		'\x2', '\x61', '\x62', '\a', 'K', '\x2', '\x2', '\x62', '\x63', '\a', 
		'P', '\x2', '\x2', '\x63', '\x64', '\a', 'U', '\x2', '\x2', '\x64', '\x14', 
		'\x3', '\x2', '\x2', '\x2', '\x65', '\x66', '\a', 'K', '\x2', '\x2', '\x66', 
		'g', '\a', 'U', '\x2', '\x2', 'g', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'h', 'i', '\a', 'P', '\x2', '\x2', 'i', 'j', '\a', 'Q', '\x2', '\x2', 
		'j', 'k', '\a', 'V', '\x2', '\x2', 'k', '\x18', '\x3', '\x2', '\x2', '\x2', 
		'l', 'o', '\x5', '\x1B', '\xE', '\x2', 'm', 'o', '\x5', '\x1D', '\xF', 
		'\x2', 'n', 'l', '\x3', '\x2', '\x2', '\x2', 'n', 'm', '\x3', '\x2', '\x2', 
		'\x2', 'o', '\x1A', '\x3', '\x2', '\x2', '\x2', 'p', 'q', '\a', 'Y', '\x2', 
		'\x2', 'q', 'r', '\a', 'g', '\x2', '\x2', 'r', 's', '\a', '\x64', '\x2', 
		'\x2', 's', 't', '\a', 'U', '\x2', '\x2', 't', 'u', '\a', 'q', '\x2', 
		'\x2', 'u', 'v', '\a', '\x65', '\x2', '\x2', 'v', 'w', '\a', 'm', '\x2', 
		'\x2', 'w', 'x', '\a', 'g', '\x2', '\x2', 'x', 'y', '\a', 'v', '\x2', 
		'\x2', 'y', '\x8F', '\a', 'u', '\x2', '\x2', 'z', '{', '\a', 'y', '\x2', 
		'\x2', '{', '|', '\a', 'g', '\x2', '\x2', '|', '}', '\a', '\x64', '\x2', 
		'\x2', '}', '~', '\a', 'U', '\x2', '\x2', '~', '\x7F', '\a', 'q', '\x2', 
		'\x2', '\x7F', '\x80', '\a', '\x65', '\x2', '\x2', '\x80', '\x81', '\a', 
		'm', '\x2', '\x2', '\x81', '\x82', '\a', 'g', '\x2', '\x2', '\x82', '\x83', 
		'\a', 'v', '\x2', '\x2', '\x83', '\x8F', '\a', 'u', '\x2', '\x2', '\x84', 
		'\x85', '\a', 'y', '\x2', '\x2', '\x85', '\x86', '\a', 'g', '\x2', '\x2', 
		'\x86', '\x87', '\a', '\x64', '\x2', '\x2', '\x87', '\x88', '\a', 'u', 
		'\x2', '\x2', '\x88', '\x89', '\a', 'q', '\x2', '\x2', '\x89', '\x8A', 
		'\a', '\x65', '\x2', '\x2', '\x8A', '\x8B', '\a', 'm', '\x2', '\x2', '\x8B', 
		'\x8C', '\a', 'g', '\x2', '\x2', '\x8C', '\x8D', '\a', 'v', '\x2', '\x2', 
		'\x8D', '\x8F', '\a', 'u', '\x2', '\x2', '\x8E', 'p', '\x3', '\x2', '\x2', 
		'\x2', '\x8E', 'z', '\x3', '\x2', '\x2', '\x2', '\x8E', '\x84', '\x3', 
		'\x2', '\x2', '\x2', '\x8F', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x90', 
		'\x91', '\a', 'V', '\x2', '\x2', '\x91', '\x92', '\a', 'g', '\x2', '\x2', 
		'\x92', '\x93', '\a', 'n', '\x2', '\x2', '\x93', '\x94', '\a', 'g', '\x2', 
		'\x2', '\x94', '\x95', '\a', 'i', '\x2', '\x2', '\x95', '\x96', '\a', 
		't', '\x2', '\x2', '\x96', '\x97', '\a', '\x63', '\x2', '\x2', '\x97', 
		'\xA1', '\a', 'o', '\x2', '\x2', '\x98', '\x99', '\a', 'v', '\x2', '\x2', 
		'\x99', '\x9A', '\a', 'g', '\x2', '\x2', '\x9A', '\x9B', '\a', 'n', '\x2', 
		'\x2', '\x9B', '\x9C', '\a', 'g', '\x2', '\x2', '\x9C', '\x9D', '\a', 
		'i', '\x2', '\x2', '\x9D', '\x9E', '\a', 't', '\x2', '\x2', '\x9E', '\x9F', 
		'\a', '\x63', '\x2', '\x2', '\x9F', '\xA1', '\a', 'o', '\x2', '\x2', '\xA0', 
		'\x90', '\x3', '\x2', '\x2', '\x2', '\xA0', '\x98', '\x3', '\x2', '\x2', 
		'\x2', '\xA1', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA4', '\t', 
		'\x3', '\x2', '\x2', '\xA3', '\xA2', '\x3', '\x2', '\x2', '\x2', '\xA4', 
		'\xA5', '\x3', '\x2', '\x2', '\x2', '\xA5', '\xA3', '\x3', '\x2', '\x2', 
		'\x2', '\xA5', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xA6', ' ', '\x3', 
		'\x2', '\x2', '\x2', '\xA7', '\xA9', '\t', '\x4', '\x2', '\x2', '\xA8', 
		'\xA7', '\x3', '\x2', '\x2', '\x2', '\xA9', '\xAA', '\x3', '\x2', '\x2', 
		'\x2', '\xAA', '\xA8', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', '\x3', 
		'\x2', '\x2', '\x2', '\xAB', '\"', '\x3', '\x2', '\x2', '\x2', '\xAC', 
		'\xAE', '\t', '\x5', '\x2', '\x2', '\xAD', '\xAC', '\x3', '\x2', '\x2', 
		'\x2', '\xAE', '\xAF', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xAD', '\x3', 
		'\x2', '\x2', '\x2', '\xAF', '\xB0', '\x3', '\x2', '\x2', '\x2', '\xB0', 
		'$', '\x3', '\x2', '\x2', '\x2', '\xB1', '\xB2', '\a', '\x32', '\x2', 
		'\x2', '\xB2', '\xB3', '\a', 'z', '\x2', '\x2', '\xB3', '\xB7', '\x3', 
		'\x2', '\x2', '\x2', '\xB4', '\xB6', '\t', '\x4', '\x2', '\x2', '\xB5', 
		'\xB4', '\x3', '\x2', '\x2', '\x2', '\xB6', '\xB9', '\x3', '\x2', '\x2', 
		'\x2', '\xB7', '\xB5', '\x3', '\x2', '\x2', '\x2', '\xB7', '\xB8', '\x3', 
		'\x2', '\x2', '\x2', '\xB8', '&', '\x3', '\x2', '\x2', '\x2', '\xB9', 
		'\xB7', '\x3', '\x2', '\x2', '\x2', '\xBA', '\xBC', '\t', '\x6', '\x2', 
		'\x2', '\xBB', '\xBA', '\x3', '\x2', '\x2', '\x2', '\xBC', '\xBD', '\x3', 
		'\x2', '\x2', '\x2', '\xBD', '\xBB', '\x3', '\x2', '\x2', '\x2', '\xBD', 
		'\xBE', '\x3', '\x2', '\x2', '\x2', '\xBE', '\xBF', '\x3', '\x2', '\x2', 
		'\x2', '\xBF', '\xC0', '\b', '\x14', '\x2', '\x2', '\xC0', '(', '\x3', 
		'\x2', '\x2', '\x2', '\r', '\x2', '+', '\x38', 'n', '\x8E', '\xA0', '\xA5', 
		'\xAA', '\xAF', '\xB7', '\xBD', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
