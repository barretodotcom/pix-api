using System.Drawing;
using System.Text;
using PixApi.DTOs;
using PixApi.Models;
using QRCoder;
using NullFX;
using NullFX.CRC;

namespace PixApi.Services
{
    public class PixService : IPixService
    {
        public byte[] GenerateQRCode(QrCodeInput input)
        {

            Pix pix = new Pix()
            {
                Key = input.Key,
                TxId = Guid.NewGuid(),
                Value = input.Value,
                CountryCode = input.CountryCode,
                MerchantCategoryCode = input.MerchantCategoryCode,
                MerchantCity = input.MerchantCity,
                MerchantName = input.MerchantName,
                Fss = input.Fss,
            };

            string qrCode = "0002010102112633";

            qrCode += "0014" + pix.Gui.ToString();
            qrCode += "01" + pix.Key.Length.ToString() + pix.Key;
            qrCode += "52" + "0"  + pix.MerchantCategoryCode.Length.ToString() + pix.MerchantCategoryCode;
            qrCode += "53" + "03" + "986";
            qrCode += "54" + "0" + pix.Value.Length.ToString() + pix.Value;
            qrCode += "58" + "0" + pix.CountryCode.Length.ToString() + pix.CountryCode;
            qrCode += "59" + pix.MerchantName.Length.ToString() + pix.MerchantName;
            qrCode += "60" + "0" + pix.MerchantCity.Length.ToString() + pix.MerchantCity;
            qrCode += "62070503***";
            qrCode += "63" + "04";

            var convertBytes = UTF8Encoding.UTF8.GetBytes(qrCode);
            var crc16 = NullFX.CRC.Crc16.ComputeChecksum(Crc16Algorithm.CcittInitialValue0xFFFF, convertBytes);
            qrCode += crc16.ToString("X2");

            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            Console.WriteLine(qrCode);
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCode, QRCodeGenerator.ECCLevel.Q);
            Console.WriteLine(qrCode);
            using (PngByteQRCode pngQRCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = pngQRCode.GetGraphic(4); 

                return qrCodeImage;
            }
        }
    }
}