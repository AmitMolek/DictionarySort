using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDictionaryWin {
	class HandleInput {

		string fileName;
		bool isSubStr;
		string subStr;
		int sortMode; // look into SortText.SortMode
		bool isLength;
		int minLen;
		int maxLen;

		const string sameFolderDisclaimer = "Make sure that the file is in the same folder as the .exe file";
		const string enterfileNameStr = "Enter the file name (without the extenstion):";
		const string useSubStrStr = "Do you want to check for a sub string ? (enter true or false):";
		const string enterModeStr = "Enter the mode you want to check for:";
		const string mode0Str = "0 = Starts with";
		const string mode1Str = "1 = Contains";
		const string mode2Str = "2 = Ends with";
		const string enterSubStrStr = "Enter the sub string you want to check for:";
		const string useLengthStr = "Do you want to check for length ? (enter true of false)";
		const string minLengthStr = "Enter the minimum length:";
		const string maxLengthStr = "Enter the maxmimum length:";

		public HandleInput() {
			getInput();
			handle();
		}

		private void getInput() {
			Console.WriteLine(sameFolderDisclaimer);

			Console.WriteLine(enterfileNameStr);
			fileName = Console.ReadLine();

			Console.WriteLine(useSubStrStr);
			isSubStr = bool.Parse(Console.ReadLine());

			if (isSubStr) {
				Console.WriteLine(enterModeStr);
				Console.WriteLine(mode0Str);
				Console.WriteLine(mode1Str);
				Console.WriteLine(mode2Str);
				sortMode = int.Parse(Console.ReadLine());

				Console.WriteLine(enterSubStrStr);
				subStr = Console.ReadLine();
			}

			Console.WriteLine(useLengthStr);
			isLength = bool.Parse(Console.ReadLine());

			if (isLength) {
				Console.WriteLine(minLengthStr);
				minLen = int.Parse(Console.ReadLine());
				Console.WriteLine(maxLengthStr);
				maxLen = int.Parse(Console.ReadLine());
			}

		}

		private void handle() {
			string path = fileName + ".txt";
			SortText sort = new SortText(path);
			List<string> words = new List<string>();

			// if the user want to check for sub string
			if (isSubStr) {
				words = sort.Sort_SubStr(subStr, (SortText.SortMode)sortMode);
				// if the use want the check for length too
				if (isLength)
					words = sort.Sort_Length(words, minLen, maxLen);
			}else {
				if (isLength)
					words = sort.Sort_Length(minLen, maxLen);
			}

			WriteToTextFile.write("", fileName, subStr, (SortText.SortMode)sortMode, minLen, maxLen, words);
		}

	}
}
