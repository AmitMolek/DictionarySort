using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SortDictionaryWin {
    class SortText{

		string path;

		public enum SortMode {
			StartsWith,
			Contains,
			EndsWith
		};

		public SortText(string path) {
			this.path = path;
		}

		private void printWhenDone(int sortedLength, int readLength) {
			//Console.Clear();
			Console.WriteLine("Done sorting:");
			Console.WriteLine("Sorted: " + sortedLength + " | From: " + readLength);
		}

		// Sortes the words by sub string
		public List<string> Sort_SubStr(IEnumerable<string> words, string subStr, SortMode mode) {
			if (String.IsNullOrEmpty(path)) return null;

			int linesRead = 0;
			List<string> sorted = new List<string>();

			try {

				foreach (string line in words) {
					linesRead++;

					switch (mode) {
						case SortMode.StartsWith:
							if (line.StartsWith(subStr)) sorted.Add(line);
							break;
						case SortMode.EndsWith:
							if (line.EndsWith(subStr)) sorted.Add(line);
							break;
						default:
							if (line.Contains(subStr)) sorted.Add(line);
							break;
					}
				}

				printWhenDone(sorted.Count, linesRead);
				return sorted;
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
			return null;
		}

		// Sortes the text file words by a sub string
		public List<string> Sort_SubStr(string subStr, SortMode mode) {
			return Sort_SubStr(File.ReadLines(path), subStr, mode);
		}

		// Sortes the words by their length
		public List<string> Sort_Length(IEnumerable<string> words, int min, int max) {
			if (min > max) return null;

			int linesRead = 0;
			List<string> sorted = new List<string>();

			try {

				foreach (string line in words) {
					int len = line.Length;
					if (len >= min && len <= max) sorted.Add(line);
				}

				printWhenDone(sorted.Count, linesRead);
				return sorted;
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
			return null;
		}

		// Sortes the words file by their length
		public List<string> Sort_Length(int min, int max) {
			return Sort_Length(File.ReadLines(path), min, max);
		}

    }
}
