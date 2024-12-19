using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net.Codecrete.QrCodeGenerator;
using PixApi.DTOs;

namespace PixApi.Services
{
    public interface IPixService
    {
        byte[] GenerateQRCode(QrCodeInput input);
    }
}