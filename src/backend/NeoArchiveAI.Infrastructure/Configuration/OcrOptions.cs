namespace NeoArchiveAI.Infrastructure.Configuration;

public sealed class OcrOptions
{
    public const string SectionName = "Ocr";

    public string ExecutablePath { get; init; } =
        "/usr/bin/tesseract";

    public string Languages { get; init; } =
        "spa+eng";
}
