using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SortDictionaryWin {
    class WriteToTextFile{

		// Builds the new file name using the data it gets from the sub string, sort mode and min and max length
		private static string buildNewFileName(string fileName, string subStr, SortText.SortMode mode, int min, int max) {
			string newFileName = fileName;
			if (!String.IsNullOrEmpty(subStr) && !String.IsNullOrWhiteSpace(subStr)) {
				newFileName += "_" + mode.ToString();
				newFileName += "_" + subStr;
			}
			if (min >= 0 && max > 0 && min <= max) {
				newFileName += "_length[" + min + "," + max + "]";
			}

			return newFileName;
		}

		// Writes the words to a new file name
		// the file name is built using the subStr, mode, and min and max length
		public static void write(string path, string fileName, string subStr, SortText.SortMode mode, int min, int max, List<string> words) {
			string newFileName = buildNewFileName(fileName, subStr, mode, min, max);

			Console.WriteLine("Writing words to file: " + newFileName);

			try {

				string newFileNameExt = newFileName + ".txt";
				StreamWriter writer = new StreamWriter(path + newFileNameExt);
				foreach (string word in words) {
					writer.WriteLine(word);
				}
				writer.Close();
				Console.WriteLine("Done writing");
			} catch (Exception e) {
				Console.WriteLine(e.StackTrace);
				Console.WriteLine(e.Message);
			}
		}

    }
}
