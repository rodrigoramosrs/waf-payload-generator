using System.Text;

namespace WafPayload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine(@"                  _    _  ____   ___ ");
            Console.WriteLine(@"                 ( \/\/ )(  _ \ / __)");
            Console.WriteLine(@"                  )    (  )___/( (_-.");
            Console.WriteLine(@"                 (__/\__)(__)   \___/");
            Console.WriteLine(@"");
            Console.WriteLine($"Waf Payload Generator - By https://github.com/rodrigoramosrs ");
            Console.WriteLine("");
            Console.WriteLine("");
            
            if(args.Length == 0) {
                Console.WriteLine("No payload to generate... Input a payload and try again.");
                return;
            }

            string input = string.Join(" ", args); // Recebe a string como argumento de linha de comando
            string allStringEncodings = EncodeAll(input);
            string customEncoding = GetCustomEncodings(input);

            File.WriteAllText("payload.txt", $"\r\n[{input}]\r\n\r\n");
            File.AppendAllText("payload.txt", allStringEncodings);
            File.AppendAllText("payload.txt", customEncoding);

            Console.WriteLine(allStringEncodings);
            Console.WriteLine(customEncoding.ToString());

            Console.WriteLine($"Output file: payload.txt");
            Console.ReadKey();
        }

        private static string GetCustomEncodings(string input)
        {
            StringBuilder encodings = new StringBuilder();

            // URL Encoding
            string urlEncoded = Uri.EscapeDataString(input);
            encodings.AppendLine("[ URL Single ]\r\n" + urlEncoded);
            encodings.AppendLine("");

            
            // Double Encoding
            string doubleEncoded = Uri.EscapeDataString(Uri.EscapeDataString(input));
            encodings.AppendLine("[ Url Double ]\r\n" + doubleEncoded);
            encodings.AppendLine("");

            // Base64 Encoding
            string base64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
            encodings.AppendLine("[ Base64 ]\r\n" + base64Encoded);
            encodings.AppendLine("");

            // Hex Encoding
            StringBuilder hexEncoded = new StringBuilder();
            foreach (char c in input)
            {
                hexEncoded.AppendFormat("{0:x2}", (int)c);
            }
            encodings.AppendLine("[ Hexadecimal ] \r\n" + hexEncoded);
            encodings.AppendLine("");

            // Binary Encoding
            StringBuilder binaryEncoded = new StringBuilder();
            foreach (char c in input)
            {
                binaryEncoded.AppendFormat("{0}", Convert.ToString(c, 2));
            }
            encodings.AppendLine("[ Binary ]\r\n" + binaryEncoded);
            encodings.AppendLine("");

            // Octal Encoding
            StringBuilder octalEncoded = new StringBuilder();
            foreach (char c in input)
            {
                octalEncoded.AppendFormat("\\{0}", Convert.ToString(c, 8));
            }

            encodings.AppendLine("[ Octal ]\r\n" + binaryEncoded);
            encodings.AppendLine("");
            return encodings.ToString();
        }

        static string EncodeAll(string input)
        {
            StringBuilder output = new StringBuilder();
            foreach (EncodingInfo fronEncodingInfo in Encoding.GetEncodings())
            {
                Encoding fromEncoding = fronEncodingInfo.GetEncoding();
                byte[] encodedBytes = fromEncoding.GetBytes(input);
                foreach (EncodingInfo toEncodingInfo in Encoding.GetEncodings())
                {
                    Encoding toEncoding = toEncodingInfo.GetEncoding();
                    if (fromEncoding.EncodingName == toEncoding.EncodingName) continue;

                    output.AppendLine($"[ {fromEncoding.EncodingName} => {toEncoding.EncodingName} Raw ]\r\n {toEncoding.GetString(encodedBytes)}\r\n");
                    output.AppendLine($"[ {fromEncoding.EncodingName} => {toEncoding.EncodingName} Base64 ]\r\n {EncodingUtils.ToBase64(input)}\r\n");
                    output.AppendLine($"[ {fromEncoding.EncodingName} => {toEncoding.EncodingName} Hexadecimal ]\r\n {EncodingUtils.ToHex(input)}\r\n");
                    output.AppendLine();
                }
               
            }

            return output.ToString();
        }
    }
}
