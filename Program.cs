using System.Text;

using Net.Codecrete.QrCodeGenerator;

var qr = QrCode.EncodeText(args[0], QrCode.Ecc.Medium);
string svg = qr.ToSvgString(4);
File.WriteAllText(args[1], svg, Encoding.UTF8);
