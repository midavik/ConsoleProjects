using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Spelling
{
    public class MessageConverter
    {
        public Dictionary<char, CodeMapping> SymbolsMapping { get; set; }

        public void MapSymbols()
        {
            SymbolsMapping = new Dictionary<char, CodeMapping>();

            try
            {
                SymbolsMapping.Add('a', new CodeMapping(2, 1));
                SymbolsMapping.Add('b', new CodeMapping(2, 2));
                SymbolsMapping.Add('c', new CodeMapping(2, 3));
                SymbolsMapping.Add('d', new CodeMapping(3, 1));
                SymbolsMapping.Add('e', new CodeMapping(3, 2));
                SymbolsMapping.Add('f', new CodeMapping(3, 3));
                SymbolsMapping.Add('g', new CodeMapping(4, 1));
                SymbolsMapping.Add('h', new CodeMapping(4, 2));
                SymbolsMapping.Add('i', new CodeMapping(4, 3));
                SymbolsMapping.Add('j', new CodeMapping(5, 1));
                SymbolsMapping.Add('k', new CodeMapping(5, 2));
                SymbolsMapping.Add('l', new CodeMapping(5, 3));
                SymbolsMapping.Add('m', new CodeMapping(6, 1));
                SymbolsMapping.Add('n', new CodeMapping(6, 2));
                SymbolsMapping.Add('o', new CodeMapping(6, 3));
                SymbolsMapping.Add('p', new CodeMapping(7, 1));
                SymbolsMapping.Add('q', new CodeMapping(7, 2));
                SymbolsMapping.Add('r', new CodeMapping(7, 3));
                SymbolsMapping.Add('s', new CodeMapping(7, 4));
                SymbolsMapping.Add('t', new CodeMapping(8, 1));
                SymbolsMapping.Add('u', new CodeMapping(8, 2));
                SymbolsMapping.Add('v', new CodeMapping(8, 3));
                SymbolsMapping.Add('w', new CodeMapping(9, 1));
                SymbolsMapping.Add('x', new CodeMapping(9, 2));
                SymbolsMapping.Add('y', new CodeMapping(9, 3));
                SymbolsMapping.Add('z', new CodeMapping(9, 4));
                SymbolsMapping.Add(' ', new CodeMapping(0, 1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConvertMessage(string message)
        {
            StringBuilder convertedMessage = new StringBuilder();

            int? priorSymbolCode = null;
            CodeMapping currentSymbolCodeMapping = null;

            try
            {
                for (int i = 0; i < message.Length; i++)
                {
                    char character = message[i];
                    SymbolsMapping.TryGetValue(character, out currentSymbolCodeMapping);
                    if (priorSymbolCode == currentSymbolCodeMapping.Code)
                    {
                        convertedMessage.Append(" ");
                    }

                    for (int j = 0; j < currentSymbolCodeMapping.RepeatCodeNr; j++)
                    {
                        convertedMessage.Append(currentSymbolCodeMapping.Code);
                    }
                    priorSymbolCode = currentSymbolCodeMapping.Code;
                }
                return convertedMessage.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateMessage(string message)
        {
            try
            {
                return Validation.ValidateMessage(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateNumberOfCases(string number)
        {
            try
            {
                return Validation.ValidateNumberOfCases(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool FileExists(string fileName)
        {
            try
            {
                return Validation.FileExists(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
