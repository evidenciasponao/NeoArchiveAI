using System.Diagnostics;
using Microsoft.Extensions.Options;
using NeoArchiveAI.Application.Abstractions.Services;
using NeoArchiveAI.Infrastructure.Configuration;

namespace NeoArchiveAI.Infrastructure.Services;

public sealed class TesseractOcrService : IOcrService
{
    private readonly OcrOptions _options;

    public TesseractOcrService(
        IOptions<OcrOptions> options)
    {
        _options = options.Value;
    }

    public async Task<string> ExtractTextAsync(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        var imageFile = Path.Combine(
            Path.GetTempPath(),
            $"{Guid.NewGuid()}.png");

        var outputBase = Path.Combine(
            Path.GetTempPath(),
            Guid.NewGuid().ToString());

        var outputFile = $"{outputBase}.txt";

        try
        {
            // Guardar imagen temporal
            await using (var file = File.Create(imageFile))
            {
                await stream.CopyToAsync(
                    file,
                    cancellationToken);
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = _options.ExecutablePath,

                    Arguments =
                        $"\"{imageFile}\" \"{outputBase}\" -l {_options.Languages}",

                    RedirectStandardOutput = true,
                    RedirectStandardError = true,

                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            await process.WaitForExitAsync(
                cancellationToken);

            if (process.ExitCode != 0)
            {
                var error =
                    await process.StandardError.ReadToEndAsync();

                throw new InvalidOperationException(
                    $"Tesseract execution failed.\n{error}");
            }

            if (!File.Exists(outputFile))
            {
                throw new FileNotFoundException(
                    "Tesseract did not generate the output file.");
            }

            var text =
                await File.ReadAllTextAsync(
                    outputFile,
                    cancellationToken);

            return text.Trim();
        }
        finally
        {
            if (File.Exists(imageFile))
            {
                File.Delete(imageFile);
            }

            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
        }
    }
}
