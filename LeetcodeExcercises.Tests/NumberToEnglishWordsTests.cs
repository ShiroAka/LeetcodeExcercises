using FluentAssertions;

namespace LeetcodeExcercises.Tests
{
    public class NumberToEnglishWordsTests
    {
        [Fact]
        public void BasicTestV1() //Using the "NumberToEnglishWords" class
        {
            int number = 123;
            string result = NumberToEnglishWords.NumberToWords(number);

            Console.WriteLine($"Number:\t{number}");
            Console.WriteLine($"Nuumber in English: ", result);

            result.Should().Be("One Hundred Twenty Three");
        }

        [Fact]
        public void BasicTestV2() //Using the "NumberToEnglishWordsV2" class
        {
            int number = 100000;
            string result = NumberToEnglishWordsV2.NumberToWords(number);

            Console.WriteLine($"Number:\t{number}");
            Console.WriteLine($"Nuumber in English: ", result);

            result.Should().Be("One Hundred Thousand");
        }
    }
}
