﻿using System.Text;

using Net.Codecrete.QrCodeGenerator;
using SkiaSharp;

if (args.Length != 2)
{
    Console.WriteLine("Usage: qr text filename");
    Console.WriteLine();
    Console.WriteLine("  Examples:");
    Console.WriteLine("    qr 'Hello, World!' hello-world-qr.svg");
    Console.WriteLine("    qr 12345 12345.svg");
    Console.WriteLine("    qr 'https://www.google.com/' google.png");
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
        qr.SaveAsPng(filename, scale: 10, border: 1, foreground: SKColors.Black, background: SKColors.White.WithAlpha(0x00));
        break;
    default:
        string svg = qr.ToSvgString(4);
        File.WriteAllText(filename, svg, Encoding.UTF8);
        break;
}
