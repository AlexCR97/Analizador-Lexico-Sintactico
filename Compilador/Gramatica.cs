using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Gramatica : Grammar
    {
        #region No Terminales
        public static readonly string NoTerminalInicio = "<inicio>";
        public static readonly string NoTerminalTipo = "<tipo>";
        public static readonly string NoTerminalValor = "<valor>";
        #endregion

        #region Terminales
        public static readonly string TerminalTipoInt = "int";
        public static readonly string TerminalTipoFloat = "float";
        public static readonly string TerminalTipoDouble = "double";
        public static readonly string TerminalTipoString = "string";
        public static readonly string TerminalIgual = "=";
        public static readonly string TerminalPuntoYComa = ";";
        #endregion

        #region Expresiones regulares
        public static readonly string RegexIdentificador = "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*";
        public static readonly string RegexValorNumero = "\\d+[f|d]?(\\.\\d+[f|d]?)?";
        public static readonly string RegexValorString = "\"[^\"]*\"";
        public static readonly string RegexValorIdentificador = "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*";
        #endregion

        public Gramatica() : base()
        {
            #region No Terminales
            var noTerminalInicio = new NonTerminal(NoTerminalInicio);
            var noTerminalTipo = new NonTerminal(NoTerminalTipo);
            var noTerminalValor = new NonTerminal(NoTerminalValor);
            #endregion

            #region Terminales
            var terminalTipoInt = ToTerm(TerminalTipoInt);
            var terminalTipoFloat = ToTerm(TerminalTipoFloat);
            var terminalTipoDouble = ToTerm(TerminalTipoDouble);
            var terminalTipoString = ToTerm(TerminalTipoString);
            var terminalIgual = ToTerm(TerminalIgual);
            var terminalPuntoYComa = ToTerm(TerminalPuntoYComa);
            #endregion

            #region Expresiones Regulares
            var regexIdentificador = new RegexBasedTerminal(RegexIdentificador);
            var regexValorNumero = new RegexBasedTerminal(RegexValorNumero);
            var regexValorString = new RegexBasedTerminal(RegexValorString);
            var regexValorIdentificador = new RegexBasedTerminal(RegexValorIdentificador);
            #endregion

            #region Reglas de produccion
            noTerminalInicio.Rule =
                noTerminalTipo + regexIdentificador + terminalPuntoYComa |
                noTerminalTipo + regexIdentificador + terminalPuntoYComa + noTerminalInicio |
                noTerminalTipo + regexIdentificador + terminalIgual + noTerminalValor + terminalPuntoYComa |
                noTerminalTipo + regexIdentificador + terminalIgual + noTerminalValor + terminalPuntoYComa + noTerminalInicio;

            noTerminalTipo.Rule =
                terminalTipoInt |
                terminalTipoFloat |
                terminalTipoDouble |
                terminalTipoString;

            noTerminalValor.Rule =
                regexValorNumero |
                regexValorString |
                regexValorIdentificador;
            #endregion

            Root = noTerminalInicio;
        }
    }
}
