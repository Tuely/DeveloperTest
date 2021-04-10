#region Copyright statement
// --------------------------------------------------------------
// Copyright (C) 1999-2016 Exclaimer Ltd. All Rights Reserved.
// No part of this source file may be copied and/or distributed 
// without the express permission of a director of Exclaimer Ltd
// ---------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DeveloperTestInterfaces;

namespace DeveloperTest
{
  
    public sealed class DeveloperTestImplementation : IDeveloperTest
    {
        private static readonly char[] separators = { ' ' };
        public void RunQuestionOne(ICharacterReader reader, IOutputResult output)
        {
           // var text = "It was the best of times, it was the worst of times".ToLower();
            var text = reader.ToString();

            var match = Regex.Match(text, "\\w+");
            Dictionary<string, int> freq = new Dictionary<string, int>();
            while (match.Success)
            {
                string word = match.Value;
                if (freq.ContainsKey(word))
                {
                    freq[word]++;
                }
                else
                {
                    freq.Add(word, 1);
                }

                match = match.NextMatch();
            }

            Console.WriteLine("Rank  Word  Frequency Details");
        
            int rank = 1;
            foreach (var elem in freq.OrderByDescending(a => a.Value).Take(10))
            {
                Console.WriteLine("{0,2}    {1,-4}    {2,5}", rank++, elem.Key, elem.Value);
                output.AddResult(elem.ToString());
            }

        

    }

    public void RunQuestionTwo(ICharacterReader[] readers, IOutputResult output)
        {
            var wordCount = new Dictionary<string, int>();

         //   string line = "a list of word frequencies ordered by word count and then alphabetically";
            string line = readers.ToString();

            while ((line != null))
            {
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word] = wordCount[word] + 1;
                    }
                    else
                    {
                        wordCount.Add(word, 1);
                        output.AddResult(wordCount.ToString());
                    }
                }
            }
        }

    }
}
    
