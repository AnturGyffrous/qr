using System.IO;
using System.Linq;
using System.Text;

using Net.Codecrete.QrCodeGenerator;

if (args.Length != 2)
{
    Console.WriteLine("Usage: qr text filename");
    return;
}

var filename = args[1];
var extension = Path.GetExtension(filename);

var validExtensions = new[] { ".SVG", ".PNG" };

if (!validExtensions.Contains(extension.ToUpper()))
{
    Console.WriteLine($"Invalid file extension {extension}");
    return;
}

var qr = QrCode.EncodeText(args[0], QrCode.Ecc.Medium);

switch (extension.ToUpper())
{
    case ".PNG":
        qr.SaveAsPng(filename, scale: 10, border: 4);
        break;
    default:
        string svg = qr.ToSvgString(4);
        File.WriteAllText(filename, svg, Encoding.UTF8);
        break;
}
