using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy
{

    public abstract class EnglishСipher 
    {
        internal char[] alphabet = new char[52];
        internal virtual string Decipher(string text) { return string.Empty; }
        internal virtual string Encrypt(string text) { return string.Empty; }

        public EnglishСipher() => FillAlphabet();
        private void FillAlphabet()
        {
            int a = 65;

            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)a;
                a++;
            }

            a = 97;

            for (int i = 26; i < 52; i++)
            {
                alphabet[i] = (char)a;
                a++;
            }
        }
    }

    public class CaesarСipher: EnglishСipher 
    {
        override internal string Decipher(string text)
        {
            string decipherText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                int index = Array.IndexOf(alphabet, text[i]);

                if (index != -1)
                {
                    if (index == 0) decipherText += alphabet[alphabet.Length / 2 - 1];
                    else if (index == alphabet.Length / 2) decipherText += alphabet[alphabet.Length - 1];
                    else decipherText += alphabet[index - 1];
                }
                else decipherText += text[i];
            }

            return decipherText;
        }
        override internal string Encrypt(string text)
        {
            string encryptText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                int index = Array.IndexOf(alphabet, text[i]) + 1;

                if (index != -1)
                {
                    if (index - 1 == alphabet.Length / 2 - 1) encryptText += alphabet[0];
                    else if (index < alphabet.Length) encryptText += alphabet[index];
                    else encryptText += alphabet[alphabet.Length / 2];
                } 
                else encryptText += text[i];
            }

            return encryptText;
        }
    }
    public class AtbashСipher: EnglishСipher
    {
        override internal string Decipher(string text)
        {
            return Encrypt(text);
        }
        override internal string Encrypt(string text)
        {
            string encryptText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                int index = Array.IndexOf(alphabet, text[i]);

                if (index != -1)
                {
                    index += 1;
                    if (index < alphabet.Length / 2) encryptText += alphabet[alphabet.Length / 2 - index];
                    else if (index > alphabet.Length / 2) encryptText += alphabet[alphabet.Length / 2 - index + alphabet.Length];
                }
                else encryptText += text[i];
            }

            return encryptText;
        }
    }

    public class Transcript 
    {
        public EnglishСipher сipher { get; set; }
        public string text { get; set; }

        public Transcript(EnglishСipher сipher, string text) 
        {
            this.сipher = сipher;
            this.text = text;
        }

        public void DecipherText()
        {
            string decipherText = сipher.Decipher(text);
            Console.WriteLine(decipherText);
        }

        public void EncryptText()
        {
            string encryptText = сipher.Encrypt(text);
            Console.WriteLine(encryptText);
        }
    }

    internal class Program
    {
        static void Main()
        {
            EnglishСipher caesarCipher = new CaesarСipher();
            EnglishСipher atbashСipher = new AtbashСipher();

            string text = Console.ReadLine();

            Transcript transcript1 = new Transcript(atbashСipher, text);
            transcript1.DecipherText();
            transcript1.EncryptText();

            Transcript transcript2 = new Transcript(caesarCipher, text);
            transcript2.DecipherText();
            transcript2.EncryptText();

            Console.ReadLine();
        }
    }
}
