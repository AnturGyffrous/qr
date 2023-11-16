using System.Text;

using Net.Codecrete.QrCodeGenerator;

if (args.Length != 2)
{
    Console.WriteLine("Usage: qr text filename");
    return;
}

var qr = QrCode.EncodeText(args[0], QrCode.Ecc.Medium);
string svg = qr.ToSvgString(4);
File.WriteAllText(args[1], svg, Encoding.UTF8);
