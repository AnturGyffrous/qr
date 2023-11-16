using System.Text;

using Net.Codecrete.QrCodeGenerator;

var qr = QrCode.EncodeText("Hello, world!", QrCode.Ecc.Medium);
string svg = qr.ToSvgString(4);
File.WriteAllText("hello-world-qr.svg", svg, Encoding.UTF8);
