using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace TriFy.Car.Downloader.IO
{
    public class FileManager : DomainService, IFileManager
    {

        private readonly IConverter _converter;

        public FileManager(IConverter converter)
        {
            _converter = converter;
        }
        
        public Task<byte[]> CreateAsync(string userId, string htmlContent)
        {
            Check.NotNullOrWhiteSpace(userId, nameof(userId));
            Check.NotNullOrWhiteSpace(htmlContent, nameof(htmlContent));

            Logger.LogInformation("Creating PDF file.");

            Logger.LogDebug($"HTML Content: {Environment.NewLine} {htmlContent}");

            //var name = string.Concat(filename, ".pdf");
            var buffer = _converter.Convert(new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4Plus
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = {
                            DefaultEncoding = "utf-8",
                        },
                        HeaderSettings = {
                            Left = "TriFy Chrome Extension",
                            FontSize = 12,
                            Right = "[page]/[toPage]",
                            Line = true,
                            Spacing = 2.812
                        },
                        FooterSettings = {
                            Left = string.Concat("ID ", userId)
                        }
                    }
                }
            });             

            return Task.FromResult(buffer);
        }

        public async Task WriteAsync(byte[] buffer, string filename)
        {
            Logger.LogInformation($"Output file: {filename}.");

            var outputPath = Path.GetDirectoryName(filename);
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            using (var fileStream = File.Create(filename, buffer.Length, FileOptions.Asynchronous))
            {
                await fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
